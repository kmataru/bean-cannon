using System;
using System.ComponentModel;
using System.Reflection;

namespace BeanCannon.BusinessLogic.Core.Extensions
{
	public static class EnumExtensions
	{
		public static string GetEnumDescription(this Enum value)
		{
			FieldInfo fi = value.GetType().GetField(value.ToString());

			var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

			if (attributes != null && attributes.Length > 0)
			{
				return attributes[0].Description;
			}

			return value.ToString();
		}
	}
}
