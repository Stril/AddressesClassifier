using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AddressesClassifier.Models;
using ExampleUsageService;

namespace WinFormUsing
{
    public partial class frmMain : Form
    {
        private readonly ModelContract _modelContract;
        private const string KladrPath = @"E:\Projects\Strill\Addresses\Base";
        private bool itLoad;

        public frmMain()
        {
            InitializeComponent();

            _modelContract = new ModelContract();

            fldTypeReader.DataSource = Contracts.ReaderTypes;
            fldFolderDialog.DataBindings.Add(new Binding("Text", _modelContract, "Folder", true,
                DataSourceUpdateMode.OnPropertyChanged));
            fldTypeReader.DataBindings.Add(new Binding("SelectedItem", _modelContract, "ReaderType", true,
                DataSourceUpdateMode.OnPropertyChanged));
        }

        private void btnFolderDialog_Click(object sender, System.EventArgs e)
        {
            fldFolderDialog.Text = Services.OpenFolder(KladrPath);
        }

        private void btnLoad_Click(object sender, System.EventArgs e)
        {
            ClearField(new[] {fldRegion, fldCity, fldDistrict, fldStreet, fldTown});

            _modelContract.ReadFileClassifier = WinFormUsingServices.GetReadFileClassifier(_modelContract);
            fldRegion.DataSource = _modelContract.ReadFileClassifier.ReadBaseInfoModel();
        }

        private static void ClearField(IEnumerable<ComboBox> comboBox)
        {
            foreach (var box in comboBox)
                box.DataSource = new List<Region>();
        }

        private void fldRegion_SelectedValueChanged(object sender, System.EventArgs e)
        {
            var model = fldRegion.SelectedItem as Territory;
            ClearField(new[] {fldCity, fldDistrict, fldStreet, fldTown});
            if (model == null) return;
            /* Если регион - федеральный город */
            if (model.Code.StartsWith("99")
                || model.Code.StartsWith("77")
                || model.Code.StartsWith("78")
                || model.Code.StartsWith("92"))
            {
                FillSettlementTowns(model);
                FillRegionStreets(model);
            }
            else
            {
                FillDistrincts(model);
            }
        }

        private void FillRegionStreets(Territory model)
        {
            var streets =
                _modelContract.ReadFileClassifier.ReadStreetsByRegionModel(model.Code)
                    .AsQueryable();
            fldStreet.DataSource =
                _modelContract.GettingDataKladr.GetStreetsByRegion(streets, model.Code)
                    .OrderBy(p => p.Name)
                    .ToList();
            fldStreet.SelectedIndex = -1;
        }

        private void FillSettlementTowns(Territory model)
        {
            var data = _modelContract.ReadFileClassifier.ReadRegionModel(model.Code).AsQueryable();
            fldCity.DataSource =
                _modelContract.GettingDataKladr.GetSettlementTownsByCity(data, model.Code).OrderBy(p => p.Name).ToList();
            fldCity.SelectedIndex = -1;
        }

        private void FillDistrincts(Territory model)
        {
            var data = _modelContract.ReadFileClassifier.ReadRegionModel(model.Code).AsQueryable();
            fldDistrict.DataSource =
                _modelContract.GettingDataKladr.GetDistrictByRegion(data, model.Code).OrderBy(p => p.Name).ToList();
            fldDistrict.SelectedIndex = -1;
        }

        private void FillCities(Territory model)
        {
            var data = _modelContract.ReadFileClassifier.ReadRegionModel(model.Code).AsQueryable();
            fldCity.DataSource =
                _modelContract.GettingDataKladr.GetTownByRegion(data, model.Code).OrderBy(p => p.Name).ToList();
        }

        private void FillStreets(string cityCode)
        {

        }

        private void fldDistrict_SelectedValueChanged(object sender, System.EventArgs e)
        {
            var model = fldRegion.SelectedItem as Territory;
            if (model == null) return;
            FillCities(model);
        }

        private void fldCity_SelectedValueChanged(object sender, System.EventArgs e)
        {

        }

        private void fldTown_SelectedValueChanged(object sender, System.EventArgs e)
        {

        }

        private void fldStreet_SelectedValueChanged(object sender, System.EventArgs e)
        {

        }

        private void fldDistrict_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
    }
}
