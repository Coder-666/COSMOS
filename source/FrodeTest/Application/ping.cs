﻿using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Sys.Network;
using Cosmos.Hardware.Network.Devices.RTL8139;
using System.Net;
using Cosmos.Hardware;

namespace FrodeTest.Application
{
    public class ping : IConsoleApplication
    {
        public int Execute(string[] args)
        {
            //Parse args into a host/ip
            //System.Net.IPAddress xDestinationIP = IPAddress.Parse("172.28.5.10");
            uint xDestinationIP = 999; //TODO

            //Get my own IP
            uint xSourceIP = 1; //TODO

            //Send ICMP Ping Request packet towards that host
            var xNic = Cosmos.Hardware.Network.NetworkDevice.NetworkDevices[0];
            xNic.Enable();

            byte[] xPingData = {(byte)'a', (byte)'b', (byte)'c', (byte)'d', (byte)'e', (byte)'f'};
            var xPingOut = new ICMPPacket(xSourceIP, xDestinationIP, ICMPPacket.ICMPType.EchoRequest, xPingData, 0);

            if (xNic.QueueBytes(xPingOut.GetData()))
            {
                DebugUtil.SendMessage("ping.cs", "Leaving Execute");
                return 0;
            }
            else
            {
                DebugUtil.SendMessage("ping.cs", "Leaving Execute");
                return -1;
            }
            
            //Wait for response back
        }

        public string CommandName
        {
            get { return "ping"; }
        }

        public string Description
        {
            get { return "Pings a destination with ICMP"; }
        }
    }
}
