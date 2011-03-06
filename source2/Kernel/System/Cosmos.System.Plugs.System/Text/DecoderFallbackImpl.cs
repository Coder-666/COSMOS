﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.IL2CPU.Plugs;

namespace Cosmos.System.Plugs.System.Text {
  [Plug(Target = typeof(DecoderFallback))]
  public static class DecoderFallbackImpl {
    // See note in EncoderFallbackImpl
    public static object get_InternalSyncObject() {
      return new object();
    }
  }
}
