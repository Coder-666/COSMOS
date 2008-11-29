﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Indy.IL2CPU.Assembler.X86 {
    [OpCode("shl")]
	public class ShiftLeft: InstructionWithDestinationAndSourceAndSize {
        public static void InitializeEncodingData(Instruction.InstructionData aData) {
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xD2},
                NeedsModRMByte=true,
                InitialModRMByteValue = 0xE0,
                OperandSizeByte=0,
                DestinationReg=Guid.Empty,
                SourceReg=Registers.CL
            }); // register by CL
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xD2 },
                NeedsModRMByte = true,
                InitialModRMByteValue = 0x20,
                OperandSizeByte = 0,
                DestinationMemory=true,
                SourceReg = Registers.CL
            }); // memory by CL
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xC0 },
                NeedsModRMByte = true,
                InitialModRMByteValue = 0xE0,
                OperandSizeByte = 0,
                DestinationReg = Guid.Empty,
                SourceImmediate=true
            }); // register by immediate
            aData.EncodingOptions.Add(new InstructionData.InstructionEncodingOption {
                OpCode = new byte[] { 0xC0 },
                NeedsModRMByte = true,
                InitialModRMByteValue = 0x20,
                OperandSizeByte = 0,
                DestinationMemory = true,
                SourceImmediate = true
            }); // memory by immediate
        }
	}
}