using System;
using System.IO;
using Mono.Cecil;
using Mono.Cecil.Cil;
using CPU = Indy.IL2CPU.Assembler.X86;

namespace Indy.IL2CPU.IL.X86 {
	[OpCode(Code.Stfld)]
	public class Stfld: Op {
		public override void Assemble(Instruction aInstruction, MethodInformation aMethodInfo) {
			throw new NotImplementedException("This file has been autogenerated and not been changed afterwards!");
		}
	}
}