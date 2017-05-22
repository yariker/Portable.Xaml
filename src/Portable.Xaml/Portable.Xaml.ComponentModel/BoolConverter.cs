﻿#if !NETSTANDARD
using System;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;

namespace Portable.Xaml.ComponentModel
{

	public class BoolConverter : TypeConverter
	{
		public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom (context, sourceType);
		}

		public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(string) || base.CanConvertTo (context, destinationType);
		}

		public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			var text = value as string;
			if (text != null) {
				bool result;
				if (bool.TryParse (text, out result))
					return result;
			}
			return base.ConvertFrom (context, culture, value);
		}

		public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is bool)
				return Convert.ToString (value);
			return base.ConvertTo (context, culture, value, destinationType);
		}
	}

}
#endif