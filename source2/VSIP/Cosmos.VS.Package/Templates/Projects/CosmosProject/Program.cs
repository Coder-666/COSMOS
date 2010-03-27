﻿using System;
using System.Collections.Generic;
using System.Text;

namespace $nameSpace$
{
    public class $className$
    {
	public static void Init()
	{
		Main();
	}
        static void Main()
        {
            // boot the Cosmos kernel:
            Cosmos.Sys.Boot xBoot = new Cosmos.Sys.Boot();
            xBoot.Execute();
            
            Console.WriteLine("Cosmos booted successfully. Type a line of text to get it echoed back:");
            string xResult = Console.ReadLine();
            // when Qemu shows you the above text, put a breakpoint on the next line, then type a line 
            // of text in qemu. you'll see that Visual Studio breaks on the breakpoint.
            // Note, you cannot set the breakpoints before running the project, this is a current bug
            // in Cosmos.
            Console.Write("Text typed: ");
            Console.WriteLine(xResult);
        }
    }
}
