using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CPU = Indy.IL2CPU.Assembler;
using CPUx86 = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(Code.Castclass, false)]
	public class Castclass: Op {
		private int mTypeId;
		private string mThisLabel;
		private string mNextOpLabel;
		public Castclass(Mono.Cecil.Cil.Instruction aInstruction, MethodInformation aMethodInfo)
			: base(aInstruction, aMethodInfo) {
			TypeReference xType = aInstruction.Operand as TypeReference;
			if (xType == null) {
				throw new Exception("Unable to determine Type!");
			}
			TypeDefinition xTypeDef = Engine.GetDefinitionFromTypeReference(xType);
			mTypeId = Engine.RegisterType(xTypeDef);
			mThisLabel = GetInstructionLabel(aInstruction);
			mNextOpLabel = GetInstructionLabel(aInstruction.Next);
		}

		public override void DoAssemble() {
			// todo: throw an exception when the class does not support the cast!
			string mReturnNullLabel = mThisLabel + "_ReturnNull";
			new CPUx86.Pop("ecx");
			Assembler.StackSizes.Pop();
			new CPUx86.Compare("ecx", "0");
			new CPUx86.JumpIfZero(mReturnNullLabel);
			new CPUx86.Pushd("[ecx]");
			Assembler.StackSizes.Push(4);
			new CPUx86.Pushd("0" + mTypeId + "h");
			Assembler.StackSizes.Push(4);
			MethodDefinition xMethodIsInstance = Engine.GetMethodDefinition(Engine.GetTypeDefinition("", "Indy.IL2CPU.VTablesImpl"), "IsInstance", "System.Int32", "System.Int32");
			Engine.QueueMethod(xMethodIsInstance);
			Op xOp = new Call(xMethodIsInstance);
			xOp.Assembler = Assembler;
			xOp.Assemble();
			new CPUx86.Pop("eax");
			Assembler.StackSizes.Pop();
			new CPUx86.Compare("eax", "0");
			new CPUx86.JumpIfEquals(mReturnNullLabel);
			new CPUx86.Pushd("ecx");
			new CPUx86.JumpAlways(mNextOpLabel);
			new CPU.Label(mReturnNullLabel);
			new CPUx86.Pushd("0");
			Assembler.StackSizes.Push(4);
		}
	}
}