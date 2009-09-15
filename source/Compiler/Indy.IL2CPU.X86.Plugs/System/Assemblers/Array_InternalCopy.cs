﻿using System;
using System.Linq;
using Indy.IL2CPU.Plugs;
using Assembler = Cosmos.IL2CPU.Assembler;
using CPUx86 = Cosmos.IL2CPU.X86;

using CosCPUAll = Cosmos.IL2CPU;
using CosCPUx86 = Cosmos.IL2CPU.X86;

namespace Indy.IL2CPU.X86.Plugs.CustomImplementations.System.Assemblers {
  public class Array_InternalCopy: AssemblerMethod {

    /* void Copy(Array sourceArray,			ebp + 0x1C
     *			 int sourceIndex,			ebp + 0x18
     *			 Array destinationArray,	ebp + 0x14
     *			 int destinationIndex,		ebp + 0x10
     *			 int length,				ebp + 0xC
     *			 bool reliable);			ebp + 0x8
     */
    public override void Assemble(Indy.IL2CPU.Assembler.Assembler aAssembler) {
      new CPUx86.Push { DestinationReg = CPUx86.Registers.EBP, DestinationIsIndirect = true, DestinationDisplacement = 0x1C };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.ESP, DestinationIsIndirect = true, SourceValue = 12, Size = 32 }; // pointer is at the element size
      new CPUx86.Pop { DestinationReg = CPUx86.Registers.EAX };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EAX, SourceReg = CPUx86.Registers.EAX, SourceIsIndirect = true }; // element size
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EBX, SourceReg = CPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x18 };
      new CPUx86.Multiply { DestinationReg = CPUx86.Registers.EBX };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.EAX, SourceValue = 16 };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.ESI, SourceReg = CPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x1C };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.ESI, SourceReg = CPUx86.Registers.EAX }; // source ptr
      new CPUx86.Push { DestinationReg = CPUx86.Registers.EBP, DestinationIsIndirect = true, DestinationDisplacement = 0x14 };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.ESP, DestinationIsIndirect = true, SourceValue = 12, Size = 32 }; // pointer is at element size
      new CPUx86.Pop { DestinationReg = CPUx86.Registers.EAX };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EAX, SourceReg = CPUx86.Registers.EAX, SourceIsIndirect = true };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.ECX, SourceReg = CPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x10 };
      new CPUx86.Multiply { DestinationReg = CPUx86.Registers.ECX };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.EAX, SourceValue = 16 };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EDI, SourceReg = CPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x14 };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.EDI, SourceReg = CPUx86.Registers.EAX };

      // calculate byte count to copy
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EAX, SourceReg = CPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x14 };
      new CPUx86.Add { DestinationReg = CPUx86.Registers.EAX, SourceValue = 12 };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EAX, SourceReg = CPUx86.Registers.EAX, SourceIsIndirect = true };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.EDX, SourceReg = CPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0xC };
      new CPUx86.Multiply { DestinationReg = CPUx86.Registers.EDX };
      new CPUx86.Move { DestinationReg = CPUx86.Registers.ECX, SourceReg = CPUx86.Registers.EAX, };
      new CPUx86.Movs { Size = 8, Prefixes = CPUx86.InstructionPrefixes.Repeat };
    }

    public override void AssembleNew(object aAssembler, object aMethodInfo) {
      new CosCPUx86.Push { DestinationReg = CosCPUx86.Registers.EBP, DestinationIsIndirect = true, DestinationDisplacement = 0x1C };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.ESP, DestinationIsIndirect = true, SourceValue = 12, Size = 32 }; // pointer is at the element size
      new CosCPUx86.Pop { DestinationReg = CosCPUx86.Registers.EAX };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EAX, SourceReg = CosCPUx86.Registers.EAX, SourceIsIndirect = true }; // element size
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EBX, SourceReg = CosCPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x18 };
      new CosCPUx86.Multiply { DestinationReg = CosCPUx86.Registers.EBX };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.EAX, SourceValue = 16 };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.ESI, SourceReg = CosCPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x1C };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.ESI, SourceReg = CosCPUx86.Registers.EAX }; // source ptr
      new CosCPUx86.Push { DestinationReg = CosCPUx86.Registers.EBP, DestinationIsIndirect = true, DestinationDisplacement = 0x14 };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.ESP, DestinationIsIndirect = true, SourceValue = 12, Size = 32 }; // pointer is at element size
      new CosCPUx86.Pop { DestinationReg = CosCPUx86.Registers.EAX };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EAX, SourceReg = CosCPUx86.Registers.EAX, SourceIsIndirect = true };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.ECX, SourceReg = CosCPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x10 };
      new CosCPUx86.Multiply { DestinationReg = CosCPUx86.Registers.ECX };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.EAX, SourceValue = 16 };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EDI, SourceReg = CosCPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x14 };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.EDI, SourceReg = CosCPUx86.Registers.EAX };

      // calculate byte count to copy
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EAX, SourceReg = CosCPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0x14 };
      new CosCPUx86.Add { DestinationReg = CosCPUx86.Registers.EAX, SourceValue = 12 };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EAX, SourceReg = CosCPUx86.Registers.EAX, SourceIsIndirect = true };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.EDX, SourceReg = CosCPUx86.Registers.EBP, SourceIsIndirect = true, SourceDisplacement = 0xC };
      new CosCPUx86.Multiply { DestinationReg = CosCPUx86.Registers.EDX };
      new CosCPUx86.Move { DestinationReg = CosCPUx86.Registers.ECX, SourceReg = CosCPUx86.Registers.EAX, };
      new CPUx86.Movs { Size = 8, Prefixes = CosCPUx86.InstructionPrefixes.Repeat };
    }
  }
}
