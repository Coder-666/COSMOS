﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Hardware {
  static public class Global {
    static readonly public Cosmos.Debug.Kernel.Debugger Dbg = new Cosmos.Debug.Kernel.Debugger("Hardware", "");

    static public Keyboard Keyboard;
    //static public PIT PIT = new PIT();
    // Must be static init, other static inits rely on it not being null
    static public TextScreen TextScreen = new TextScreen();

    static void InitAta(BlockDevice.Ata.ControllerIdEnum aControllerID, BlockDevice.Ata.BusPositionEnum aBusPosition) {
      var xIO = aControllerID == BlockDevice.Ata.ControllerIdEnum.Primary ? Cosmos.Core.Global.BaseIOGroups.ATA1 : Cosmos.Core.Global.BaseIOGroups.ATA2;
      var xATA = new BlockDevice.AtaPio(xIO, aControllerID, aBusPosition);
      if (xATA.DriveType != BlockDevice.AtaPio.SpecLevel.Null) {
        BlockDevice.BlockDevice.Devices.Add(xATA);
      }
    }

    // Init devices that are "static"/mostly static. These are devices
    // that all PCs are expected to have. Keyboards, screens, ATA hard drives etc.
    // Despite them being static, some discovery is required. For example, to see if
    // a hard drive is connected or not and if so what type.
    static internal void InitStaticDevices() {
      //TextScreen = new TextScreen();
      TextScreen.Clear();

      Keyboard = new Keyboard();

      // Find hardcoded ATA controllers
      InitAta(BlockDevice.Ata.ControllerIdEnum.Primary, BlockDevice.Ata.BusPositionEnum.Master);
      InitAta(BlockDevice.Ata.ControllerIdEnum.Primary, BlockDevice.Ata.BusPositionEnum.Slave);
      //TODO Need to change code to detect if ATA controllers are present or not. How to do this? via PCI enum? 
      // They do show up in PCI space as well as the fixed space. 
      //InitAta(BlockDevice.Ata.ControllerIdEnum.Secondary, BlockDevice.Ata.BusPositionEnum.Master);
      //InitAta(BlockDevice.Ata.ControllerIdEnum.Secondary, BlockDevice.Ata.BusPositionEnum.Slave);
    }

    static internal void InitPciDevices() {
      //TODO Redo this - Global init should be other.
      // Move PCI detection to hardware? Or leave it in core? Is Core PC specific, or deeper?
      // If we let hardware do it, we need to protect it from being used by System.
      // Probably belongs in hardware, and core is more specific stuff like CPU, memory, etc.
      Core.PciBus.OnPCIDeviceFound = PCIDeviceFound;
      Cosmos.Core.Global.Init();
    }

    static public void Init() {
      // DANGER! This is before heap? Yet somehow its working currently...
      // Leaving it for now because Core.Init outputs to Console, but we need
      // to change this...
      // Heap seems to self init on demand? But even before IDT/GDT etc?

      InitStaticDevices();
      InitPciDevices();
    }

    static void PCIDeviceFound(Core.PciBus.PciInfo aInfo, Core.IOGroup.PciDevice aIO) {
      // Later we need to dynamically load these, but we need to finish the design first.
      if ((aInfo.VendorID == 0x8086) && (aInfo.DeviceID == 0x7111)) {
        //ATA1 = new ATA(Core.Global.BaseIOGroups.ATA1);
      }
    }

  }
}
