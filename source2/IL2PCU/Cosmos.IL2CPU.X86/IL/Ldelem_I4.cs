using System;

namespace Cosmos.IL2CPU.X86.IL
{
	[Cosmos.IL2CPU.OpCode(ILOpCode.Code.Ldelem_I4)]
	public class Ldelem_I4: ILOp
	{
		public Ldelem_I4(ILOpCode aOpCode):base(aOpCode)
		{
		}

    public override void Execute(uint aMethodUID) {
      throw new Exception("TODO:");
    }

    #region Old code
		// using System;
		// using System.Collections.Generic;
		// using System.IO;
		// 
		// 
		// using CPU = Indy.IL2CPU.Assembler;
		// using CPUx86 = Indy.IL2CPU.Assembler.X86;
		// 
		// namespace Indy.IL2CPU.IL.X86 {
		// 	[OpCode(OpCodeEnum.Ldelem_I4)]
		// 	public class Ldelem_I4: Op {
		// 
		//         //public static void ScanOp(ILReader aReader, MethodInformation aMethodInfo, SortedList<string, object> aMethodData)
		//         //{
		//         //    Engine.RegisterType(typeof(int));
		//         //}
		// 
		//         public Ldelem_I4(ILReader aReader, MethodInformation aMethodInfo)
		// 			: base(aReader, aMethodInfo) {
		// 		}
		// 
		// 		public override void DoAssemble() {
		// 			Ldelem_Ref.Assemble(Assembler, 4);
		// 		}
		// 	}
		// }
		#endregion Old code
	}
}
