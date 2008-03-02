using System;
using System.Linq;
using Indy.IL2CPU.Assembler;
using CPU = Indy.IL2CPU.Assembler;
using CPUx86 = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(OpCodeEnum.Box, false)]
	public class Box: Op {
		private int mTheSize;
		private int mTypeId;

		public Box(ILReader aReader, MethodInformation aMethodInfo)
			: base(aReader, aMethodInfo) {
			Type xTypeRef = aReader.OperandValueType as Type;
			if (xTypeRef == null) {
				throw new Exception("Couldn't determine Type!");
			}
			//if (xTypeRef is GenericParameter) {
			//    // todo: implement support for generics
			//    mTheSize = 4;
			//} else {
				mTheSize = Engine.GetFieldStorageSize(xTypeRef);
			//}
			//if (((mTheSize / 4) * 4) != mTheSize) {
			//    throw new Exception("Incorrect Datasize. ( ((mTheSize / 4) * 4) === mTheSize should evaluate to true!");
			//}
			//if (!(xTypeRef is GenericParameter)) {
			mTypeId = Engine.RegisterType(xTypeRef);
			//}
		}

		public override void DoAssemble() {
			int xSize = mTheSize;
			if (mTheSize % 4 != 0) {
				xSize += 4 - (mTheSize % 4);
			}
			new CPUx86.Pushd("0x" + (ObjectImpl.FieldDataOffset + xSize).ToString("X").ToUpper());
			new CPUx86.Call(CPU.Label.GenerateLabelName(RuntimeEngineRefs.Heap_AllocNewObjectRef));
			new CPUx86.Move("dword", CPUx86.Registers.AtEAX, "0x" + mTypeId.ToString("X"));
			new CPUx86.Move("dword", "[eax + 4]", "0x" + InstanceTypeEnum.BoxedValueType.ToString("X"));
			for (int i = 0; i < (xSize / 4); i++) {
				new CPUx86.Pop(CPUx86.Registers.EDX);
				new CPUx86.Move("dword", "[eax + 0x" + (ObjectImpl.FieldDataOffset + (i * 4)).ToString("X") + "]", "edx");
			}
			Assembler.StackContents.Pop();
			new CPUx86.Pushd(CPUx86.Registers.EAX);
			Assembler.StackContents.Push(new StackContent(4, false, false, false));
		}
	}
}