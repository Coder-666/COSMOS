﻿using System;
using System.Collections.Generic;
using System.Text;
using Indy.IL2CPU.Plugs;

namespace Cosmos.Kernel.Plugs {
	[Plug(Target=typeof(System.Type))]
	public static class TypeImpl {
		[PlugMethod(Signature="System_Void__System_Type__cctor__")]
		public static void CCtor() {
		}

        //[PlugMethod(Signature = "System_Type__System_Type_GetTypeFromHandle_System_RuntimeTypeHandle_")]
        public static Type GetTypeFromHandle(RuntimeTypeHandle aHandle) {
            return null;
        }

        public static string ToString(Type aThis) {
          return "<type>";
        }

	    //System.Type  System.Type.GetTypeFromHandle(System.RuntimeTypeHandle)
	}
}