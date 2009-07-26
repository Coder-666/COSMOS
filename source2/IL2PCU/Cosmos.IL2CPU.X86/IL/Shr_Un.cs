using System;

namespace Cosmos.IL2CPU.X86.IL
{
	[Cosmos.IL2CPU.OpCode(ILOpCode.Code.Shr_Un)]
	public class Shr_Un: ILOp
	{
		public Shr_Un(Cosmos.IL2CPU.Assembler aAsmblr):base(aAsmblr)
		{
		}

    public override void Execute(uint aMethodUID, ILOpCode aOpCode) {
      throw new Exception("TODO:");
    }

    #region Old code
		// using System;
		// using System.IO;
		// 
		// 
		// using CPU = Indy.IL2CPU.Assembler.X86;
		// 
		// namespace Indy.IL2CPU.IL.X86 {
		// 	[OpCode(OpCodeEnum.Shr_Un)]
		// 	public class Shr_Un: Shr {
		// 		public Shr_Un(ILReader aReader, MethodInformation aMethodInfo)
		// 			: base(aReader, aMethodInfo) {
		// 		}
		// 	}
		// }
		#endregion Old code
	}
}
