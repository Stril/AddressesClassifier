using System;
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
            try
            {
                ClearField(new[] {fldRegion, fldCity, fldDistrict, fldStreet, fldSettlementTown});

                _modelContract.ReadFileClassifier = WinFormUsingServices.GetReadFileClassifier(_modelContract);
                fldRegion.DataSource = _modelContract.ReadFileClassifier.ReadBaseInfoModel()
                    .OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void fldRegion_SelectedValueChanged(object sender, System.EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Получение районов */

        private void btnGetDistricts_Click(object sender, System.EventArgs e)
        {
            try
            {
                var model = fldRegion.SelectedItem as Territory;
                if (model == null)
                {
                    MessageBox.Show("Не выбран регион");
                    return;
                }

                ClearField(new[] {fldCity, fldDistrict, fldStreet, fldSettlementTown});

                /* Если регион - федеральный город */
                if (model.Code.StartsWith("99")
                    || model.Code.StartsWith("77")
                    || model.Code.StartsWith("78")
                    || model.Code.StartsWith("92"))
                {
                    MessageBox.Show("У федерального города нет муниципальных районов");
                    return;
                }

                var data = _modelContract.ReadFileClassifier.ReadRegionModel(model.Code)
                    .AsQueryable();
                fldDistrict.DataSource = _modelContract.GettingDataKladr.GetDistrictByRegion(data, model.Code)
                    .OrderBy(p => p.Name).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Получение городов региона */

        private void btnGetCity_Click(object sender, System.EventArgs e)
        {
            try
            {
                var model = fldRegion.SelectedItem as Territory;
                if (model == null)
                {
                    MessageBox.Show("Не выбран регион");
                    return;
                }

                /* Если регион - федеральный город */
                if (model.Code.StartsWith("99")
                    || model.Code.StartsWith("77")
                    || model.Code.StartsWith("78")
                    || model.Code.StartsWith("92"))
                {
                    MessageBox.Show("У федерального города нет городов. Выберите подчиненные города или сразу улицу");
                    return;
                }

                var data = _modelContract.ReadFileClassifier.ReadRegionModel(model.Code)
                    .AsQueryable();
                fldCity.DataSource = _modelContract.GettingDataKladr.GeTerritoriesByRegion(data, model.Code)
                    .OrderBy(p => p.Name).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* получение населенных пунктов административного округа или подчиненных городу */

        private void btnGetSettlementTown_Click(object sender, System.EventArgs e)
        {
            try
            {
                var model = fldRegion.SelectedItem as Territory;
                if (model == null)
                {
                    MessageBox.Show("Не выбран регион");
                    return;
                }

                if (model.Code.StartsWith("99")
                    || model.Code.StartsWith("77")
                    || model.Code.StartsWith("78")
                    || model.Code.StartsWith("92"))
                {
                    var data = _modelContract.ReadFileClassifier.ReadRegionModel(model.Code)
                        .AsQueryable();
                    fldSettlementTown.DataSource = _modelContract.GettingDataKladr.GetSettlementTownsByCity(data, model.Code)
                        .OrderBy(p => p.Name).ToList();
                    return;
                }

                var region = fldDistrict.SelectedItem as Region;
                if (region != null)
                {
                    var data = _modelContract.ReadFileClassifier.ReadRegionModel(region.Code)
                        .AsQueryable();
                    fldSettlementTown.DataSource = _modelContract.GettingDataKladr.GetTownsByDistrict(data, region.Code)
                        .OrderBy(p => p.Name).ToList();
                    return;
                }

                var city = fldCity.SelectedItem as Region;
                if (city != null)
                {
                    var data = _modelContract.ReadFileClassifier.ReadRegionModel(city.Code)
                        .AsQueryable();
                    fldSettlementTown.DataSource = _modelContract.GettingDataKladr.GetSettlementTownsByCity(data, city.Code)
                        .OrderBy(p => p.Name).ToList();
                    return;
                }

                MessageBox.Show("Ничего не нашлось =(");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /* Получение улиц */

        private void btnGetStreet_Click(object sender, System.EventArgs e)
        {
            try
            {
                var settlementCity = fldSettlementTown.SelectedItem as Region;
                if (settlementCity != null)
                {
                    var streets = _modelContract.ReadFileClassifier.ReadStreetsByRegionModel(settlementCity.Code)
                        .AsQueryable();
                    fldStreet.DataSource = _modelContract.GettingDataKladr.GetStreets(streets, settlementCity.Code)
                        .OrderBy(p => p.Name).ToList();
                    return;
                }

                var model = fldRegion.SelectedItem as Territory;
                if (model == null)
                {
                    MessageBox.Show("Не выбран регион");
                    return;
                }
                /* Если регион - федеральный город */
                if (model.Code.StartsWith("99")
                    || model.Code.StartsWith("77")
                    || model.Code.StartsWith("78")
                    || model.Code.StartsWith("92"))
                {
                    var streets = _modelContract.ReadFileClassifier.ReadStreetsByRegionModel(model.Code)
                        .AsQueryable();
                    fldStreet.DataSource = _modelContract.GettingDataKladr.GetStreetsByRegion(streets, model.Code)
                        .OrderBy(p => p.Name).ToList();
                    return;
                }

                var city = fldCity.SelectedItem as Region;
                if (city != null)
                {
                    var streets = _modelContract.ReadFileClassifier.ReadStreetsByRegionModel(city.Code)
                        .AsQueryable();
                    fldStreet.DataSource = _modelContract.GettingDataKladr.GetStreets(streets, city.Code)
                        .OrderBy(p => p.Name).ToList();
                    return;
                }

                MessageBox.Show("Ничего не нашлось =(");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ClearField(IEnumerable<ComboBox> comboBox)
        {
            try
            {
                foreach (var box in comboBox)
                {
                    box.DataSource = new List<Region>();
                    box.SelectedItem = null;
                    box.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtnClearDistrict_Click(object sender, System.EventArgs e)
        {
            ClearField(new[] {fldDistrict});
        }

        private void btnClearCity_Click(object sender, System.EventArgs e)
        {
            ClearField(new[] {fldCity});
        }

        private void btnClearSettlementTown_Click(object sender, System.EventArgs e)
        {
            ClearField(new[] {fldSettlementTown});
        }

        private void btnClearStreet_Click(object sender, System.EventArgs e)
        {
            ClearField(new[] {fldStreet});
        }
    }
}
