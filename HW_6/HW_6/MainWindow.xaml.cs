using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_6
{
    public enum Sex
    {
        Male,
        Female,
        Any
    }
    class Person
    {
        public string name { get; set; }
        public string patronymic;
        public string lastname;
        public int age;
        public Sex sex;

        public string getSex()
        {
            if (sex == Sex.Male)
                return "Мужской";
            else if (sex == Sex.Female)
                return "Женский";
            else
            return "Другой";
        }
    }

    class Preschooler : Person
    {
        public int whatUp;
        public int whatDown;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст:{3}  Пол:{4}\n\tCтатус: Дошкольник\n\tДоход {5},   Расход: {6}",
                    name, patronymic, lastname, age, getSex(), whatUp, whatDown);
        }
        public override bool Equals(object obj)
        {
            Preschooler o = obj as Preschooler;
            if (o.whatUp == this.whatUp)
                return true;
            else
                return false;
        }
    }

    class Schoolboy : Person
    {
        public int pocketUp;
        public int pocketDown;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст:{3}  Пол:{4}\n\tCтатус: Школьник\n\tДоход {5},   Расход: {6}",
                    name, patronymic, lastname, age, getSex(), pocketUp, pocketDown);
        }
        public override bool Equals(object obj)
        {
            Schoolboy o = obj as Schoolboy;
            if (o.pocketUp == this.pocketUp)
                return true;
            else
                return false;
        }
    }

    class Student : Person
    {
        public int scholarshipUp;
        public int scholarshipDown;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст:{3}  Пол:{4}\n\tCтатус: Студент\n\tДоход {5},   Расход: {6}",
                    name, patronymic, lastname, age, getSex(), scholarshipUp, scholarshipDown);
        }
        public override bool Equals(object obj)
        {
            Student o = obj as Student;
            if (o.scholarshipUp == this.scholarshipUp)
                return true;
            else
                return false;
        }
    }

    class Working : Person
    {
        public int salaryUp;
        public int salaryDown;

        public override string ToString()
        {
            return String.Format("{0} {1} {2}\n\tВозраст: {3}  Пол: {4}\n\tCтатус: Работающий \n\tДоход: {5} ₽   Расход: {6} ₽",
                    name, patronymic, lastname, age, getSex(), salaryUp, salaryDown);
        }
        public override bool Equals(object obj)
        {
            Working o = obj as Working;
            if (o.salaryUp == this.salaryUp)
                return true;
            else
                return false;
        }
    }

    public partial class MainWindow : Window
    {
        List<Person> Spisok = new List<Person>
        {
            new Student {name =  "Захарий",patronymic = "Адонисович", lastname = "Криворуков", age = 46, sex = Sex.Male,
                scholarshipUp = 5000, scholarshipDown = 15  },
            new Working {name =  "Мелентий",patronymic = "Ксенофонтович", lastname = "Овцын", age = 64, sex = Sex.Male,
                salaryUp = 25000, salaryDown = 25000 },
            new Preschooler {name =  "Пантелеимон",patronymic = "Аполлонович", lastname = "Обижаев", age = 4, sex = Sex.Any,
                whatUp = 0, whatDown = 0 },
            new Working {name =  "Агния",patronymic = "Аскольдовна", lastname = "Мясоедова", age = 29, sex = Sex.Female,
                salaryUp = 15000, salaryDown = 15000 },
            new Preschooler {name =  "Ульяна",patronymic = "Аврелиевна", lastname = "Гадюкин", age = 0, sex = Sex.Female,
                whatUp = 1000000, whatDown = 99999 },
            new Schoolboy {name =  "Мартимьян",patronymic = "Нарциссович", lastname = "Серверов", age = 7, sex = Sex.Male,
                pocketUp = 0, pocketDown = 0 },
            new Schoolboy {name =  "Олисава",patronymic = "Рюриковна", lastname = "Недокус", age = 16, sex = Sex.Any,
                pocketUp = 250, pocketDown = 0 },
            new Preschooler {name =  "Фома",patronymic = "Платонович", lastname = "Жаба", age = 3, sex = Sex.Male,
                whatUp = 0, whatDown = 0 },
            new Student {name =  "Анфиса",patronymic = "Аврелиевна", lastname = "Чижова", age = 20, sex = Sex.Female,
                scholarshipUp = 30000, scholarshipDown = 25000  },
            new Schoolboy {name =  "Афанасий",patronymic = "Сократович", lastname = "Гусев", age = 11, sex = Sex.Any,
                pocketUp = 500, pocketDown = 500 },
            new Student {name =  "Евдокия",patronymic = "Кронидовна", lastname = "Барашева", age = 19, sex = Sex.Female,
                scholarshipUp = 10000, scholarshipDown = 8600  },
            new Working {name =  "Гурий",patronymic = "Несторович", lastname = "Тетерин", age = 31, sex = Sex.Male,
                salaryUp = 50000, salaryDown = 45000 },
        };

        bool input_txt = false, input_cb = false;


        public MainWindow()
        {
            InitializeComponent();
            Write();
        }

        private void Write()
        {
            txt_output.Items.Clear();
            for (int i = 0; i < Spisok.Count; i++)
            {
                txt_output.Items.Add($"{i+1}. {Spisok[i].ToString()}");
            }
        }

        private void Btm_new_Click(object sender, RoutedEventArgs e)
        {
            grid_new.Visibility = Visibility.Visible;
            grid_great.Visibility = Visibility.Hidden;
        }

        
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            input_txt = true;
            int y;

            if (sender is TextBox)
            {
                if (String.Compare((sender as TextBox).Name, "txt_name") == 0 || String.Compare((sender as TextBox).Name, "txt_lastname") == 0 || String.Compare((sender as TextBox).Name, "txt_patronymic") == 0)
                {
                    for (int i = 0; i < (sender as TextBox).Text.Length; i++)
                    {
                        if (!char.IsLetter((sender as TextBox).Text[i]) && (sender as TextBox).Text.Length != 0)
                        {
                            MessageBox.Show("ФИО могут содержать только буквы");
                            input_txt = false;
                        }
                            
                    }
                }

                if (String.Compare((sender as TextBox).Name, "txt_Down") == 0 || String.Compare((sender as TextBox).Name, "txt_Up") == 0 || String.Compare((sender as TextBox).Name, "txt_year") == 0)
                {
                    if (!int.TryParse((sender as TextBox).Text, out y) && (sender as TextBox).Text.Length != 0)
                    {
                        MessageBox.Show("Вводить надо число.");
                        input_txt = false;
                    }

                    else if (String.Compare((sender as TextBox).Name, "txt_year") == 0)
                    {
                        if (Int32.Parse(txt_year.Text) > 100)
                        { 
                            MessageBox.Show("Введите реальный возраст.");
                            input_txt = false;
                        }
                    }

                    else if (txt_Down.Text.Length != 0 && txt_Up.Text.Length != 0)
                    {
                        if (Int32.Parse(txt_Down.Text) > Int32.Parse(txt_Up.Text))
                        {
                            MessageBox.Show("Расход не может превышать доход.");
                            input_txt = false;
                        }
                    }
                }
            }

            if (txt_name.Text.Length == 0 || txt_lastname.Text.Length == 0 || txt_patronymic.Text.Length == 0 ||  txt_Up.Text.Length == 0 || txt_year.Text.Length == 0 || txt_Down.Text.Length == 0 )
                input_txt = false;
            else
                input_txt = true;

            if (input_cb && input_txt)
                btm_save.IsEnabled = true;
            else
                btm_save.IsEnabled = false;
        }

        private void Btm_delete_Click(object sender, RoutedEventArgs e)
        {
            int n = txt_output.SelectedIndex;
            Spisok.RemoveAt(n);
            Write();
        }

        private void Btm_save_Click(object sender, RoutedEventArgs e)
        {
            int type = cb_status.SelectedIndex, sex_ind = cb_sex.SelectedIndex;
            switch (type)
            {
                case 0:
                    {
                        Spisok.Add(new Preschooler { name = txt_name.Text, patronymic = txt_patronymic.Text, lastname = txt_lastname.Text,
                            age = Int32.Parse(txt_year.Text), whatUp = Int32.Parse(txt_Up.Text), whatDown = Int32.Parse(txt_Down.Text) });
                        break;
                    }
                case 1:
                    {
                        Spisok.Add(new Schoolboy { name = txt_name.Text, patronymic = txt_patronymic.Text, lastname = txt_lastname.Text,
                            age = Int32.Parse(txt_year.Text), sex = Sex.Any, pocketUp = Int32.Parse(txt_Up.Text), pocketDown = Int32.Parse(txt_Down.Text) });
                        break;
                    }
                case 2:
                    {
                        Spisok.Add(new Student { name = txt_name.Text, patronymic = txt_patronymic.Text, lastname = txt_lastname.Text,
                            age = Int32.Parse(txt_year.Text), sex = Sex.Any, scholarshipUp = Int32.Parse(txt_Up.Text), scholarshipDown = Int32.Parse(txt_Down.Text) });
                        break;
                    }
                case 3:
                    {
                        Spisok.Add(new Working { name = txt_name.Text, patronymic = txt_patronymic.Text, lastname = txt_lastname.Text,
                            age = Int32.Parse(txt_year.Text), sex = Sex.Any, salaryUp = Int32.Parse(txt_Up.Text), salaryDown = Int32.Parse(txt_Down.Text) });
                        break;
                    }
            }

            switch (sex_ind)
            {
                case 0:
                    {
                        Spisok[Spisok.Count - 1].sex = Sex.Male;
                        break;
                    }
                case 1:
                    {
                        Spisok[Spisok.Count - 1].sex = Sex.Female;
                        break;
                    }
            }

            grid_new.Visibility = Visibility.Hidden;
            grid_great.Visibility = Visibility.Visible;
            Write();
        }

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            input_cb = false;
            if(cb_sex.SelectedIndex != -1 && cb_status.SelectedIndex != -1)
                input_cb = true;

            if (input_cb && input_txt)
                btm_save.IsEnabled = true;
            else
                btm_save.IsEnabled = false;
        }

        private void Txt_output_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txt_output.SelectedIndex != -1)
                btm_delete.IsEnabled = true;
            else
                btm_delete.IsEnabled = false;
        }
    }
}
