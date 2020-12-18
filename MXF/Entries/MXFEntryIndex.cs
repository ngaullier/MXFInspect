﻿//
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

using System;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace Myriadbits.MXF
{
	public class MXFEntryIndex : MXFObject
	{
		[CategoryAttribute("IndexEntry"), ReadOnly(true)]
		public UInt64 Index { get; set; }
		[CategoryAttribute("IndexEntry"), ReadOnly(true)] 
		public sbyte? TemporalOffset { get; set; }
		[CategoryAttribute("IndexEntry"), ReadOnly(true)] 
		public sbyte? KeyFrameOffset { get; set; }
		[CategoryAttribute("IndexEntry"), ReadOnly(true)] 
		public byte? Flags { get; set; }
		[CategoryAttribute("IndexEntry"), ReadOnly(true)] 
		public UInt64? StreamOffset { get; set; }
		[CategoryAttribute("IndexEntry"), ReadOnly(true)]
		public UInt32[] SliceOffsets { get; set; }
		[CategoryAttribute("IndexEntry"), ReadOnly(true)]
		public MXFRational[] PosTable { get; set; }

		public MXFEntryIndex(UInt64 index, MXFReader reader, byte? sliceCount, byte? posTableCount, UInt32 length)
			: base(reader)
		{
			this.m_eType = MXFObjectType.Index;

			this.Length = length;
			this.Index = index;
			this.TemporalOffset = reader.ReadsB();
			this.KeyFrameOffset = reader.ReadsB();
			this.Flags = reader.ReadB();
			this.StreamOffset = reader.ReadL();

			if (sliceCount.HasValue && sliceCount.Value > 0)
			{
				this.SliceOffsets = new UInt32[sliceCount.Value];
				for (int n = 0; n < sliceCount; n++)
					this.SliceOffsets[n] = reader.ReadD();
			}

			if (posTableCount.HasValue && posTableCount.Value > 0)
			{
				this.PosTable = new MXFRational[posTableCount.Value];
				for (int n = 0; n < posTableCount; n++)
					this.PosTable[n] = reader.ReadRational();				
			}
		}

		/// <summary>
		/// Some output
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return string.Format("Index[{0}] - TemporalOffset {1}, KeyFrameOffset {2}, Offset {3}", this.Index, this.TemporalOffset, this.KeyFrameOffset, this.StreamOffset);
		}

		public string FlagsAsString()
		{
			StringBuilder sb = new StringBuilder();
			bool isKeyFrameOffsetOutOfRange = (this.Flags & (1 << 3)) != 0;
			if ((this.Flags & 0x80) != 0)
				sb.Append("R");
			if ((this.Flags & 0x40) != 0)
				sb.Append("S");
			if ((this.Flags & 0x20) != 0)
				sb.Append("F");
			if ((this.Flags & 0x10) != 0)
				sb.Append("B");
			if (isKeyFrameOffsetOutOfRange)
				sb.Append("-KFHS");
			if ((this.Flags & 0x04) != 0)
				sb.Append("?");
			if ((this.Flags & 0x03) == 0x02)
				sb.Append("[P]");
			else if ((this.Flags & 0x03) == 0x03)
				sb.Append("[B]");
			else if ((this.Flags & 0x03) == 0x01)
				sb.Append("[?]");
			return sb.ToString();
		}

		public override XElement ToXML(bool detailed = false)
		{
			XElement ret = new XElement("Index",
					new XAttribute("streamoffset", this.StreamOffset)
					);
			if (detailed)
				ret.Add(
					new XAttribute("flags", String.Format("{0:X2}",this.Flags)),
					new XAttribute("flagsdesc", FlagsAsString()),
					new XAttribute("keyframe", this.KeyFrameOffset),
					new XAttribute("temporal", this.TemporalOffset),
					new XAttribute("offset", this.Offset)
					);
			return ret;
		}
	}
}
