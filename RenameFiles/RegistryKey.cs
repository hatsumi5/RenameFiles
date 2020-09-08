using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RenameFiles
{
	static class RegistryKey
	{
		private static string GetRegistrySubKey(string type)
		{
			return $@"{type}\shell\Rename Files";
		}
		private static string GetRegistrySubKeyCommand(string type)
		{
			return $@"{GetRegistrySubKey(type)}\command";
		}
		public static void SetRegistry(string type, Dictionary<string, string> value, Dictionary<string, string> cvalue)
		{
			var name = GetRegistrySubKey(type);
			SetRegistryCore(name, value);
			name = GetRegistrySubKeyCommand(type);
			SetRegistryCore(name, cvalue);
		}
		private static void SetRegistryCore(string name, Dictionary<string, string> value)
		{
			using (var reg = Registry.ClassesRoot.CreateSubKey(name))
			{
				try
				{
					if (reg == null) return;

					foreach (var item in value)
					{
						reg.SetValue(item.Key, item.Value);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.ToString());
				}
			}
		}
		public static void RemoveRegistry(string type)
		{
			var path = GetRegistrySubKeyCommand(type);
			RemoveRegistryCore(path);
			path = GetRegistrySubKey(type);
			RemoveRegistryCore(path);
		}
		private static void RemoveRegistryCore(string name)
		{
			using (var reg = Registry.ClassesRoot.OpenSubKey(name))
			{
				try
				{
					if (reg != null)
					{
						reg.Close();
						Registry.ClassesRoot.DeleteSubKey(name);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, ex.ToString());
				}
			}
		}
	}
}