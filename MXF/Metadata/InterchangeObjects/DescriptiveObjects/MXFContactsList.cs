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

using System.ComponentModel;

namespace Myriadbits.MXF
{
    public class MXFContactsList : MXFDescriptiveObject
    {
        public readonly MXFKey personObjects_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x05, 0x40, 0x14, 0x00);
        public readonly MXFKey organizationObjects_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x05, 0x40, 0x15, 0x00);
        public readonly MXFKey locationObjects_Key = new MXFKey(0x06, 0x0e, 0x2b, 0x34, 0x01, 0x01, 0x01, 0x05, 0x06, 0x01, 0x01, 0x04, 0x05, 0x40, 0x16, 0x00);

        public MXFContactsList(MXFReader reader, MXFKLV headerKLV)
            : base(reader, headerKLV)
        {
            this.MetaDataName = "Contacts List";
        }

        /// <summary>
        /// Overridden method to process local tags
        /// </summary>
        /// <param name="localTag"></param>
        protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
        {
            if (localTag.Key != null)
            {
                switch (localTag.Key)
                {
                    case var _ when localTag.Key == personObjects_Key:
                        this.AddChild(reader.ReadReferenceSet<MXFDescriptiveObject>("PersonObjects", "PersonObject")); 
                        return true;
                    case var _ when localTag.Key == organizationObjects_Key: 
                        this.AddChild(reader.ReadReferenceSet<MXFDescriptiveObject>("OrganizationObjects", "OrganizationObject")); 
                        return true;
                    case var _ when localTag.Key == locationObjects_Key: 
                        this.AddChild(reader.ReadReferenceSet<MXFDescriptiveObject>("LocationObjects", "LocationObject")); 
                        return true;
                }
            }

            return base.ParseLocalTag(reader, localTag);
        }

    }
}
