using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RenameFiles
{
	public partial class FormRenameFiles : Form
	{
		private List<PathRename> collection;
		private Dictionary<string, string> log;
		public DataGridViewDragDropEvent DataGridView { get; private set; }
		public FormRenameFiles()
		{
			InitializeComponent();
			collection = new List<PathRename>();
			DataGridView = new DataGridViewDragDropEvent(dgvList, collection);
			log = new Dictionary<string, string>();
			AddDragEnter();
            txtNumBegin.Maximum = decimal.MaxValue;
		}
		private void AddDragEnter()
		{
			DragEnter += delegate (object sender, DragEventArgs e)
			{
				SystemUtil.SetForegroundWindows();
			};

			foreach (Control item in Controls)
			{
				item.DragEnter += delegate (object sender, DragEventArgs e)
				{
					SystemUtil.SetForegroundWindows();
				};
			}
		}
		private void Undo()
		{
			foreach (var item in log)
			{
				if (File.Exists(item.Key)) { File.Move(item.Key, item.Value); continue; }
				Directory.Move(item.Key, item.Value);
			}
			if (!log.Any()) return;
			MessageBox.Show("Desfeita.");
			log.Clear();
		}
		private void btnSalvar_Click(object sender, EventArgs e)
		{
			if (!collection.Any())
			{
				MessageBox.Show("Nenhum arquivo ou pasta adicionado.");
				return;
			}
			if (collection.Any(i => string.IsNullOrWhiteSpace(i.NewName)))
			{
				MessageBox.Show("ERRO!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (collection.Select(r => r.NewPath).Distinct().Count() < collection.Count)
			{
				MessageBox.Show("Tem mais que um com nomes iguais.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
            var name = string.Empty;
			try
			{
				foreach (var item in collection)
				{
                    name = $"{item.OriginalName} => {item.NewName}";
                    item.Rename(log);
				}
				foreach (var item in collection)
				{
                    name = $"{item.OriginalName} => {item.NewName}";
                    item.RenameNumerate(log);
				}
				MessageBox.Show("Renomeado com sucesso", "Sucesso");
			}
			catch (Exception ex)
			{
                MessageBox.Show(ex.Message + Environment.NewLine + ex.ToString(), name);
				Undo();
			}
		}
		private void btnNomear_Click(object sender, EventArgs e)
		{
			var hasNum = txtFormat.Text.Contains("{NUM}");
			if (!hasNum)
			{
				MessageBox.Show("Não tem {NUM}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string format = txtFormat.Text.Replace("NOME", "0").Replace("NUM", "1");
			foreach (var item in collection)
			{
				var num = (txtNumBegin.Value + item.Index)
					.ToString().PadLeft((int)txtNumCount.Value, '0');
				item.NewName = string.Format(format, txtNome.Text, num);
			}
			Refresh();
		}

		private void btnAddPath_Click(object sender, EventArgs e)
		{
			return;
			using (var fbd = new FolderBrowserDialog())
			{
				if (fbd.ShowDialog() == DialogResult.OK)
				{
					DataGridView.Add(fbd.SelectedPath);
				}
			}
		}
		private void btnRefazer_Click(object sender, EventArgs e)
		{
			Undo();
		}

		private void carregaList(string path)
		{
			if (!Directory.Exists(path))
			{
				return;
			}
			btnRefazer.Enabled = false;
			btnSalvar.Enabled = false;
			dgvList.Rows.Clear();
			collection.Clear();

			FileAttributes attr = File.GetAttributes(path);
			txtNome.Text = new DirectoryInfo(path).Name;

			string[] files = Directory.GetFiles(path);
			Array.Sort(files, SystemUtil.Compare);
			//foreach (var item in files) AddPath(item);

			string[] directories = Directory.GetDirectories(path);
			Array.Sort(directories, SystemUtil.Compare);
			//foreach (var item in files) AddPath(item);

		}
		private void btnAddRegistry_Click(object sender, EventArgs e)
		{
			var dic = new Dictionary<string, string>();
			dic.Add("", "&Rename Files");
			dic.Add("Icon", $@"""{Application.ExecutablePath}""");

			var dicc = new Dictionary<string, string>();
			dicc.Add("", $@"""{Application.ExecutablePath}"" ""%1""");

			RegistryKey.SetRegistry("*", dic, dicc);
			RegistryKey.SetRegistry("Folder", dic, dicc);
		}
		private void btnRemoveRegistry_Click(object sender, EventArgs e)
		{
			RegistryKey.RemoveRegistry("*");
			RegistryKey.RemoveRegistry("Folder");
		}
		private void FormRenameFiles_FormClosed(object sender, FormClosedEventArgs e)
		{
			Process.GetCurrentProcess().Kill();
		}
		private void dgvList_DataSourceChanged(object sender, EventArgs e)
		{
			txtNome.Text = DataGridView.GetName();
			txtNumCount.Value = collection.Count.ToString().Length;
		}

        private void btnMesmo_Click(object sender, EventArgs e)
        {
            foreach (var item in collection)
            {
                item.NewName = item.OriginalName;
            }
            Refresh();
        }

        private void btnSubstituir_Click(object sender, EventArgs e)
        {
            foreach (var item in collection)
            {
                item.NewName = item.NewName.Replace(txtOriginal.Text, txtNovo.Text);
            }
            Refresh();
        }
    }
}