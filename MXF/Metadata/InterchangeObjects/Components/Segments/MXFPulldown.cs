﻿#region license
//
// MXF - Myriadbits .NET MXF library. 
// Read MXF Files.
// Copyright (C) 2015 Myriadbits, Jochem Bakker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// For more information, contact me at: info@myriadbits.com
//
#endregion

using System;
using System.ComponentModel;

namespace Myriadbits.MXF
{
    public class MXFPulldown : MXFSegment
    {
        private const string CATEGORYNAME = "Pulldown";

        [Category(CATEGORYNAME)]
        [ULElement("urn:smpte:ul:060e2b34.01010102.05401001.01000000")]
        public MXFPulldownDirection? PulldownDirection { get; set; }

        [Category(CATEGORYNAME)]
        [ULElement("urn:smpte:ul:060e2b34.01010102.05401001.02000000")]
        public MXFPulldownKind? PulldownKind { get; set; }

        [Category(CATEGORYNAME)]
        [ULElement("urn:smpte:ul:060e2b34.01010102.05401001.03000000")]
        public UInt32? PhaseFrame { get; set; }

        public MXFPulldown(MXFReader reader, MXFKLV headerKLV, string metadataName)
            : base(reader, headerKLV, "Pulldown")
        {
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
        {
            switch (localTag.Tag)
            {
                case 0x0D03: this.PulldownDirection = (MXFPulldownDirection?)reader.ReadByte(); return true;
                case 0x0D02: this.PulldownKind = (MXFPulldownKind?)reader.ReadByte(); return true;
                case 0x0D04: this.PhaseFrame = reader.ReadUInt32(); return true;
                case 0x0D01: this.AddChild(reader.ReadReference<MXFSegment>("InputSegment")); return true;
            }

            return base.ParseLocalTag(reader, localTag);
        }

    }
}
