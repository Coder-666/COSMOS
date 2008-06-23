﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmos.Sys.Network {
    // http://en.wikipedia.org/wiki/User_Datagram_Protocol
    public class UDPPacket : IP4Packet {
        public UDPPacket(uint aSrcIP, UInt16 aSrcPort, uint aDestIP, UInt16 aDestPort, byte[] aData) {
            mHeaderBegin = Initialize(aData, 8, 0x11, aSrcIP, aDestIP);
            // Source Port
            mData[mHeaderBegin] = (byte)(aSrcPort >> 8);
            mData[mHeaderBegin + 1] = (byte)aSrcPort;
            // Destination Port
            mData[mHeaderBegin + 2] = (byte)(aDestPort >> 8);
            mData[mHeaderBegin + 3] = (byte)aDestPort;
            // Length
            int xSize = mData.Length - mHeaderBegin;
            mData[mHeaderBegin + 4] = (byte)(xSize >> 8);
            mData[mHeaderBegin + 5] = (byte)xSize;
        }

        protected new int mHeaderBegin;

        protected override void Conclude() {
            base.Conclude();
            mData[mHeaderBegin + 6] = 0;
            mData[mHeaderBegin + 7] = 0;

            // This needs to be updated. 0 is valid for no checksum, but this also 
            // is correct once updated
            // All offsets are -34 now
            //mData[40] = 0;
            //mData[41] = 0;

            //// TODO: Change this to a ASM and use 32 bit addition
            //UInt32 xResult = 0;
            //// TODO: Adjust for length and odd sizes
            //for (int i = 34; i < 42; i = i + 2) {
            //    xResult += (UInt16)((mData[i] << 8) + mData[i + 1]);
            //}
            //// Data
            //xResult += (UInt16)((mData[42] << 8) + 0);
            //// Pseudo header
            //// --Protocol
            //// TODO: Change to actually iterate data
            //xResult += (UInt16)(mData[23]);
            //// --IP Source
            //xResult += (UInt16)((mData[26] << 8) + mData[27]);
            //xResult += (UInt16)((mData[28] << 8) + mData[29]);
            //// --IP Dest
            //xResult += (UInt16)((mData[30] << 8) + mData[31]);
            //xResult += (UInt16)((mData[32] << 8) + mData[33]);
            //// --UDP Length
            //xResult += (UInt16)((mData[38] << 8) + mData[39]);

            //xResult = (~((xResult & 0xFFFF) + (xResult >> 16)));

            //mData[40] = (byte)(xResult >> 8);
            //mData[41] = (byte)xResult;

            //return (UInt16)xResult;
        }
    }
}
