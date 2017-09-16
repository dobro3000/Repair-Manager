using System;
using System.Windows;
using VRA.Dto;
using VRA.BusinessLayer;
using System.Globalization;
using System.Threading;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinTypeMach.xaml
    /// </summary>
    public partial class WinTypeMach : Window
    {
        public WinTypeMach()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            InitializeComponent();
        }

        private int _id;

        public void Load(TypeMachineDto rep)
        {
            if (rep == null)
                return;

            this._id = Convert.ToInt32(rep.YearOfIssue);

            tbCodeMachine.Text = rep.CodeMachine.ToString();
            tbMark.Text = rep.Mark;
            dpData.Text = rep.YearOfIssue.ToString();

            tbCodeMachine.IsEnabled = false;

        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCodeMachine.Text))
            {
                MessageBox.Show("Код станка не может быть пустым.", "Проверка");
                return;
             }
            else
            {
                int num;
                bool isNum = int.TryParse(tbCodeMachine.Text, out num);
                if (!isNum)
                {
                    MessageBox.Show("Введено не число! Пожалуйста, повторите ввод!", "Проверка");
                    return;
                }
            }

            if (string.IsNullOrEmpty(tbMark.Text))
            {
                MessageBox.Show("Марка не может быть пустым", "Проверка");
                return;
            }
            if(tbMark.Text.Length > 20)
            {
                MessageBox.Show("Название марки не может превышать более 20 символов.", "Проверка");
            }

            if (string.IsNullOrEmpty(dpData.Text))
            {
                MessageBox.Show("Дата выпуска не может быть пустым", "Проверка");
                return;
            }
           if( Convert.ToInt32( dpData.Text) < 1980 && (Convert.ToInt32(dpData.Text) > 1999))
            {
                MessageBox.Show("Станка данного года не обслуживается", "Проверка");
            }
           
            TypeMachineDto mach = new TypeMachineDto();
            mach.YearOfIssue = Convert.ToInt32(this.dpData.Text);
            mach.CodeMachine = Convert.ToInt32(this.tbCodeMachine.Text);
            mach.Mark = this.tbMark.Text;

            ITypeMachineProcess machProcess = ProcessFactory.GetTypeMachinProcess();

            if (_id == 0)
            {
                machProcess.Add(mach);
            }
            else
            {
                mach.YearOfIssue =  _id;
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
