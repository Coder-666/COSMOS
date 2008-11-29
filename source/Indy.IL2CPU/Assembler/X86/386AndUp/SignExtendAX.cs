﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indy.IL2CPU.Assembler.X86
{
    [OpCode("cdq")]
	public class SignExtendAX : InstructionWithSize
	{
		public override string ToString()
		{
			switch (Size)
			{
			case 4:
				return "cdq";
			case 2:
				return "cwd";
			default:
				throw new NotSupportedException();
			}
		}
	}
}