﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Diagnostics;
using Cosmos.Sys.Network;
using Cosmos.Hardware;
using Cosmos.Hardware.Network;
using Cosmos.Kernel;

namespace MatthijsTest
{
    public class Program
    {
        #region Cosmos Builder logic
        // Most users wont touch this. This will call the Cosmos Build tool
        [STAThread]
        static void Main(string[] args)
        {
            Cosmos.Compiler.Builder.BuildUI.Run();
        }
        #endregion

        private static NetworkDevice mNet;

        public static unsafe void Init()
        {

            var xInit = false;
            if (xInit)
            {
                var xBoot = new Cosmos.Sys.Boot();
                xBoot.Execute(true);
            }

            int xValue = 43;
            Console.Write("Value = ");
            Console.WriteLine((object)xValue);
            Console.Write("Value2 = ");
            Console.WriteLine(xValue.ToString());
            Console.Write("Value2 = ");
            Console.WriteLine(xValue);

            //ulong a = 1;
            //ulong b = 2;
            //var c = a + b;
            //Interrupts.WriteNumber((uint)c, 32);
            //Console.WriteLine("");

            //MyATAController.Scan();
            //MyATADevice xDevice = null;
            //for (int i = 0; i < Device.Devices.Count; i++)
            //{
            //    if (Device.Devices[i] is MyATADevice)
            //    {
            //        xDevice = (MyATADevice)Device.Devices[i];
            //        break;
            //    }
            //}
            //if (xDevice != null)
            //{
            //    Console.WriteLine("Drive found!");
            //    Console.Write("Supports LBA28: ");
            //    if (xDevice.SupportsLBA28)
            //    {
            //        Console.WriteLine("Yes");
            //    }
            //    else
            //    {
            //        Console.WriteLine("No");
            //    }
            //    Console.Write("Supported UDMA: ");
            //    Interrupts.WriteNumber(xDevice.SupportedUDMA, 8);
            //    Console.WriteLine();
            //    Console.Write("Sector count: ");
            //    Interrupts.WriteNumber((uint)xDevice.BlockCount, 32);
            //    Console.WriteLine();

            //    var xDataToSend = new byte[512];
            //    for (int i = 0; i < 512; i++)
            //    {
            //        xDataToSend[i] = (byte)(i % 256);
            //    }
            //    xDevice.WriteBlock(2, xDataToSend);

            //}
            Console.WriteLine("Done");
            while (true)
                ;
        }
    }

    public static class DebugUtil
    {
        public static void Write(string data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Write(data[i]);
            }
        }

        private static void Write(char data)
        {
            Serial.WriteSerial(0, (byte)data);
        }

        public static void WriteUIntAsHex(uint data)
        {
            Write("0x");
            var xTemp = "0123456789ABCDEF";
            Write(xTemp[((int)((data >> 28) & 0xF))]);
            Write(xTemp[((int)((data >> 24) & 0xF))]);
            Write(xTemp[((int)((data >> 20) & 0xF))]);
            Write(xTemp[((int)((data >> 16) & 0xF))]);
            Write(xTemp[((int)((data >> 12) & 0xF))]);
            Write(xTemp[((int)((data >> 8) & 0xF))]);
            Write(xTemp[((int)((data >> 4) & 0xF))]);
            Write(xTemp[((int)((data) & 0xF))]);
        }

        public static void WriteLine(string data)
        {
            Write(data);
            Write("\r\n");
        }
    }
}