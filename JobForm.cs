using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2dLayoutOptimizer
{
    public partial class JobForm : Form
    {
        JobViewModel _viewModel;
        public JobForm()
        {
            InitializeComponent();

        }
        public JobViewModel Job
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;


            }
        }


        private void wholeNumberKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void jobForm_Load(object sender, EventArgs e)
        {
            _viewModel = new JobViewModel(new Job());
            BindDataSource();
        }
        private void BindDataSource()
        {
            this.jobViewModelBindingSource.DataSource = _viewModel;
            BindFractionOptions(this.cboSheetLength);
            this.cboSheetLength.SelectedIndex = _viewModel.LengthFraction;
            BindFractionOptions(this.cboSheetWidth);
            this.cboSheetWidth.SelectedIndex = _viewModel.WidthFraction;
            BindFractionOptions(this.cboKerf);
            this.cboKerf.SelectedIndex = _viewModel.KerfWidthFraction;
            BindFractionOptions(this.dgvSkus.Columns["lengthFractionDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn);
            BindFractionOptions(this.dgvSkus.Columns["widthFractionDataGridViewTextBoxColumn"] as DataGridViewComboBoxColumn);
            this.dgvSkus.DataSource = _viewModel.SkuViewModels;
        }

        private void BindFractionOptions(ListControl cbo)
        {
            cbo.DataSource = _viewModel.Fractions.Select(x => x).ToList();
            cbo.DisplayMember = "Value";
            cbo.ValueMember = "Key";
        }
        private void BindFractionOptions(DataGridViewComboBoxColumn cbo)
        {
            cbo.DataSource = _viewModel.Fractions.Select(x => x).ToList();
            cbo.DisplayMember = "Value";
            cbo.ValueMember = "Key";
        }
        private void DgvSkus_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == _viewModel.SkuViewModels.Count - 1)
            {
                _viewModel.SkuViewModels.Add(new SkuViewModel(new Sku(), _viewModel.DataChanged));
            }
        }

        private void btnNewJob_Click(object sender, EventArgs e)
        {
            if (_viewModel.UnsavedChanges)
            {
                var result = MessageBox.Show("Are you sure you want to continue?", "Unsaved Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (result == DialogResult.OK)
                {
                    jobForm_Load(null, null);
                }
            }
        }

        private void btnSaveJob_Click(object sender, EventArgs e)
        {
            this.dgvSkus.EndEdit();
            this.jobViewModelBindingSource.EndEdit();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "2dJob|*.2djob";
            saveFileDialog1.Title = "Save Job";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {   
                File.WriteAllText(saveFileDialog1.FileName, JsonConvert.SerializeObject(_viewModel.GetJob()));
                _viewModel.UnsavedChanges = false;
            }
        }

        private void btnOpenJob_Click(object sender, EventArgs e)
        {
            bool ignoreChanges = !_viewModel.UnsavedChanges;
            if (_viewModel.UnsavedChanges)
            {
                var result = MessageBox.Show("Are you sure you want to continue?", "Unsaved Changes", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                ignoreChanges = (result == DialogResult.OK);    
            }
            if (ignoreChanges)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "2dJob|*.2djob";
                openFileDialog.Title = "Open Job";
                openFileDialog.ShowDialog();

                if (openFileDialog.FileName != "")
                {
                    var job = JsonConvert.DeserializeObject<Job>(File.ReadAllText(openFileDialog.FileName));
                    _viewModel = new JobViewModel(job);
                    BindDataSource();
                }
            }
        }

        private void btnRunJob_Click(object sender, EventArgs e)
        {
            this.dgvSkus.EndEdit();
            var job = _viewModel.GetJob();
            var form = new CutSheetForm();
            form.RunJob(job);
            form.Show();
        }
    }
}
