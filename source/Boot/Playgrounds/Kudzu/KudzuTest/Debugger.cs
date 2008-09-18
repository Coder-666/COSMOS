﻿using System;
using System.Collections.Generic;
using System.Text;
using Dbg = Cosmos.Debug;

namespace Cosmos.Playground.Kudzu {
    public class Debugger {
        public static void Main() {
            //Debugger.Break();
            Dbg.Debugger.TraceOn();
            Random xRandom = new Random((int)(Cosmos.Hardware.Global.TickCount
                + Cosmos.Hardware.RTC.GetSeconds()));
            // Divide by 100, get remainder
            int xMagicNo = xRandom.Next() % 100;
            Dbg.Debugger.Send("The magic number is " + xMagicNo);
            Dbg.Debugger.Break();
            Console.WriteLine("I am thinking of a number between 0 and 100. What is it?");
            Dbg.Debugger.TraceOff();
            Console.ReadLine();
        }
    }
}
