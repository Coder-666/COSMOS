﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indy.IL2CPU.Assembler.X86.Native {
	[OpCode(0xFFFFFFFF, "iret")]
	public class IRet: X86.Instruction {
	}
}