﻿using System;
using System.Collections.Generic;
using System.Text;
using Indy.IL2CPU.Assembler.X86;
using Indy.IL2CPU.Plugs;
using Assembler = Indy.IL2CPU.Assembler.Assembler;
using CPUx86 = Indy.IL2CPU.Assembler.X86;
using CPUNative = Indy.IL2CPU.Assembler.X86;

namespace Cosmos.Kernel.Plugs.Assemblers {
    public sealed class IORead32 : AssemblerMethod {
        public override void Assemble(Assembler aAssembler) {
            //TODO: This is a lot of work to read a port. We need to have some kind of inline ASM option that can emit a single out instruction
            //TODO: Also make an attribute that forces normal inlining fo a method
            new CPUx86.Move(Registers.EDX, "[ebp + 0x08]");
            new CPUNative.InDWord(Registers.EAX, Registers.DX);
            new CPUx86.Push(Registers.EAX);
        }
    }
}
