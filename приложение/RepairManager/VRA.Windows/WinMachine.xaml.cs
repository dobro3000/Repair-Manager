using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinMachine.xaml
    /// </summary>
    public partial class WinMachine : Window
    {

        private readonly IList<TypeMachineDto> Machine = ProcessFactory.GetTypeMachinProcess().GetList();
        private IList<EnterpriseDto> enterpriseGet = ProcessFactory.GetEnterpriseProcess().GetList();
        private IList<CountryDto> countryGet = ProcessFactory.GetCountryProcess().GetList();

        public WinMachine()
        {
            InitializeComponent();
            
            this.cbCodeMachine.ItemsSource = (from a in Machine orderby a.CodeMachine select a).ToList<TypeMachineDto>();

            this.cbEnterprise.ItemsSource = (from a in enterpriseGet orderby a.NameEnterprise select a).ToList<EnterpriseDto>();

            this.cbCountry.ItemsSource = (from a in countryGet orderby a.NameCountry select a).ToList<CountryDto>();
        }

        private int _id;
        private int? numbRep = 0;
        public void Load(MachineDto mach)
        {
            if (mach == null) return;

            this._id = mach.CodeMashine;
            numbRep = mach.NumberOfRepair;

            foreach (CountryDto countr in countryGet)
            {
                if (countr.IDCountry == mach.IDCountry.IDCountry )
                {
                    this.cbCountry.SelectedItem = countr;
                    break;
                }
            }

            foreach (EnterpriseDto enter in enterpriseGet)
            {
                if (mach.IDEnterprise.IDEnterprise == enter.IDEnterprise)
                {
                    this.cbEnterprise.SelectedItem = enter;
                    break;
                }
            }

            foreach (TypeMachineDto mac in Machine)
            {
                if (mach.CodeMashine == mac.CodeMachine)
                {
                    this.cbCodeMachine.SelectedItem = mac;
                    break;
                }
            }

            cbCodeMachine.IsEnabled = false;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrEmpty(cbCodeMachine.Text))
            {
                MessageBox.Show("Код станка не может быть пустым.", "Проверка");
                return;
            }

            if (string.IsNullOrEmpty(cbEnterprise.Text))
            {
                MessageBox.Show("Название предприятия не может быть пустым.", "Проверка");
                return;
            }

            if (string.IsNullOrEmpty(cbCountry.Text))
            {
                MessageBox.Show("Название страны не может быть пустым.", "Проверка");
                return;
            }


            MachineDto mach = new MachineDto();
            mach.CodeMashine = Convert.ToInt32(this.cbCodeMachine.Text);
            mach.IDCountry = cbCountry.SelectedItem as CountryDto;
            mach.IDEnterprise = cbEnterprise.SelectedItem as EnterpriseDto;
            mach.NumberOfRepair = numbRep;
           


            IMachineProcess machProcess = ProcessFactory.GetMachinerProcess();

            if (_id == 0)
            {
                mach.NumberOfRepair = 0;
                machProcess.Add(mach);
            }
            else 
            {
                mach.CodeMashine = _id;
                machProcess.Update(mach);
            }

            this.Close();


        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
