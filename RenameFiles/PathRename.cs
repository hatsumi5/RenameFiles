using System.Collections.Generic;
using System.IO;

namespace RenameFiles
{
	public class PathRename
	{
		protected string CurrentDirectory { get; set; }
		public string ParentName { get { return Directory.GetParent(OriginalPath).Name; } }
		public string OriginalPath { get; private set; }
		public string OriginalName
		{
			get
			{
				if (IsDirectory) return new DirectoryInfo(OriginalPath).Name;
				if (IsFile) return Path.GetFileName(OriginalPath);
				return null;
			}
		}
		public string NewPath
		{
			get
			{
				if (string.IsNullOrWhiteSpace(NewName)) return null;

				var path = Path.Combine(CurrentDirectory, NewName);
				if (IsFile) return path + extension;
				return path;
			}
		}
		public string NewName
		{
			get { return newName; }
			set
			{
				var num = 0;
				newName = value;
				do
				{
					newNameNumerate = value;
					if (num > 0) newNameNumerate += $" ({num.ToString().PadLeft(3, '0')})";
					num++;
				} while (Exists(NewPathNumerate));
			}
		}
		private string NewPathNumerate
		{
			get
			{
				if (string.IsNullOrWhiteSpace(newNameNumerate)) return null;

				var path = Path.Combine(CurrentDirectory, newNameNumerate);
				if (IsFile) return path + extension;
				return path;
			}
		}
		public int Index { get { return collection.FindIndex(i => i.OriginalPath == OriginalPath); } }
		private bool IsDirectory { get { return type == FileAttributes.Directory; } }
		private bool IsFile { get { return type == FileAttributes.Archive; } }
		private bool IsNewNameNumerate { get { return NewName != newNameNumerate; } }


		private List<PathRename> collection;
		private string extension;
		private string newName;
		private string newNameNumerate;
		private FileAttributes type;
		public PathRename(string originalPath, List<PathRename> collection)
		{
			OriginalPath = originalPath;
			CurrentDirectory = Path.GetDirectoryName(originalPath);
			this.collection = collection;
			extension = Path.GetExtension(originalPath);
			type = File.GetAttributes(OriginalPath).HasFlag(FileAttributes.Directory) ? FileAttributes.Directory : FileAttributes.Archive;
		}
		public bool Exists(string path)
		{
			return IsFile ? File.Exists(path) : Directory.Exists(path);
		}

		private void Move(string originalPath, string newPath, Dictionary<string, string> pathLog)
		{
			if (!IsDirectory && !IsFile) return;
			if (IsDirectory) Directory.Move(originalPath, newPath);
			if (IsFile) File.Move(originalPath, newPath);
			pathLog.Add(newPath, originalPath);
		}
		public void Rename(Dictionary<string, string> pathLog)
		{
			if (!IsDirectory && !IsFile) return;
			Move(OriginalPath, NewPathNumerate, pathLog);
		}
		public void RenameNumerate(Dictionary<string, string> pathLog)
		{
			if (!IsDirectory && !IsFile) return;
			if (!IsNewNameNumerate) return;
			if (Exists(NewName)) return;
			Move(NewPathNumerate, NewPath, pathLog);
		}
	}
}