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
using System.Globalization;
using System.Text;

namespace Myriadbits.MXF
{
    /// <summary>
    /// Provides a type converter based on the array converter, that shows a int array
    /// as hex string (e.g. { 312, 21, 0, 7, ...} )
    /// </summary>
    public class IntegerArrayConverter : ArrayConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value != null)
            {
                if (value is UInt32[] uint_array)
                {
                    return IntegerArrayToString<UInt32>(uint_array);
                }
                else if (value is Int32[] int_array)
                {
                    return IntegerArrayToString<Int32>(int_array);
                }

            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private string IntegerArrayToString<T>(T[] array)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{ ");
            for (int n = 0; n < array.Length; n++)
            {
                if (n > 0)
                {
                    sb.Append(", ");
                }
                sb.Append(array[n]);
            }
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
