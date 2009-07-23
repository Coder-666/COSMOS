using System;

namespace Cosmos.IL2CPU.ILOpCodes
{
	[Cosmos.IL2CPU.OpCode(ILOpCode.Code.Conv_R8)]
	public class Conv_R8: ILOpCode
	{



		#region Old code
		// using System;
		// using System.IO;
		// 
		// 
		// using CPUx86 = Indy.IL2CPU.Assembler.X86;
		// using Indy.IL2CPU.Assembler;
		// 
		// namespace Indy.IL2CPU.IL.X86 {
		// 	[Cosmos.IL2CPU.OpCode(ILOpCode.Code.Conv_R8)]
		// 	public class Conv_R8: ILOpCode {
		//         private string mNextLabel;
		// 	    private string mCurLabel;
		// 	    private uint mCurOffset;
		// 	    private MethodInformation mMethodInformation;
		// 		public Conv_R8(ILReader aReader, MethodInformation aMethodInfo)
		// 			: base(aReader, aMethodInfo) {
		//              mMethodInformation = aMethodInfo;
		// 		    mCurOffset = aReader.Position;
		// 		    mCurLabel = IL.Op.GetInstructionLabel(aReader);
		//             mNextLabel = IL.Op.GetInstructionLabel(aReader.NextPosition);
		// 		}
		// 		public override void DoAssemble() {
		// 			var xStackItem = Assembler.StackContents.Peek();
		// 			switch (xStackItem.Size) {
		// 				case 1:
		// 				case 2:
		// 				case 4: {
		//                         new CPUx86.Pop { DestinationReg = CPUx86.Registers.EAX };
		//                         new CPUx86.Push { DestinationValue = 0 };
		//                         new CPUx86.Push { DestinationReg = CPUx86.Registers.EAX };
		// 						Assembler.StackContents.Pop();
		// 						Assembler.StackContents.Push(new StackContent(8, typeof(Double)));
		// 
		// 						break;
		// 					}
		// 				case 8: {
		// 						new CPUx86.Noop();
		// 						break;
		// 					}
		// 				default:
		//                     EmitNotImplementedException(Assembler, GetServiceProvider(), "Conv_R8: SourceSize " + xStackItem.Size + " not supported!", mCurLabel, mMethodInformation, mCurOffset, mNextLabel);
		// 					throw new Exception("SourceSize " + xStackItem.Size + " not supported!");
		// 			}
		// 		}
		// 	}
		// }
		#endregion
	}
}
