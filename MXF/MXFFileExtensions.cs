﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Myriadbits.MXF
{
    // TODO: really needed?
    public static class MXFFileExtensions
    {
        public static MXFPartition GetHeader(this MXFFile file)
        {
            return file
                    .FlatList.OfType<MXFPartition>()
                    .SingleOrDefault(p => p.PartitionType == PartitionType.Header);

        }

        public static MXFPartition GetFooter(this MXFFile file)
        {
            return file
                    .FlatList.OfType<MXFPartition>()
                    .SingleOrDefault(p => p.PartitionType == PartitionType.Footer);
        }

        public static MXFCDCIPictureEssenceDescriptor GetMXFPictureDescriptorInHeader(this MXFFile file)
        {
            return file
                    .GetHeader()
                    .Children
                    .OfType<MXFCDCIPictureEssenceDescriptor>()
                    .SingleOrDefault();
        }

        public static IEnumerable<MXFAES3AudioEssenceDescriptor> GetMXFAES3AudioEssenceDescriptors(this MXFFile file)
        {
            return file
                .GetHeader()
                .Children
                .OfType<MXFAES3AudioEssenceDescriptor>();
        }

        public static bool IsKAGSizeOfAllPartitionsEqual(this MXFFile file, uint size)
        {
            return file.Partitions.Select(p => p.KagSize).All(s => s == size);
        }

        public static bool AreAllPartitionsOP1a(this MXFFile file)
        {
            MXFKey op1a = new MXFKey(0x06, 0x0E, 0x2B, 0x34, 0x04, 0x01, 0x01, 0x01, 0x0D, 0x01, 0x02, 0x01, 0x01, 0x01, 0x09, 0x00);
            return file.Partitions.Select(p => p.OP).Any(s => s == op1a);
        }

        public static bool IsFooterClosedAndComplete(this MXFFile file)
        {
            return file.GetFooter().Closed && file.GetFooter().Complete == true;
        }

        public static bool IsHeaderStatusValid(this MXFFile file)
        {
            return !(file.GetHeader().Closed == false  && file.GetHeader().Complete == true);
        }

        public static bool NoEssencesInHeader(this MXFFile file)
        {
            return !file.GetHeader().Children.OfType<MXFEssenceElement>().Any();
        }

        public static bool ISRIPPresent(this MXFFile file)
        {
            return file.RIP != null;
        }

    }
}
