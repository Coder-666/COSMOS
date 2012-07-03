﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace Cosmos.Debug.VSDebugEngine.Host {
  public abstract class Base {
    protected NameValueCollection mParams;
    protected bool mUseGDB;

    public Base(NameValueCollection aParams, bool aUseGDB) {
      mParams = aParams;
      mUseGDB = aUseGDB;
    }

    public abstract string StartOld();
    public abstract void Start();
    public abstract void Stop();
    public abstract string GetHostProcessExe();
  }
}
