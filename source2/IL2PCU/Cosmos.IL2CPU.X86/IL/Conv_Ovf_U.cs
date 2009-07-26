using System;

namespace Cosmos.IL2CPU.X86.IL
{
	[Cosmos.IL2CPU.OpCode(ILOpCode.Code.Conv_Ovf_U)]
	public class Conv_Ovf_U: ILOp
	{
		public Conv_Ovf_U(ILOpCode aOpCode):base(aOpCode)
		{
		}

    public override void Execute(uint aMethodUID) {
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
		// 	[OpCode(OpCodeEnum.Conv_Ovf_U)]
		// 	public class Conv_Ovf_U: Op {
		//         private string mNextLabel;
		// 	    private string mCurLabel;
		// 	    private uint mCurOffset;
		// 	    private MethodInformation mMethodInformation;
		// 		public Conv_Ovf_U(ILReader aReader, MethodInformation aMethodInfo)
		// 			: base(aReader, aMethodInfo) {
		//              mMethodInformation = aMethodInfo;
		// 		    mCurOffset = aReader.Position;
		// 		    mCurLabel = IL.Op.GetInstructionLabel(aReader);
		//             mNextLabel = IL.Op.GetInstructionLabel(aReader.NextPosition);
		// 		}
		// 		public override void DoAssemble() {
		//             EmitNotImplementedException(Assembler, GetServiceProvider(), "Conv_Ovf_U: This has not been implemented at all yet!", mCurLabel, mMethodInformation, mCurOffset, mNextLabel);
		//         }
		// 	}
		// }
		#endregion Old code
	}
}
