using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;
using VRA.DataAccess;
using System.Globalization;
using System.Threading;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinAddRepair.xaml
    /// </summary>
    public partial class WinAddRepair : Window
    {

        private  IList<MachineDto> machineGet = ProcessFactory.GetMachinerProcess().GetList();

        private IList<NameRepairDto> typeRepGet = ProcessFactory.GetNameRapairProcess().GetList();

        private DateTime _id;


        public WinAddRepair()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci; 

            InitializeComponent();

            this.cbMachine.ItemsSource = (from a in machineGet orderby a.CodeMashine select a);

            this.cbTypeRepair.ItemsSource = (from a in typeRepGet orderby a.NameTypeRepair select a);
        }

        public void Load(RepairDto rep)
        {
            if (rep == null)
                return;

            this._id = rep.StartDate;
            dpStartDate.Text = rep.StartDate.ToString();
            tmNote.Text = rep.Note ?? "";

            foreach (MachineDto m in machineGet)
            {
                if (m.CodeMashine == rep.CodeMachine)
                {
                    this.cbMachine.SelectedItem = m;
                    break;
                }
            }

            foreach (NameRepairDto tr in typeRepGet)
            {
                if (tr.IDRepair == rep.IDRepair.IDRepair)
                {
                    this.cbTypeRepair.SelectedItem = tr;
                    break;
                }
            }

            dpStartDate.IsEnabled = false;
            cbTypeRepair.IsEnabled = false;
            cbMachine.IsEnabled = false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cbMachine.Text))
            {
                MessageBox.Show("Код станка не может быть пустым.", "Проверка");
                return;
            }

            if (string.IsNullOrEmpty(cbTypeRepair.Text))
            {
                MessageBox.Show("Тип ремонта не может быть пустым.", "Проверка");
                return;
            }

            if (string.IsNullOrEmpty(dpStartDate.Text))
            {
                MessageBox.Show("Укажите дату начала ремонта", "Проверка");
                return;
            }
            if(tmNote.Text.Length > 500)
            {
                MessageBox.Show("Примечание не может содержать более 500 символов.", "Проверка");
            }

            RepairDto mach = new RepairDto();
            mach.StartDate = Convert.ToDateTime((this.dpStartDate.Text));
            mach.CodeMachine = Convert.ToInt32( this.cbMachine.Text);
            mach.IDRepair = this.cbTypeRepair.SelectedItem as NameRepairDto;
            mach.Note = this.tmNote.Text;

            MachineDto m = new MachineDto();
            MachineDao mD = new MachineDao();
            Machine MM = mD.Get(Convert.ToInt32(this.cbMachine.Text));
            m.CodeMashine = Convert.ToInt32(this.cbMachine.Text);
            m.NumberOfRepair = MM.NumberOfRepair + 1;
            m.IDCountry = DtoConvert.Convert(DaoFactory.GetCountryDao().Get(MM.IDCountry));
            m.IDEnterprise = DtoConvert.Convert(DaoFactory.GetEnterprisenDao().Get(MM.IDEnterprise));
            IMachineProcess mP = ProcessFactory.GetMachinerProcess();
            IRepairProcess machProcess = ProcessFactory.GetRepairProcess();

            if (_id.ToString().Equals("01-01-0001 0:00:00"))
            {
                machProcess.Add(mach);
                machineGet = ProcessFactory.GetMachinerProcess().GetList();
                mP.Update(m);
            }
            else
            {
                mach.StartDate = _id;
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
