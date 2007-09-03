using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CPU = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(Code.Ldelem_U1)]
	public class Ldelem_U1: Op {
		public Ldelem_U1(Mono.Cecil.Cil.Instruction aInstruction, MethodInformation aMethodInfo)
			: base(aInstruction, aMethodInfo) {
		}
		public override void Assemble() {
			throw new NotImplementedException("This file has been autogenerated and not been changed afterwards!");
		}
	}
}