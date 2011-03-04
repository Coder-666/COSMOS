﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.Debug.Kernel;
using Cosmos.Common.Extensions;
using Cosmos.Hardware.BlockDevice;

namespace BreakpointsKernel {
  public class BreakpointsOS : Sys.Kernel {
    public BreakpointsOS() {
      ClearScreen = false;
    }

    protected override void BeforeRun() {
      Console.WriteLine("Cosmos boot complete.");
    }

    protected void TestSB() {
      var xSB = new StringBuilder();
      xSB.Append("Hello");
      xSB.Append("Hello");
      var xDisplay = xSB.ToString();
      Console.WriteLine(xDisplay.Length);
      Console.WriteLine("First char: " + xSB[0]);
      Console.WriteLine(xDisplay);
    }

    void Trace1() {
      int x = 4;
      Trace2();
      int y = 5;
      int z = 6;
    }

    void Trace2() {
      int x2 = 4;
      Trace3();
      int y2 = 5;
      int z2 = 6;
    }

    void Trace3() {
      int x3 = 4;
      int y3 = 5;
      int z3 = 6;
    }

    void TestStringCtor() {
      char[] xChars = new char[5];
      xChars[0] = 'A';
      xChars[1] = 'B';
      xChars[2] = 'C';
      xChars[3] = 'D';
      xChars[4] = 'E';
      var xString = new string(xChars, 0, 3);
      Console.WriteLine(xString);
      Console.WriteLine(xString.Length);
    }

    protected override void Run() {
      //try {
      //Trace1();
      //TestSB();
      TestStringCtor();

      Console.WriteLine("Block devices found: " + BlockDevice.Devices.Count);

      AtaPio xATA = null;
      for (int i = 0; i < BlockDevice.Devices.Count; i++) {
        var xDevice = BlockDevice.Devices[i];
        if (xDevice is AtaPio) {
          xATA = (AtaPio)xDevice;
        }
      }
      Console.WriteLine("--------------------------");
      Console.WriteLine("Type: " + (xATA.DriveType == AtaPio.SpecLevel.ATA ? "ATA" : "ATAPI"));
      Console.WriteLine("Serial No: " + xATA.SerialNo);
      Console.WriteLine("Firmware Rev: " + xATA.FirmwareRev);
      Console.WriteLine("Model No: " + xATA.ModelNo);
      Console.WriteLine("Size: " + xATA.BlockCount * xATA.BlockSize / 1024 / 1024 + " MB");

      Partition xPartition = null;
      for (int i = 0; i < BlockDevice.Devices.Count; i++) {
        var xDevice = BlockDevice.Devices[i];
        if (xDevice is Partition) {
          xPartition = (Partition)xDevice;
        }
      }
      Console.WriteLine();
      Console.WriteLine("Root directory");
      var xFS = new Cosmos.System.Filesystem.FAT.FatFileSystem(xPartition);
      var xListing = xFS.GetRoot();
      Sys.Filesystem.FAT.Listing.FatFile xRootFile = null;
      for (int i = 0; i < xListing.Count; i++) {
        var xItem = xListing[i];
        if (xItem is Sys.Filesystem.Listing.Directory) {
          Console.WriteLine("<" + xListing[i].Name + ">");
        } else if (xItem is Sys.Filesystem.Listing.File) {
          Console.WriteLine(xListing[i].Name);
          if (xListing[i].Name == "ROOT.TXT") {
            xRootFile = (Sys.Filesystem.FAT.Listing.FatFile)xListing[i];
          }
        }
      }

      //var xStream = new Sys.Filesystem.FAT.FatStream(xRootFile);
      

      //var xWrite = new byte[512];
      //for (int i = 0; i < 512; i++) {
      //  xWrite[i] = (byte)i;
      //}
      //xATA.WriteBlock(0, xWrite);

      //var xRead = xATA.NewBlockArray(1);
      //xATA.ReadBlock(0, 1, xRead);
      //string xDisplay = "";
      //for (int i = 0; i < 512; i++) {
      //  xDisplay = xDisplay + xRead[i].ToHex();
      //}
      //Console.WriteLine(xDisplay);
      Stop();
      //} catch (Exception e) {
      //  Console.WriteLine("Exception: " + e.Message);
      //  Stop();
      //}
    }

    protected override void AfterRun() {
      Console.Write("Done");
      Console.ReadLine();
    }
  }
}
