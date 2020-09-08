using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RenameFiles
{
	public class DataGridViewDragDropEvent
	{
		private DataGridView dataGridView;
		private List<PathRename> collection;
		private List<PathRename> dragPaths;
		private bool dragFromExtern;
		private bool dragMove;

		public DataGridViewDragDropEvent(DataGridView gv, List<PathRename> collection)
		{
			dataGridView = gv; ;
			dataGridView.DragEnter += DataGridView_DragEnter;
			dataGridView.MouseClick += DataGridView_MouseClick;
			dataGridView.MouseMove += DataGridView_MouseMove;
			dataGridView.DragDrop += DataGridView_DragDrop;
			dataGridView.DragOver += DataGridView_DragOver;
			dataGridView.KeyDown += DataGridView_KeyDown;
			this.collection = collection;
			dragFromExtern = false;
			dragMove = false;
			dragPaths = new List<PathRename>();
		}

		
		#region Methods
		public void Add(string path)
		{
			Add(-1, new PathRename(path, collection));
		}

		private void Add(int index, PathRename path)
		{
			if (collection.Exists(i => i.OriginalPath == path.OriginalPath)) return;

			if (index > -1) collection.Insert(index, path);
			else collection.Add(path);
			index = path.Index;
			Refresh();
			dataGridView.Rows[index].Selected = true;
		}

		public void Remove(PathRename path)
		{
			if (path == null) return;

			var index = path.Index;
			collection.Remove(path);
			Refresh();
			if (collection.Count == 0) return;
			if (collection.Count == index) index--;
			dataGridView.CurrentCell = dataGridView[0, index];
			dataGridView.Rows[index].Selected = true;
		}

		public void Move(PathRename p1, PathRename p2)
		{
			if (p1 == p2) return;

			var i1 = p1.Index;
			var i2 = p2.Index;

			dataGridView.CurrentCell = dataGridView[0, i2];
			dataGridView.Rows[i2].Selected = true;
			if (i1 > i2)
			{
				var tmp = p1;
				p1 = p2;
				p2 = tmp;
				var itmp = i1;
				i1 = i2;
				i2 = itmp;
			}
			collection.Remove(p2);
			collection.Insert(i1, p2);
			collection.Remove(p1);
			collection.Insert(i2, p1);
			Refresh();
		}
		public void Refresh()
		{
			dataGridView.DataSource = null;
			dataGridView.DataSource = collection;
		}
		public string GetName()
		{
			return collection.FirstOrDefault()?.ParentName;
		}

		#endregion
		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Delete) return;
			var collection = new List<PathRename>();
			foreach (DataGridViewRow row in dataGridView.SelectedRows) collection.Add((PathRename)row.DataBoundItem);

			foreach (var item in collection) Remove(item);
		}
		
		private void DataGridView_MouseClick(object sender, MouseEventArgs e)
		{
			if (Control.ModifierKeys != Keys.Alt) return;

			var index = dataGridView.HitTest(e.X, e.Y).RowIndex;
			if (!(dragMove = index > -1)) return;

			dragPaths.Clear();
			dragPaths.Add((PathRename)dataGridView.SelectedRows[0].DataBoundItem);
			dataGridView.DoDragDrop(dragPaths, DragDropEffects.Move);
		}
		private void DataGridView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
				dragFromExtern = true;

				dragPaths.Clear();
				var files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (var item in files)
				{
					dragPaths.Add(new PathRename(item, collection));
				}
				return;
			}
			if (dragMove)
			{
				e.Effect = DragDropEffects.Move;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void DataGridView_DragOver(object sender, DragEventArgs e)
		{
			if (!dragFromExtern && !dragMove) return;
			
			Point clientPoint = dataGridView.PointToClient(new Point(e.X, e.Y));
			int index = dataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
			if (index < 0) return;
			if (dragFromExtern)
			{
				foreach (DataGridViewRow item in dataGridView.Rows) item.Selected = item.Index == index;
				return;
			}
			var p = (PathRename)dataGridView.Rows[index].DataBoundItem;
			Move(dragPaths[0], p);
		}

		private void DataGridView_DragDrop(object sender, DragEventArgs e)
		{
			Point clientPoint = dataGridView.PointToClient(new Point(e.X, e.Y));
			int index = dataGridView.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

			if (dragFromExtern)
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				foreach (var item in dragPaths)
				{
					Add(index, item);
				}
				dataGridView.Focus();
				dataGridView.CurrentCell = dataGridView[0, dragPaths.Last().Index];
			}
			e.Effect = DragDropEffects.None;
			dragFromExtern = false;
			dragMove = false;
		}

		private void DataGridView_MouseMove(object sender, MouseEventArgs e)
		{
			if (!dragMove) return;
			if ((e.Button & MouseButtons.Left) != MouseButtons.Left) return;

			DragDropEffects dropEffect = dataGridView.DoDragDrop(dragPaths, DragDropEffects.Move);
		}
	}
}