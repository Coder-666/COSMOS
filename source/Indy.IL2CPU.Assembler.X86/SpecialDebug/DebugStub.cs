﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.IL2CPU.Debug;

//TODO: The asm code here is not efficient. Our first priority is to make it functionally robust and working
// We will later optimize this
namespace Indy.IL2CPU.Assembler.X86 {
    public class DebugStub : X.Y86 {
        protected UInt16 mComAddr;
        protected UInt16 mComStatusAddr;
        protected enum Tracing { Off = 0, On = 1 };
        // Current status of OS Debug Stub
        public enum Status { Run = 0, Break = 1, Stepping = 2 }

        protected void Commands() {
            Label = "DebugStub_TraceOff";
            Memory["DebugTraceMode", 32] = (int)Tracing.Off;
            Return();

            Label = "DebugStub_TraceOn";
            Memory["DebugTraceMode", 32] = (int)Tracing.On;
            Return();

            Label = "DebugStub_Continue";
            Memory["DebugStatus", 32] = (int)Status.Run;
            Return();

            Label = "DebugStub_Step";
            Memory["DebugStatus", 32] = (int)Status.Stepping;
            Return();
        }

        protected void Break() {
            Label = "DebugStub_Break";
            Memory["DebugStatus", 32] = (int)Status.Break;
            Call("DebugStub_SendTrace");

            DX = mComStatusAddr;
            Label = "DebugStub_WaitCmd";
            AL = Port[DX];
            AL.Test(0x01);
            JumpIf(Flags.Zero, "DebugStub_WaitCmd");

            DX = mComAddr;
            AL = Port[DX];

            //TODO: AL could also change... need to jump and not compare further
            AL.Compare((byte)Command.TraceOff);
                CallIf(Flags.Equal, "DebugStub_TraceOff", "DebugStub_WaitCmd");
            AL.Compare((byte)Command.TraceOn);
                CallIf(Flags.Equal, "DebugStub_TraceOn", "DebugStub_WaitCmd");
            AL.Compare((byte)Command.Break);
                // Break command is also the continue command
                CallIf(Flags.Equal, "DebugStub_Continue", "DebugStub_Break_Exit");
            AL.Compare((byte)Command.Step);
                CallIf(Flags.Equal, "DebugStub_Step", "DebugStub_Break_Exit");

            Label = "DebugStub_Break_Exit";
            Return();
        }

        // Modifies: EAX
        protected void SendTrace() {
            Label = "DebugStub_SendTrace";

            Memory["DebugTraceSent", 32].Compare(1);
            JumpIf(Flags.Equal, "DebugStub_SendTrace_Exit");
                Memory["DebugTraceSent", 32] = 1;

                // Write the type
                //TODO: Add extension methods so we can do int.Push, byte.Push, etc
                AL = (int)MsgType.TracePoint;
                EAX.Push();
                Call("WriteByteToComPort");
                // Send EIP
                AL = Memory[EBP + 3];
                EAX.Push();
                Call("WriteByteToComPort");
                AL = Memory[EBP + 2];
                EAX.Push();
                Call("WriteByteToComPort");
                AL = Memory[EBP + 1];
                EAX.Push();
                Call("WriteByteToComPort");
                AL = Memory[EBP];
                EAX.Push();
                Call("WriteByteToComPort");
            Label = "DebugStub_SendTrace_Exit";
            Return();
        }

        // Modifies EAX, ECX, EDX, ESI
        protected void SendText() {
            Label = "DebugStub_SendText";

            // Write the type
            AL = (int)MsgType.Text;
            EAX.Push();
            Call("WriteByteToComPort");
            
            // Write Length
            EAX = Memory[EBP + 12];
            ECX = EAX; // Store in counter for later
            EAX.Push();
            Call("WriteByteToComPort");
        
            //Need to find out which of these causes an error, watch output and trap errors
            // Address of string
            //new X86.Move("EAX", "[EBP + 8]");
            // Dereference pointer
            //new X86.Move("ESI", "[EAX]");
            Label = "DebugStub_SendTextWriteChar";
            ECX.Compare(0);
                JumpIf(Flags.Equal, "DebugStub_SendTextExit");
            //new X86.Move("AL", "[ESI]");
            AL = 0xFF;
            EAX.Push();
            //TODO: Change WriteByteToComPort to take an address to write to in a register
            Call("WriteByteToComPort");
            new X86.Dec("ECX");
            new X86.Inc("ESI");
            Jump("DebugStub_SendTextWriteChar");
   
            Label = "DebugStub_SendTextExit";
            Return();
        }

        // Modifies: EAX, EDX
        protected void WriteByteToComPort() {
            // This sucks to use the stack, but x86 can only read and write ports from AL and
            // we need to read a port before we can write out the value to another port.
            // The overhead is a lot, but compared to the speed of the serial and the fact
            // that we wait on the serial port anyways, its a wash.
            Label = "WriteByteToComPort";
            Label = "WriteByteToComPort_Wait";
            DX = mComStatusAddr;
            AL = Port[DX];
            AL.Test(0x20);
                JumpIf(Flags.Zero, "WriteByteToComPort_Wait");
            DX = mComAddr;
            AL = Memory[ESP + 4];
            Port[DX] = AL;
            Return(4);
        }

        protected void DebugSuspend() {
            Label = "DebugPoint_DebugSuspend";
            Memory["DebugSuspendLevel", 32]++;
            Return();
        }

        protected void DebugResume() {
            Label = "DebugPoint_DebugResume";
            Memory["DebugSuspendLevel", 32]--;
            Return();
        }

        protected void Emit() {
            Commands();
            Executing();
            SendTrace();
            SendText();
            WriteByteToComPort();
            DebugSuspend();
            DebugResume();
            Break();
        }

        protected void Executing() {
            Label = "DebugStub_Executing";
            //TODO: Change this to support CallIf(AL == 1, "DebugStub_SendTrace");
            Memory["DebugTraceMode", 32].Compare((int)Tracing.On);
                CallIf(Flags.Equal, "DebugStub_SendTrace");

            // Is there a new incoming command?
            Label = "DebugStub_Executing_Normal";
            DX = mComStatusAddr;
            AL = Port[DX];
            AL.Test(0x01);
            JumpIf(Flags.Zero, "DebugStub_Executing_Exit");

            // Process command
            DX = mComAddr;
            AL = Port[DX];
            AL.Compare((byte)Command.TraceOff);
                JumpIf(Flags.Equal, "DebugStub_TraceOff");
            AL.Compare((byte)Command.TraceOn);
                JumpIf(Flags.Equal, "DebugStub_TraceOn");
            AL.Compare((byte)Command.Break);
                JumpIf(Flags.Equal, "DebugStub_Break");

            Label = "DebugStub_Executing_Exit";
            Return();
        }

        public void Main(UInt16 aComAddr) {
            mComAddr = aComAddr;
            mComStatusAddr = (UInt16)(aComAddr + 5);
            Emit();
            // For System..Break
            //  public class BreakAssembler: AssemblerMethod

            Label = "DebugPoint__";

            // If debug stub is in break, and then an IRQ happens, the IRQ
            // can call debug stub again. This causes two debug stubs to 
            // run which causes havoc. So we only allow one to run.
            // We arent multi threaded yet, so this works fine.
            // IRQ's are disabled between Compare and JumpIf so an IRQ cant
            // happen in between them which could then cause double entry again
            DisableInterrupts();

            Memory["DebugSuspendLevel", 32].Compare(0);
            JumpIf(Flags.Equal, "DebugStub_Running");
                Memory["InterruptsEnabledFlag", 32].Compare(0);
                JumpIf(Flags.Equal, "DebugStub_Return");
                EnableInterrupts();
                Jump("DebugStub_Return");

            Label = "DebugStub_Running";
            Memory["DebugRunning", 32].Compare(0);
            JumpIf(Flags.Equal, "DebugStub_Start");
                Memory["InterruptsEnabledFlag", 32].Compare(0);
                JumpIf(Flags.Equal, "DebugStub_Return");
                EnableInterrupts();
                Jump("DebugStub_Return");

            Label = "DebugStub_Start";
            Memory["DebugRunning", 32] = 1;
            Memory["InterruptsEnabledFlag", 32].Compare(0);
            JumpIf(Flags.Equal, "DebugStub_NoSTI");
            EnableInterrupts();
            Label = "DebugStub_NoSTI";
            //
            PushAll32();
            EBP = ESP;
            EBP.Add(32);
            //
            EAX = Memory[EBP];
            Memory["DebugEIP"] = EAX;
            //
            Memory["DebugTraceSent", 32] = 0;

            //if tracemode = 4
            //   SendTrace
            //   Wait for some command that continues
            //else
            Call("DebugStub_Executing");
            
            PopAll32();
            Memory["DebugRunning", 32] = 0;
            Label = "DebugStub_Return";
            Return();
        }
    }
}
