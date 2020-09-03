using System.ComponentModel;

namespace _2dLayoutOptimizer
{
    partial class JobForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvSkus = new System.Windows.Forms.DataGridView();
            this.skuViewModelsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.txtSheetWidth = new System.Windows.Forms.TextBox();
            this.txtSheetLength = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboSheetLength = new System.Windows.Forms.ComboBox();
            this.cboSheetWidth = new System.Windows.Forms.ComboBox();
            this.cboKerf = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewJob = new System.Windows.Forms.ToolStripButton();
            this.btnOpenJob = new System.Windows.Forms.ToolStripButton();
            this.btnSaveJob = new System.Windows.Forms.ToolStripButton();
            this.btnRunJob = new System.Windows.Forms.ToolStripButton();
            this.jobViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthWholeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lengthFractionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.widthWholeNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.widthFractionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.canRotateDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skuViewModelsBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSkus
            // 
            this.dgvSkus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSkus.AutoGenerateColumns = false;
            this.dgvSkus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSkus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.lengthWholeNumberDataGridViewTextBoxColumn,
            this.lengthFractionDataGridViewTextBoxColumn,
            this.widthWholeNumberDataGridViewTextBoxColumn,
            this.widthFractionDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn,
            this.canRotateDataGridViewCheckBoxColumn});
            this.dgvSkus.DataSource = this.skuViewModelsBindingSource;
            this.dgvSkus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSkus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgvSkus.Location = new System.Drawing.Point(12, 87);
            this.dgvSkus.MultiSelect = false;
            this.dgvSkus.Name = "dgvSkus";
            this.dgvSkus.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvSkus.Size = new System.Drawing.Size(776, 464);
            this.dgvSkus.TabIndex = 0;
            this.dgvSkus.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DgvSkus_CellBeginEdit);
            // 
            // skuViewModelsBindingSource
            // 
            this.skuViewModelsBindingSource.DataMember = "SkuViewModels";
            this.skuViewModelsBindingSource.DataSource = this.jobViewModelBindingSource;
            // 
            // txtJobName
            // 
            this.txtJobName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobViewModelBindingSource, "JobName", true));
            this.txtJobName.Location = new System.Drawing.Point(92, 34);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(454, 20);
            this.txtJobName.TabIndex = 1;
            // 
            // txtSheetWidth
            // 
            this.txtSheetWidth.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobViewModelBindingSource, "WidthWholeNumber", true));
            this.txtSheetWidth.Location = new System.Drawing.Point(291, 60);
            this.txtSheetWidth.Name = "txtSheetWidth";
            this.txtSheetWidth.Size = new System.Drawing.Size(50, 20);
            this.txtSheetWidth.TabIndex = 2;
            this.txtSheetWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wholeNumberKeyPressed);
            // 
            // txtSheetLength
            // 
            this.txtSheetLength.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.jobViewModelBindingSource, "LengthWholeNumber", true));
            this.txtSheetLength.Location = new System.Drawing.Point(92, 60);
            this.txtSheetLength.Name = "txtSheetLength";
            this.txtSheetLength.Size = new System.Drawing.Size(50, 20);
            this.txtSheetLength.TabIndex = 3;
            this.txtSheetLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wholeNumberKeyPressed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Job Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sheet Length:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sheet Width:";
            // 
            // cboSheetLength
            // 
            this.cboSheetLength.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.jobViewModelBindingSource, "LengthFraction", true));
            this.cboSheetLength.DisplayMember = "Key";
            this.cboSheetLength.FormattingEnabled = true;
            this.cboSheetLength.Location = new System.Drawing.Point(149, 60);
            this.cboSheetLength.Name = "cboSheetLength";
            this.cboSheetLength.Size = new System.Drawing.Size(50, 21);
            this.cboSheetLength.TabIndex = 8;
            this.cboSheetLength.ValueMember = "Key";
            // 
            // cboSheetWidth
            // 
            this.cboSheetWidth.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.jobViewModelBindingSource, "WidthFraction", true));
            this.cboSheetWidth.DisplayMember = "Key";
            this.cboSheetWidth.FormattingEnabled = true;
            this.cboSheetWidth.Location = new System.Drawing.Point(347, 60);
            this.cboSheetWidth.Name = "cboSheetWidth";
            this.cboSheetWidth.Size = new System.Drawing.Size(50, 21);
            this.cboSheetWidth.TabIndex = 9;
            this.cboSheetWidth.ValueMember = "Key";
            // 
            // cboKerf
            // 
            this.cboKerf.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.jobViewModelBindingSource, "KerfWidthFraction", true));
            this.cboKerf.DisplayMember = "Key";
            this.cboKerf.FormattingEnabled = true;
            this.cboKerf.Location = new System.Drawing.Point(496, 60);
            this.cboKerf.Name = "cboKerf";
            this.cboKerf.Size = new System.Drawing.Size(50, 21);
            this.cboKerf.TabIndex = 10;
            this.cboKerf.ValueMember = "Key";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(461, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Kerf:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewJob,
            this.btnOpenJob,
            this.btnSaveJob,
            this.btnRunJob});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewJob
            // 
            this.btnNewJob.Image = ((System.Drawing.Image)(resources.GetObject("btnNewJob.Image")));
            this.btnNewJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewJob.Name = "btnNewJob";
            this.btnNewJob.Size = new System.Drawing.Size(72, 22);
            this.btnNewJob.Text = "New Job";
            this.btnNewJob.Click += new System.EventHandler(this.btnNewJob_Click);
            // 
            // btnOpenJob
            // 
            this.btnOpenJob.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenJob.Image")));
            this.btnOpenJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenJob.Name = "btnOpenJob";
            this.btnOpenJob.Size = new System.Drawing.Size(77, 22);
            this.btnOpenJob.Text = "Open Job";
            this.btnOpenJob.Click += new System.EventHandler(this.btnOpenJob_Click);
            // 
            // btnSaveJob
            // 
            this.btnSaveJob.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveJob.Image")));
            this.btnSaveJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveJob.Name = "btnSaveJob";
            this.btnSaveJob.Size = new System.Drawing.Size(51, 22);
            this.btnSaveJob.Text = "Save";
            this.btnSaveJob.Click += new System.EventHandler(this.btnSaveJob_Click);
            // 
            // btnRunJob
            // 
            this.btnRunJob.Image = ((System.Drawing.Image)(resources.GetObject("btnRunJob.Image")));
            this.btnRunJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunJob.Name = "btnRunJob";
            this.btnRunJob.Size = new System.Drawing.Size(48, 22);
            this.btnRunJob.Text = "Run";
            this.btnRunJob.Click += new System.EventHandler(this.btnRunJob_Click);
            // 
            // jobViewModelBindingSource
            // 
            this.jobViewModelBindingSource.DataSource = typeof(_2dLayoutOptimizer.JobViewModel);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // lengthWholeNumberDataGridViewTextBoxColumn
            // 
            this.lengthWholeNumberDataGridViewTextBoxColumn.DataPropertyName = "LengthWholeNumber";
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.lengthWholeNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.lengthWholeNumberDataGridViewTextBoxColumn.HeaderText = "Length";
            this.lengthWholeNumberDataGridViewTextBoxColumn.Name = "lengthWholeNumberDataGridViewTextBoxColumn";
            // 
            // lengthFractionDataGridViewTextBoxColumn
            // 
            this.lengthFractionDataGridViewTextBoxColumn.DataPropertyName = "LengthFraction";
            this.lengthFractionDataGridViewTextBoxColumn.HeaderText = "Fraction";
            this.lengthFractionDataGridViewTextBoxColumn.Name = "lengthFractionDataGridViewTextBoxColumn";
            this.lengthFractionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.lengthFractionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // widthWholeNumberDataGridViewTextBoxColumn
            // 
            this.widthWholeNumberDataGridViewTextBoxColumn.DataPropertyName = "WidthWholeNumber";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.widthWholeNumberDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.widthWholeNumberDataGridViewTextBoxColumn.HeaderText = "Width";
            this.widthWholeNumberDataGridViewTextBoxColumn.Name = "widthWholeNumberDataGridViewTextBoxColumn";
            // 
            // widthFractionDataGridViewTextBoxColumn
            // 
            this.widthFractionDataGridViewTextBoxColumn.DataPropertyName = "WidthFraction";
            this.widthFractionDataGridViewTextBoxColumn.HeaderText = "Fraction";
            this.widthFractionDataGridViewTextBoxColumn.Name = "widthFractionDataGridViewTextBoxColumn";
            this.widthFractionDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.widthFractionDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Qty";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            // 
            // canRotateDataGridViewCheckBoxColumn
            // 
            this.canRotateDataGridViewCheckBoxColumn.DataPropertyName = "CanRotate";
            this.canRotateDataGridViewCheckBoxColumn.HeaderText = "CanRotate";
            this.canRotateDataGridViewCheckBoxColumn.Name = "canRotateDataGridViewCheckBoxColumn";
            // 
            // JobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 563);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboKerf);
            this.Controls.Add(this.cboSheetWidth);
            this.Controls.Add(this.cboSheetLength);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSheetLength);
            this.Controls.Add(this.txtSheetWidth);
            this.Controls.Add(this.txtJobName);
            this.Controls.Add(this.dgvSkus);
            this.Name = "JobForm";
            this.Text = "JobForm";
            this.Load += new System.EventHandler(this.jobForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSkus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skuViewModelsBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSkus;
        private System.Windows.Forms.BindingSource jobViewModelBindingSource;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.TextBox txtSheetWidth;
        private System.Windows.Forms.TextBox txtSheetLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboSheetLength;
        private System.Windows.Forms.ComboBox cboSheetWidth;
        private System.Windows.Forms.ComboBox cboKerf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewJob;
        private System.Windows.Forms.ToolStripButton btnSaveJob;
        private System.Windows.Forms.ToolStripButton btnRunJob;
        private System.Windows.Forms.ToolStripButton btnOpenJob;
        private System.Windows.Forms.BindingSource skuViewModelsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lengthWholeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn lengthFractionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn widthWholeNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn widthFractionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn canRotateDataGridViewCheckBoxColumn;
    }
}