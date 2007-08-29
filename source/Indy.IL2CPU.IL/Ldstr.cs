﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil.Cil;

namespace Indy.IL2CPU.IL {
	[OpCode(Code.Ldstr)]
	public class Ldstr: Op {
		public override void Process(Instruction aInstruction)
		{
			// Operand contains the string to be loaded
			Console.WriteLine("LdStr, string = '{0}'", aInstruction.Operand);
		}
	}
}