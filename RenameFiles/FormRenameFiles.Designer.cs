namespace RenameFiles
{
    partial class FormRenameFiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRenameFiles));
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnNomear = new System.Windows.Forms.Button();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.OriginalPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathRenameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblFormato = new System.Windows.Forms.Label();
            this.lblFormat = new System.Windows.Forms.Label();
            this.lblNumInicio = new System.Windows.Forms.Label();
            this.btnRefazer = new System.Windows.Forms.Button();
            this.btnAddRegistry = new System.Windows.Forms.Button();
            this.btnRemoveRegistry = new System.Windows.Forms.Button();
            this.txtNumCount = new System.Windows.Forms.NumericUpDown();
            this.txtNumBegin = new System.Windows.Forms.NumericUpDown();
            this.btnMesmo = new System.Windows.Forms.Button();
            this.txtOriginal = new System.Windows.Forms.TextBox();
            this.btnSubstituir = new System.Windows.Forms.Button();
            this.txtNovo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathRenameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumBegin)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            resources.ApplyResources(this.txtNome, "txtNome");
            this.txtNome.Name = "txtNome";
            // 
            // btnSalvar
            // 
            resources.ApplyResources(this.btnSalvar, "btnSalvar");
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnNomear
            // 
            resources.ApplyResources(this.btnNomear, "btnNomear");
            this.btnNomear.Name = "btnNomear";
            this.btnNomear.UseVisualStyleBackColor = true;
            this.btnNomear.Click += new System.EventHandler(this.btnNomear_Click);
            // 
            // dgvList
            // 
            this.dgvList.AllowDrop = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToOrderColumns = true;
            resources.ApplyResources(this.dgvList, "dgvList");
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OriginalPath,
            this.OriginalName,
            this.NewPath,
            this.NewName});
            this.dgvList.DataSource = this.pathRenameBindingSource;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.DataSourceChanged += new System.EventHandler(this.dgvList_DataSourceChanged);
            // 
            // OriginalPath
            // 
            this.OriginalPath.DataPropertyName = "OriginalPath";
            resources.ApplyResources(this.OriginalPath, "OriginalPath");
            this.OriginalPath.Name = "OriginalPath";
            this.OriginalPath.ReadOnly = true;
            // 
            // OriginalName
            // 
            this.OriginalName.DataPropertyName = "OriginalName";
            resources.ApplyResources(this.OriginalName, "OriginalName");
            this.OriginalName.Name = "OriginalName";
            this.OriginalName.ReadOnly = true;
            // 
            // NewPath
            // 
            this.NewPath.DataPropertyName = "NewPath";
            resources.ApplyResources(this.NewPath, "NewPath");
            this.NewPath.Name = "NewPath";
            this.NewPath.ReadOnly = true;
            // 
            // NewName
            // 
            this.NewName.DataPropertyName = "NewName";
            resources.ApplyResources(this.NewName, "NewName");
            this.NewName.Name = "NewName";
            // 
            // pathRenameBindingSource
            // 
            this.pathRenameBindingSource.DataSource = typeof(RenameFiles.PathRename);
            // 
            // txtFormat
            // 
            resources.ApplyResources(this.txtFormat, "txtFormat");
            this.txtFormat.Name = "txtFormat";
            // 
            // lblNome
            // 
            resources.ApplyResources(this.lblNome, "lblNome");
            this.lblNome.Name = "lblNome";
            // 
            // lblFormato
            // 
            resources.ApplyResources(this.lblFormato, "lblFormato");
            this.lblFormato.Name = "lblFormato";
            // 
            // lblFormat
            // 
            resources.ApplyResources(this.lblFormat, "lblFormat");
            this.lblFormat.Name = "lblFormat";
            // 
            // lblNumInicio
            // 
            resources.ApplyResources(this.lblNumInicio, "lblNumInicio");
            this.lblNumInicio.Name = "lblNumInicio";
            // 
            // btnRefazer
            // 
            resources.ApplyResources(this.btnRefazer, "btnRefazer");
            this.btnRefazer.Name = "btnRefazer";
            this.btnRefazer.UseVisualStyleBackColor = true;
            this.btnRefazer.Click += new System.EventHandler(this.btnRefazer_Click);
            // 
            // btnAddRegistry
            // 
            resources.ApplyResources(this.btnAddRegistry, "btnAddRegistry");
            this.btnAddRegistry.Name = "btnAddRegistry";
            this.btnAddRegistry.UseVisualStyleBackColor = true;
            this.btnAddRegistry.Click += new System.EventHandler(this.btnAddRegistry_Click);
            // 
            // btnRemoveRegistry
            // 
            resources.ApplyResources(this.btnRemoveRegistry, "btnRemoveRegistry");
            this.btnRemoveRegistry.Name = "btnRemoveRegistry";
            this.btnRemoveRegistry.UseVisualStyleBackColor = true;
            this.btnRemoveRegistry.Click += new System.EventHandler(this.btnRemoveRegistry_Click);
            // 
            // txtNumCount
            // 
            resources.ApplyResources(this.txtNumCount, "txtNumCount");
            this.txtNumCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtNumCount.Name = "txtNumCount";
            this.txtNumCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtNumBegin
            // 
            resources.ApplyResources(this.txtNumBegin, "txtNumBegin");
            this.txtNumBegin.Name = "txtNumBegin";
            this.txtNumBegin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnMesmo
            // 
            resources.ApplyResources(this.btnMesmo, "btnMesmo");
            this.btnMesmo.Name = "btnMesmo";
            this.btnMesmo.UseVisualStyleBackColor = true;
            this.btnMesmo.Click += new System.EventHandler(this.btnMesmo_Click);
            // 
            // txtOriginal
            // 
            resources.ApplyResources(this.txtOriginal, "txtOriginal");
            this.txtOriginal.Name = "txtOriginal";
            // 
            // btnSubstituir
            // 
            resources.ApplyResources(this.btnSubstituir, "btnSubstituir");
            this.btnSubstituir.Name = "btnSubstituir";
            this.btnSubstituir.UseVisualStyleBackColor = true;
            this.btnSubstituir.Click += new System.EventHandler(this.btnSubstituir_Click);
            // 
            // txtNovo
            // 
            resources.ApplyResources(this.txtNovo, "txtNovo");
            this.txtNovo.Name = "txtNovo";
            // 
            // FormRenameFiles
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNovo);
            this.Controls.Add(this.btnSubstituir);
            this.Controls.Add(this.txtOriginal);
            this.Controls.Add(this.btnMesmo);
            this.Controls.Add(this.txtNumBegin);
            this.Controls.Add(this.txtNumCount);
            this.Controls.Add(this.btnRemoveRegistry);
            this.Controls.Add(this.btnAddRegistry);
            this.Controls.Add(this.btnRefazer);
            this.Controls.Add(this.lblNumInicio);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.lblFormato);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtFormat);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.btnNomear);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtNome);
            this.Name = "FormRenameFiles";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormRenameFiles_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathRenameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumBegin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNomear;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.Label lblNumInicio;
        private System.Windows.Forms.Button btnRefazer;
		private System.Windows.Forms.Button btnAddRegistry;
		private System.Windows.Forms.Button btnRemoveRegistry;
		private System.Windows.Forms.BindingSource pathRenameBindingSource;
		private System.Windows.Forms.NumericUpDown txtNumCount;
		private System.Windows.Forms.NumericUpDown txtNumBegin;
		private System.Windows.Forms.DataGridViewTextBoxColumn OriginalPath;
		private System.Windows.Forms.DataGridViewTextBoxColumn OriginalName;
		private System.Windows.Forms.DataGridViewTextBoxColumn NewPath;
		private System.Windows.Forms.DataGridViewTextBoxColumn NewName;
        private System.Windows.Forms.Button btnMesmo;
        private System.Windows.Forms.TextBox txtOriginal;
        private System.Windows.Forms.Button btnSubstituir;
        private System.Windows.Forms.TextBox txtNovo;
    }
}

