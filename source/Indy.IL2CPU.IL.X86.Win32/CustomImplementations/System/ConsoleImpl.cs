﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Indy.IL2CPU.Plugs;

namespace Indy.IL2CPU.IL.X86.Win32.CustomImplementations.System {
	[Plug(Target = typeof(Console))]
	public static class ConsoleImpl {
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		static extern unsafe bool WriteConsole(IntPtr hConsoleOutput, uint lpBuffer,
		   uint nNumberOfCharsToWrite, out uint lpNumberOfCharsWritten,
		   IntPtr lpReserved);
		[DllImport("kernel32.dll")]
		static extern IntPtr GetStdHandle(int nStdHandle);

		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr aHandle);

		private const int ConsoleOutHandle = -11;
		private static int mInitialized = 0;
		private static IntPtr mConsoleOutHandler;

		private static void DoInitialize() {
			if (mInitialized == 0) {
				mInitialized = 1;
				mConsoleOutHandler = GetStdHandle(ConsoleOutHandle);
			}
		}

		[PlugMethod]
		public static void Write(string aData) {
			DoInitialize();
			uint xCharsWritten;
			uint xCharsToWrite = (uint)aData.Length;
			WriteConsole(mConsoleOutHandler, CustomImplementation.System.StringImpl.GetStorage(aData), xCharsToWrite, out xCharsWritten, IntPtr.Zero);
		}

		[PlugMethod]
		public static void WriteLine(string aData) {
			Console.Write(aData);
			WriteLine();
		}

		[PlugMethod]
		public static void WriteLine() {
			Console.Write(Environment.NewLine);
		}
	}
}