using System;

namespace Cosmos.IL2CPU.X86.IL {
  [Cosmos.IL2CPU.OpCode(ILOpCode.Code.Conv_Ovf_I4)]
  public class Conv_Ovf_I4 : ILOp {
    public Conv_Ovf_I4(Cosmos.IL2CPU.Assembler aAsmblr)
      : base(aAsmblr) {
    }

    public override void Execute(MethodInfo aMethod, ILOpCode aOpCode) {
      throw new NotImplementedException();
    }

  }
}
