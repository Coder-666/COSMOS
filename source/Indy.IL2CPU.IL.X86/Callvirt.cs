using System;
using System.Linq;


using CPU = Indy.IL2CPU.Assembler;
using CPUx86 = Indy.IL2CPU.Assembler.X86;
using System.Reflection;
using Indy.IL2CPU.Assembler;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(OpCodeEnum.Callvirt, true)]
	public class Callvirt: Op {
		private readonly int mMethodIdentifier;
		private readonly string mNormalAddress;
		private readonly string mMethodDescription;
		private readonly int mThisOffset;
		private readonly int mArgumentCount;
		private readonly int mReturnSize;
		private readonly string mLabelName;
		private readonly MethodInformation mCurrentMethodInfo;
		private readonly MethodInformation mTargetMethodInfo;
		private readonly int mCurrentILOffset;
	    private readonly int mExtraStackSpace;
		public Callvirt(ILReader aReader, MethodInformation aMethodInfo)
			: base(aReader, aMethodInfo) {
			mLabelName = GetInstructionLabel(aReader);
			mCurrentMethodInfo = aMethodInfo;
		    MethodBase xMethod = aReader.OperandValueMethod;
			if (xMethod == null) {
				throw new Exception("Unable to determine Method!");
			}
			MethodBase xMethodDef = xMethod;
			mMethodDescription = CPU.Label.GenerateLabelName(xMethodDef);
			mTargetMethodInfo = Engine.GetMethodInfo(xMethodDef, xMethodDef, mMethodDescription, null, aMethodInfo.DebugMode);
			if (xMethodDef.IsStatic || !xMethodDef.IsVirtual || xMethod.IsFinal) {
				Engine.QueueMethod(xMethodDef);
				mNormalAddress = CPU.Label.GenerateLabelName(xMethodDef);
			}
			mMethodIdentifier = Engine.GetMethodIdentifier(xMethodDef);
			Engine.QueueMethod(VTablesImplRefs.GetMethodAddressForTypeRef);
			mArgumentCount = mTargetMethodInfo.Arguments.Length;
			mReturnSize = mTargetMethodInfo.ReturnSize;
			mThisOffset = mTargetMethodInfo.Arguments[0].Offset;
            if (mTargetMethodInfo.ExtraStackSize > 0) { mThisOffset -= mTargetMethodInfo.ExtraStackSize; }
			mCurrentILOffset = aReader.Position;
            mExtraStackSpace = mTargetMethodInfo.ExtraStackSize;

		}

		public override void DoAssemble() {
			Action xEmitCleanup = delegate() {
				foreach (MethodInformation.Argument xArg in mTargetMethodInfo.Arguments) {
					new CPUx86.Add("esp", xArg.Size.ToString());
				}
			};
			if (!String.IsNullOrEmpty(mNormalAddress)) {
				EmitCompareWithNull(Assembler, mCurrentMethodInfo, "[esp + 0x" + mThisOffset.ToString("X") + "]", mLabelName, mLabelName + "_AfterNullRefCheck", xEmitCleanup, mCurrentILOffset);
				new CPU.Label(mLabelName + "_AfterNullRefCheck");
                if(mExtraStackSpace>0) {
                    new CPUx86.Sub("esp",
                                   mExtraStackSpace.ToString());
                }
			    new CPUx86.Call(mNormalAddress);
			} else {
				if (Assembler.InMetalMode) {
					throw new Exception("Virtual methods not supported in Metal mode! (Called method = '" + mMethodDescription + "')");
				}
				//Assembler.Add(new CPUx86.Pop("eax"));
				//Assembler.Add(new CPUx86.Pushd("eax"));
				EmitCompareWithNull(Assembler, mCurrentMethodInfo, "[esp + 0x" + mThisOffset.ToString("X") + "]", mLabelName, mLabelName + "_AfterNullRefCheck", xEmitCleanup, mCurrentILOffset);
				new CPU.Label(mLabelName + "_AfterNullRefCheck");
				new CPUx86.Move(CPUx86.Registers.EAX, "[esp + 0x" + mThisOffset.ToString("X") + "]");
				new CPUx86.Pushd(CPUx86.Registers.AtEAX);
				new CPUx86.Pushd("0" + mMethodIdentifier.ToString("X") + "h");
				new CPUx86.Call(CPU.Label.GenerateLabelName(VTablesImplRefs.GetMethodAddressForTypeRef));
                new CPUx86.Pop("eax"); // boxing fix
				Call.EmitExceptionLogic(Assembler, mCurrentILOffset, mCurrentMethodInfo, mLabelName + "_AfterAddressCheck", true, xEmitCleanup);
				new CPU.Label(mLabelName + "_AfterAddressCheck");
				if (mTargetMethodInfo.Arguments[0].ArgumentType == typeof(object)) {
					new CPUx86.Push("eax");
					new CPUx86.Move("eax", "[esp + " + (mThisOffset + 4) + "]");
					new CPUx86.Compare("dword [eax + 4]", ((int)InstanceTypeEnum.BoxedValueType).ToString());
					new CPUx86.Pop("eax");
					new CPUx86.JumpIfNotEqual(mLabelName + "_NOT_BOXED_THIS");
					new CPUx86.Push("eax");
					new CPUx86.Move("eax", "[esp + " + (mThisOffset + 4) + "]");
					new CPUx86.Add("eax", ObjectImpl.FieldDataOffset.ToString());
                    // TODO: add support for automatic unboxing of values of >4bytes
				    new CPUx86.Move("eax",
				                    "[eax]");
				    new CPUx86.Move("[esp + " + mThisOffset + "]",
				                    "eax");
                    //new CPUx86.Pushd("[eax]");
                    //for (int i = mThisOffset; i > 0; i -= 4) {
                    //    new CPUx86.Pushd("[esp + " + mThisOffset + "]");
                    //}
                    //new CPUx86.Move("eax", "esp");
                    //new CPUx86.Add("eax", (mThisOffset).ToString());
                    //new CPUx86.Pushd(CPUx86.Registers.EAX);
                    //new CPUx86.Move("eax", "[esp + " + (mThisOffset + 8) + "]");
                    //if (mExtraStackSpace > 0)
                    //{
                    //    new CPUx86.Sub("esp",
                    //                   mExtraStackSpace.ToString());
                    //}
                    //new CPUx86.Call(CPUx86.Registers.EAX);
                    //// todo: fix this.
                    //// MtW: Dutch: CallVirt kopieert de arguments, dus nu moeten we de result terug kopieren
                    //if (mReturnSize > 0) {
                    //    throw new NotImplementedException("TODO"); }
                    //new CPUx86.Add("esp", "8");
                    //for (int i = mThisOffset; i >= 0; i -= 4) {
                    //    new CPUx86.Add("esp", "4");
                    //}
					new CPUx86.Jump(mLabelName + "__AFTER_NOT_BOXED_THIS");
				}
				new CPU.Label(mLabelName + "_NOT_BOXED_THIS");
			    new CPUx86.Pop("eax");
                if (mExtraStackSpace > 0)
                {
                    new CPUx86.Sub("esp",
                                   mExtraStackSpace.ToString());
                }
				new CPUx86.Call("eax");
				new CPU.Label(mLabelName + "__AFTER_NOT_BOXED_THIS");
			}
			if (!Assembler.InMetalMode) {
				new CPUx86.Test(CPUx86.Registers.ECX, 2);
				new CPUx86.JumpIfNotEqual(MethodFooterOp.EndOfMethodLabelNameException);
			}
			new CPU.Comment("Argument Count = " + mArgumentCount.ToString());
			for (int i = 0; i < mArgumentCount; i++) {
				Assembler.StackContents.Pop();
			}
            Assembler.StackContents.Push(new StackContent(mReturnSize));
		}
	}
}