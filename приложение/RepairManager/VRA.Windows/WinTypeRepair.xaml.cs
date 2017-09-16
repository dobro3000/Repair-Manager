using System;
using System.Windows;
using VRA.BusinessLayer;
using VRA.Dto;

namespace VRA.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinRepairxaml.xaml
    /// </summary>
    public partial class WinRepairxaml : Window
    {
        private int _id;

        public WinRepairxaml()
        {
            InitializeComponent();
        }

        public void Load(TypeRepairDto typeRep)
        {
            if (typeRep == null)
                return;
            _id = typeRep.IDRepair;
            tbLength.Text = typeRep.Lenght.ToString();
            tbNameRepair.Text = typeRep.NameRepair;
            Note.Text = typeRep.Note;
            Cost.Text = typeRep.Cost.ToString();

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLength.Text))
            {
                MessageBox.Show("Длина ремонта не должно быть пустым", "Проверка");
                return;
            }
            else
            {
                double num;
                bool isNum = double.TryParse(tbLength.Text, out num);
                if (!isNum)
                {
                    MessageBox.Show("Введено не число! Подалуйста, повторите ввод.", "Проверка");
                    return;
                }
            }
            
            if (string.IsNullOrEmpty(tbNameRepair.Text))
            {
                MessageBox.Show("Название ремонта  не должно быть пустым", "Проверка");
                return;
            }
            else if(tbNameRepair.Text.Length > 100)
            {
                MessageBox.Show("Название ремонта не может содержать в себе более 100 символов.", "Проверка");
            }

            if (string.IsNullOrEmpty(Cost.Text))
            {
                MessageBox.Show("Цена ремонта не должно быть пустым", "Проверка");
                return;
            }
            else if(Convert.ToInt32(Cost.Text) == 0)
            {
                MessageBox.Show("Цена не может быть равна 0.", "Проверка");
            }
            else
            {
                double num;
                bool isNum = double.TryParse(Cost.Text, out num);
                if (!isNum)
                {
                    MessageBox.Show("Ввдено не число! Пожалуйста, повторите ввод.", "Проверка");
                    return;
                }
            }
            if (Note.Text.Length > 500)
            {
                MessageBox.Show("Примечание не может содержать в себе более 500 символов.", "Проверка");
            }
            TypeRepairDto typeRep = new TypeRepairDto();
            typeRep.NameRepair = tbNameRepair.Text;
            typeRep.Lenght = Math.Round( Convert.ToDouble(tbLength.Text),2);
            typeRep.Cost = Math.Round(Convert.ToDouble(Cost.Text),2);
            typeRep.Note = Note.Text;
            ITypeRepairProcess customerProcess = ProcessFactory.GetTypeRepairProcess();
            
            if (_id == 0)
            {
                customerProcess.Add(typeRep);
            }
            else 
            {
                typeRep.IDRepair = _id;
                customerProcess.Update(typeRep);
            }
            Close();

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
