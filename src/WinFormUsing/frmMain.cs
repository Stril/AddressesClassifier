using System.Windows.Forms;
using AddressesClassifier;
using ExampleUsageService;

namespace WinFormUsing
{
    public partial class frmMain : Form
    {
        private ModelContract _modelContract;
        private ReaderKladr _readerKladr;

        public frmMain()
        {
            _modelContract = new ModelContract();
            InitializeComponent();

            fldTypeReader.DataSource = Contracts.ReaderTypes;
            fldTypeReader.ValueMember = "CodeEnum";
            fldTypeReader.DisplayMember = "Name";
            fldFolderDialog.DataBindings.Add(new Binding("Text", _modelContract, "Folder", true,
                DataSourceUpdateMode.OnPropertyChanged));
            fldTypeReader.DataBindings.Add(new Binding("SelectedItem", _modelContract, "ReaderType", true,
                DataSourceUpdateMode.OnPropertyChanged));
        }

        private void btnFolderDialog_Click(object sender, System.EventArgs e)
        {
            fldFolderDialog.Text = Services.OpenFolder();
        }

        private void btnLoad_Click(object sender, System.EventArgs e)
        {
            _modelContract.ReadFileClassifier = WinFormUsingServices.GetReadFileClassifier(_modelContract);
            fldRegion.DataSource = _modelContract.ReadFileClassifier.ReadBaseInfoModel();
            fldRegion.ValueMember = "Code";
            fldRegion.DisplayMember = "Name";

        }
    }
}
