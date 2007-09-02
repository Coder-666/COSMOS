﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indy.IL2CPU.Assembler.X86 {
	/// <summary>
	/// Represents the JZ opcode
	/// </summary>
	[OpCode(0xFFFFFFFF, "jz")]
	public class JumpIfZero: Instruction {
		public readonly string Address;
		public JumpIfZero(string aAddress) {
			Address = aAddress;
		}
		public override string ToString() {
			return "jz " + Address;
		}
	}
}