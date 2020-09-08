using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RenameFiles
{
	public static class SystemUtil
	{
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		public static void SetForegroundWindows()
		{
			SetForegroundWindow(Process.GetCurrentProcess().MainWindowHandle);
		}

		public static int Compare(string x, string y)
		{
			return new MyComparer().Compare(x, y);
		}
		class MyComparer : IComparer<string>
		{

			[DllImport("shlwapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true)]
			static extern int StrCmpLogicalW(String x, String y);

			public int Compare(string x, string y)
			{
				return StrCmpLogicalW(x, y);
				//var regex = new Regex("^(d+)");

				//// run the regex on both strings
				//var xRegexResult = regex.Match(x);
				//var yRegexResult = regex.Match(y);

				//// check if they are both numbers
				//if (xRegexResult.Success && yRegexResult.Success)
				//{
				//    return int.Parse(xRegexResult.Groups[1].Value).CompareTo(int.Parse(yRegexResult.Groups[1].Value));
				//}

				//// otherwise return as string comparison
				//return x.CompareTo(y);
			}

		}

	}
}
