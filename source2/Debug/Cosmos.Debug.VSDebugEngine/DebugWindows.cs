﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cosmos.Debug.VSDebugEngine {

  static public class DebugWindows {
    static Cosmos.Debug.Common.PipeClient mPipe;

    static public void SendCommand(byte aCmd, byte[] aData) {
      if (mPipe == null) {
        mPipe = new Cosmos.Debug.Common.PipeClient(Cosmos.Debug.Consts.Pipes.DownName);
      }
      mPipe.SendCommand(aCmd, aData);
    }

  }

}
