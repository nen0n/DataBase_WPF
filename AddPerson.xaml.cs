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
using System.Windows.Shapes;

namespace DataBase
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class AddPerson : Window
    {
        private double OriginalHeightWindow = 400;
        private double OriginalWidthWindow = 565;
        public AddPerson()
        {
            InitializeComponent();
            Title = "Добавити людину";
            KPIdiploma.SelectedIndex = 0;
            MONdiploma.SelectedIndex = 0;
            diploma.SelectedIndex = 0;
            Faculity.SelectedIndex = 0;
        }

        private void KPIdiploma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (KPIdiploma.SelectedIndex != 0)
            {
                IDOfProtocol.Visibility = Visibility.Visible;
                YearOfKPI.Visibility = Visibility.Visible;
                Year.Visibility = Visibility.Visible;
                ID.Visibility = Visibility.Visible;
                YearOfKPI.Text = "";
                IDOfProtocol.Text = "";
            }
            else
            {
                IDOfProtocol.Visibility = Visibility.Hidden;
                YearOfKPI.Visibility = Visibility.Hidden;
                Year.Visibility = Visibility.Hidden;
                ID.Visibility = Visibility.Hidden;
                YearOfKPI.Text = "";
                IDOfProtocol.Text = "";
            }
        }

        private void MONdiploma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MONdiploma.SelectedIndex != 0)
            {
                YearOfMON.Visibility = Visibility.Visible;
                Year.Visibility = Visibility.Visible;
                YearOfMON.Text = "";
            }
            else
            {
                Year.Visibility = Visibility.Hidden;
                YearOfMON.Visibility = Visibility.Hidden;
                YearOfMON.Text = "";
            }
        }
        public Person ReturnData()
        {
            if (diploma.SelectedIndex == 2)
            {
                TextBlock selectedFaculity = (TextBlock)Faculity.SelectedItem;
                string selectedMON = (string)MONdiploma.SelectedIndex.ToString();
                Person person = new Person(Name.Text, Surname.Text, SecondName.Text, selectedFaculity.Text, selectedMON, YearOfMON.Text);
                return person;
            }
            else
            {
                TextBlock selectedFaculity = (TextBlock)Faculity.SelectedItem;
                string selectedKPI = (string)KPIdiploma.SelectedIndex.ToString();
                Person person = new Person(Name.Text, Surname.Text, SecondName.Text, selectedFaculity.Text, selectedKPI, IDOfProtocol.Text, YearOfKPI.Text);
                return person;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void diploma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (diploma.SelectedIndex == 1)
            {
                MONdiploma.SelectedIndex = 0;
                KPIdiploma.Visibility = Visibility.Visible;
            }
            else
            {
                KPIdiploma.Visibility = Visibility.Hidden;
            }
            if (diploma.SelectedIndex == 2)
            {
                KPIdiploma.SelectedIndex = 0;
                MONdiploma.Visibility = Visibility.Visible;
            }
            else
            {
                MONdiploma.Visibility = Visibility.Hidden;
                Year.Visibility = Visibility.Hidden;
                YearOfMON.Visibility = Visibility.Hidden;
            }
            if (diploma.SelectedIndex == 0)
            {
                KPIdiploma.SelectedIndex = 0;
                MONdiploma.SelectedIndex = 0;
                KPIdiploma.Visibility = Visibility.Hidden;
                MONdiploma.Visibility = Visibility.Hidden;
                IDOfProtocol.Visibility = Visibility.Hidden;
                YearOfKPI.Visibility = Visibility.Hidden;
                ID.Visibility = Visibility.Hidden;
                Year.Visibility = Visibility.Hidden;
                YearOfMON.Visibility = Visibility.Hidden;
            }
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Add.IsEnabled = false;
            if (Name.Text != "" && Surname.Text != "" && SecondName.Text != "")
            {
                if (Faculity.SelectedIndex != 0)
                {
                    if (MONdiploma.SelectedIndex != 0)
                    {
                        if (YearOfMON.Text != "" && Int32.TryParse(YearOfMON.Text, out int a) && Int32.Parse(YearOfMON.Text) > 0 && Int32.Parse(YearOfMON.Text) < 2023)
                        {
                            Add.IsEnabled = true;
                        }
                    }
                    if (KPIdiploma.SelectedIndex != 0)
                    {
                        if(YearOfKPI.Text != "" && IDOfProtocol.Text != "" && Int32.TryParse(YearOfKPI.Text, out int a) && Int32.Parse(YearOfKPI.Text) > 0 && Int32.Parse(YearOfKPI.Text) < 2023)
                        {
                            Add.IsEnabled = true;
                        }
                    }
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                float xRatio = (float)this.Width / (float)OriginalWidthWindow;
                float yRatio = (float)this.Height / (float)OriginalHeightWindow;
                Render.Width = 186 * xRatio;
                Render.Height = 45 * yRatio;
                Render.Margin = new Thickness(355 * xRatio, 314 * yRatio, 0, 0);

                Surname.Width = 145 * xRatio;
                Surname.Height = 22 * yRatio;
                Surname.Margin = new Thickness(40 * xRatio, 40 * yRatio, 0, 0);
                Surname.FontSize = 12 * (xRatio + yRatio) / 2;

                Name.Width = 145 * xRatio;
                Name.Height = 22 * yRatio;
                Name.Margin = new Thickness(210 * xRatio, 40 * yRatio, 0, 0);
                Name.FontSize = 12 * (xRatio + yRatio) / 2;

                SecondName.Width = 145 * xRatio;
                SecondName.Height = 22 * yRatio;
                SecondName.Margin = new Thickness(380 * xRatio, 40 * yRatio, 0, 0);
                SecondName.FontSize = 12 * (xRatio + yRatio) / 2;

                Faculity.Width = 145 * xRatio;
                Faculity.Height = 22 * yRatio;
                Faculity.Margin = new Thickness(40 * xRatio, 90 * yRatio, 0, 0);
                Faculity.FontSize = 12 * (xRatio + yRatio) / 2;

                KPIdiploma.Width = 315 * xRatio;
                KPIdiploma.Height = 22 * yRatio;
                KPIdiploma.Margin = new Thickness(40 * xRatio, 190 * yRatio, 0, 0);
                KPIdiploma.FontSize = 12 * (xRatio + yRatio) / 2;

                MONdiploma.Width = 315 * xRatio;
                MONdiploma.Height = 22 * yRatio;
                MONdiploma.Margin = new Thickness(40 * xRatio, 190 * yRatio, 0, 0);
                MONdiploma.FontSize = 12 * (xRatio + yRatio) / 2;

                IDOfProtocol.Width = 145 * xRatio;
                IDOfProtocol.Height = 22 * yRatio;
                IDOfProtocol.Margin = new Thickness(40 * xRatio, 260 * yRatio, 0, 0);
                IDOfProtocol.FontSize = 12 * (xRatio + yRatio) / 2;

                YearOfKPI.Width = 145 * xRatio;
                YearOfKPI.Height = 22 * yRatio;
                YearOfKPI.Margin = new Thickness(210 * xRatio, 260 * yRatio, 0, 0);
                YearOfKPI.FontSize = 12 * (xRatio + yRatio) / 2;

                YearOfMON.Width = 145 * xRatio;
                YearOfMON.Height = 22 * yRatio;
                YearOfMON.Margin = new Thickness(210 * xRatio, 260 * yRatio, 0, 0);
                YearOfMON.FontSize = 12 * (xRatio + yRatio) / 2;

                Add.Width = 145 * xRatio;
                Add.Height = 22 * yRatio;
                Add.Margin = new Thickness(380 * xRatio, 330 * yRatio, 0, 0);
                Add.FontSize = 12 * (xRatio + yRatio) / 2;

                diploma.Width = 315 * xRatio;
                diploma.Height = 22 * yRatio;
                diploma.Margin = new Thickness(40 * xRatio, 140 * yRatio, 0, 0);
                diploma.FontSize = 12 * (xRatio + yRatio) / 2;

                Text1.Width = 145 * xRatio;
                Text1.Height = 22 * yRatio;
                Text1.Margin = new Thickness(40 * xRatio, 18 * yRatio, 0, 0);
                Text1.FontSize = 12 * (xRatio + yRatio) / 2;

                Text2.Width = 145 * xRatio;
                Text2.Height = 22 * yRatio;
                Text2.Margin = new Thickness(210 * xRatio, 18 * yRatio, 0, 0);
                Text2.FontSize = 12 * (xRatio + yRatio) / 2;

                Text3.Width = 145 * xRatio;
                Text3.Height = 22 * yRatio;
                Text3.Margin = new Thickness(380 * xRatio, 18 * yRatio, 0, 0);
                Text3.FontSize = 12 * (xRatio + yRatio) / 2;

                Year.Width = 145 * xRatio;
                Year.Height = 23 * yRatio;
                Year.Margin = new Thickness(210 * xRatio, 232 * yRatio, 0, 0);
                Year.FontSize = 12 * (xRatio + yRatio) / 2;

                ID.Width = 145 * xRatio;
                ID.Height = 23 * yRatio;
                ID.Margin = new Thickness(40 * xRatio, 232 * yRatio, 0, 0);
                ID.FontSize = 12 * (xRatio + yRatio) / 2;
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;

            }
            if (this.WindowState == WindowState.Normal)
            {
                this.Width = OriginalWidthWindow;
                this.Height = OriginalHeightWindow;
            }
            float xRatio = (float)this.Width / (float)OriginalWidthWindow;
            float yRatio = (float)this.Height / (float)OriginalHeightWindow;
            Render.Width = 186 * xRatio;
            Render.Height = 45 * yRatio;
            Render.Margin = new Thickness(355 * xRatio, 314 * yRatio, 0, 0);

            Surname.Width = 145 * xRatio;
            Surname.Height = 22 * yRatio;
            Surname.Margin = new Thickness(40 * xRatio, 40 * yRatio, 0, 0);
            Surname.FontSize = 12 * (xRatio + yRatio) / 2;

            Name.Width = 145 * xRatio;
            Name.Height = 22 * yRatio;
            Name.Margin = new Thickness(210 * xRatio, 40 * yRatio, 0, 0);
            Name.FontSize = 12 * (xRatio + yRatio) / 2;

            SecondName.Width = 145 * xRatio;
            SecondName.Height = 22 * yRatio;
            SecondName.Margin = new Thickness(380 * xRatio, 40 * yRatio, 0, 0);
            SecondName.FontSize = 12 * (xRatio + yRatio) / 2;

            Faculity.Width = 145 * xRatio;
            Faculity.Height = 22 * yRatio;
            Faculity.Margin = new Thickness(40 * xRatio, 90 * yRatio, 0, 0);
            Faculity.FontSize = 12 * (xRatio + yRatio) / 2;

            KPIdiploma.Width = 315 * xRatio;
            KPIdiploma.Height = 22 * yRatio;
            KPIdiploma.Margin = new Thickness(40 * xRatio, 190 * yRatio, 0, 0);
            KPIdiploma.FontSize = 12 * (xRatio + yRatio) / 2;

            MONdiploma.Width = 315 * xRatio;
            MONdiploma.Height = 22 * yRatio;
            MONdiploma.Margin = new Thickness(40 * xRatio, 190 * yRatio, 0, 0);
            MONdiploma.FontSize = 12 * (xRatio + yRatio) / 2;

            IDOfProtocol.Width = 145 * xRatio;
            IDOfProtocol.Height = 22 * yRatio;
            IDOfProtocol.Margin = new Thickness(40 * xRatio, 260 * yRatio, 0, 0);
            IDOfProtocol.FontSize = 12 * (xRatio + yRatio) / 2;

            YearOfKPI.Width = 145 * xRatio;
            YearOfKPI.Height = 22 * yRatio;
            YearOfKPI.Margin = new Thickness(210 * xRatio, 260 * yRatio, 0, 0);
            YearOfKPI.FontSize = 12 * (xRatio + yRatio) / 2;

            YearOfMON.Width = 145 * xRatio;
            YearOfMON.Height = 22 * yRatio;
            YearOfMON.Margin = new Thickness(210 * xRatio, 260 * yRatio, 0, 0);
            YearOfMON.FontSize = 12 * (xRatio + yRatio) / 2;

            Add.Width = 145 * xRatio;
            Add.Height = 22 * yRatio;
            Add.Margin = new Thickness(380 * xRatio, 330 * yRatio, 0, 0);
            Add.FontSize = 12 * (xRatio + yRatio) / 2;

            diploma.Width = 315 * xRatio;
            diploma.Height = 22 * yRatio;
            diploma.Margin = new Thickness(40 * xRatio, 140 * yRatio, 0, 0);
            diploma.FontSize = 12 * (xRatio + yRatio) / 2;

            Text1.Width = 145 * xRatio;
            Text1.Height = 22 * yRatio;
            Text1.Margin = new Thickness(40 * xRatio, 18 * yRatio, 0, 0);
            Text1.FontSize = 12 * (xRatio + yRatio) / 2;

            Text2.Width = 145 * xRatio;
            Text2.Height = 22 * yRatio;
            Text2.Margin = new Thickness(210 * xRatio, 18 * yRatio, 0, 0);
            Text2.FontSize = 12 * (xRatio + yRatio) / 2;

            Text3.Width = 145 * xRatio;
            Text3.Height = 22 * yRatio;
            Text3.Margin = new Thickness(380 * xRatio, 18 * yRatio, 0, 0);
            Text3.FontSize = 12 * (xRatio + yRatio) / 2;

            Year.Width = 145 * xRatio;
            Year.Height = 23 * yRatio;
            Year.Margin = new Thickness(210 * xRatio, 232 * yRatio, 0, 0);
            Year.FontSize = 12 * (xRatio + yRatio) / 2;

            ID.Width = 145 * xRatio;
            ID.Height = 23 * yRatio;
            ID.Margin = new Thickness(40 * xRatio, 232 * yRatio, 0, 0);
            ID.FontSize = 12 * (xRatio + yRatio) / 2;

        }
    }
}
