﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Build.Windows;
using Cosmos.Hardware;

namespace Cosmos.Shell.Console {
	public class MyClass {
		public MyClass(int aParam1, int aParam2) {
			System.Console.WriteLine("MyClass..ctor");
		}
	}
	public class Program {

        #region Build Console
        // This contains code to launch the build console. Most users should not chagne this.
        [STAThread]
        public static void Main() {
			var xBuilder = new Builder();
			xBuilder.Build();
        }
        #endregion

        // Here is where your Cosmos code goes. This is the code that will be executed during Cosmos boot.
        // Write your code, and run. Cosmos build console will appear, select your target, and thats it!
        public static void Init() {
			try {
				Cosmos.Kernel.Boot.Default();
				System.Console.WriteLine("Creating StageQueue");
				Kernel.Staging.DefaultStageQueue stages = new Cosmos.Kernel.Staging.DefaultStageQueue();
				System.Console.WriteLine("Queueing Prompter");
				stages.Enqueue(new Prompter());
				System.Console.WriteLine("Done");

				stages.Run();
				stages.Teardown();
			} catch (Exception E) {
				System.Console.WriteLine("Error occurred:");
				System.Console.Write("    ");
				System.Console.WriteLine(E.Message);
			}

			System.Console.WriteLine("Halting system now..");
			
			// Halt system.
			while (true)
				;
		}


		private static void WriteNumber(uint aValue, byte aBitCount) {
			uint xValue = aValue;
			byte xCurrentBits = aBitCount;
			System.Console.Write("0x");
			while (xCurrentBits >= 4) {
				xCurrentBits -= 4;
				byte xCurrentDigit = (byte)((xValue >> xCurrentBits) & 0xF);
				string xDigitString = null;
				switch (xCurrentDigit) {
					case 0:
						xDigitString = "0";
						goto default;
					case 1:
						xDigitString = "1";
						goto default;
					case 2:
						xDigitString = "2";
						goto default;
					case 3:
						xDigitString = "3";
						goto default;
					case 4:
						xDigitString = "4";
						goto default;
					case 5:
						xDigitString = "5";
						goto default;
					case 6:
						xDigitString = "6";
						goto default;
					case 7:
						xDigitString = "7";
						goto default;
					case 8:
						xDigitString = "8";
						goto default;
					case 9:
						xDigitString = "9";
						goto default;
					case 10:
						xDigitString = "A";
						goto default;
					case 11:
						xDigitString = "B";
						goto default;
					case 12:
						xDigitString = "C";
						goto default;
					case 13:
						xDigitString = "D";
						goto default;
					case 14:
						xDigitString = "E";
						goto default;
					case 15:
						xDigitString = "F";
						goto default;
					default:
						System.Console.Write(xDigitString);
						break;
				}
			}
		}
	}
}