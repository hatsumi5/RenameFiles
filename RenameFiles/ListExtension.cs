using System;
using System.Collections.Generic;

namespace RenameFiles
{
	public static class ListExtension
	{
		public static int Min<T>(this List<T> list, Converter<T, int> projection)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException("Empty list");
			}
			int maxValue = int.MinValue;
			foreach (T item in list)
			{
				int value = projection(item);
				if (value < maxValue)
				{
					maxValue = value;
				}
			}
			return maxValue;
		}
		public static int Max<T>(this List<T> list, Converter<T, int> projection)
		{
			if (list.Count == 0)
			{
				throw new InvalidOperationException("Empty list");
			}
			int maxValue = int.MinValue;
			foreach (T item in list)
			{
				int value = projection(item);
				if (value > maxValue)
				{
					maxValue = value;
				}
			}
			return maxValue;
		}
	}
}