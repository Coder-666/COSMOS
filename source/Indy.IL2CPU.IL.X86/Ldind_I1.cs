using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CPU = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(Code.Ldind_I1)]
	public class Ldind_I1: Op {
		public Ldind_I1(Mono.Cecil.Cil.Instruction aInstruction, MethodInformation aMethodInfo)
			: base(aInstruction, aMethodInfo) {
		}
		public override void DoAssemble() {
			Pop("ecx");
			Move(Assembler, "eax", "0");
			Move(Assembler, "al", "[ecx]");
			Push(Assembler, 1, "eax");
		}
	}
}