using System;
using CPUx86 = Cosmos.Assembler.x86;

namespace Cosmos.IL2CPU.X86.IL
{
    [Cosmos.IL2CPU.OpCode( ILOpCode.Code.Ldind_U2 )]
    public class Ldind_U2 : ILOp
    {
        public Ldind_U2( Cosmos.Assembler.Assembler aAsmblr )
            : base( aAsmblr )
        {
        }

        public override void Execute( MethodInfo aMethod, ILOpCode aOpCode )
        {
			Assembler.Stack.Pop();
			new CPUx86.Pop { DestinationReg = CPUx86.Registers.ECX };
			new CPUx86.MoveZeroExtend { DestinationReg = CPUx86.Registers.EAX, Size = 16, SourceReg = CPUx86.Registers.ECX, SourceIsIndirect = true };
			new CPUx86.Push { DestinationReg = CPUx86.Registers.EAX };
			Assembler.Stack.Push(ILOp.Align(2, 4), typeof(int));
        }
    }
}