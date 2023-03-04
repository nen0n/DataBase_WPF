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
    /// Логика взаимодействия для Find.xaml
    /// </summary>
    public partial class Find : Window
    {
        private double OriginalHeightWindow = 273;
        private double OriginalWidthWindow = 600;
        private int choise = 0;
        private int MONindex;
        private int KPIindex;
        private TextBlock Faculityindex;


        public Find()
        {
            InitializeComponent();
            Choise.SelectedIndex = 0;
            KPI.SelectedIndex = 0;
            MON.SelectedIndex = 0;
            Faculity.SelectedIndex = 0;
            Title = "Добавити людину";
        }

        private void Choise_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            KPI.SelectedIndex = 0;
            MON.SelectedIndex = 0;
            Faculity.SelectedIndex = 0;
            MON.Visibility = Visibility.Hidden;
            KPI.Visibility = Visibility.Hidden;
            Faculity.Visibility = Visibility.Hidden;
            Text.Text = "";
            Text.Visibility = Visibility.Hidden;
            choise = 0;
            if (Choise.SelectedIndex == 1)
            {
                choise = 1;
                Text.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 2)
            {
                choise = 2;
                Text.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 3)
            {
                choise = 3;
                Text.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 4)
            {
                choise = 4;
                Faculity.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 5)
            {
                choise = 5;
                KPI.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 6)
            {
                choise = 6;
                Text.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 7)
            {
                choise = 7;
                Text.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 8)
            {
                choise = 8;
                MON.Visibility = Visibility.Visible;
            }
            if (Choise.SelectedIndex == 9)
            {
                choise = 9;
                Text.Visibility = Visibility.Visible;
            }
        }

        private void Render_MouseEnter(object sender, MouseEventArgs e)
        {
            Button.IsEnabled = false;

            MONindex = MON.SelectedIndex;
            KPIindex = KPI.SelectedIndex;
            Faculityindex = (TextBlock)Faculity.SelectedItem;

            if (Text.Text != "")
            {
                if(choise == 7 || choise == 9)
                {
                    if(Int32.Parse(Text.Text) > 0 && Int32.TryParse(Text.Text, out int a))
                    {
                        Button.IsEnabled = true;
                    }
                }
                else
                {
                    Button.IsEnabled = true;
                }
            }
            if(choise == 8)
            {
                if(MON.SelectedIndex != 0)
                {
                    Button.IsEnabled = true;
                }
            }
            if(choise == 5)
            {
                if(KPI.SelectedIndex != 0)
                {
                    Button.IsEnabled = true;
                }    
            }
            if(choise == 4)
            {
                if(Faculity.SelectedIndex != 0)
                {
                    Button.IsEnabled = true;
                }
            }
        }

        public ReturnData ReturnData()
        {
            if (choise == 8)
            {
                return new ReturnData(choise, MONindex.ToString());
            }
            if (choise == 5)
            {
                return new ReturnData(choise, KPIindex.ToString());
            }
            if (choise == 4)
            {
                TextBlock text = Faculityindex;
                return new ReturnData(choise, text.Text);
            }
            return new ReturnData(choise, Text.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
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
            TextBlock.Width = 300 * xRatio;
            TextBlock.Height = 23 * yRatio;
            TextBlock.Margin = new Thickness(50 * xRatio, 50 * yRatio, 0, 0);
            TextBlock.FontSize = 12 * (xRatio + yRatio) / 2;

            Choise.Width = 300 * xRatio;
            Choise.Height = 23 * yRatio;
            Choise.Margin = new Thickness(50 * xRatio, 100 * yRatio, 0, 0);
            Choise.FontSize = 12 * (xRatio + yRatio) / 2;

            Text.Width = 300 * xRatio;
            Text.Height = 23 * yRatio;
            Text.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
            Text.FontSize = 12 * (xRatio + yRatio) / 2;

            Faculity.Width = 300 * xRatio;
            Faculity.Height = 23 * yRatio;
            Faculity.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
            Faculity.FontSize = 12 * (xRatio + yRatio) / 2;

            MON.Width = 300 * xRatio;
            MON.Height = 23 * yRatio;
            MON.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
            MON.FontSize = 12 * (xRatio + yRatio) / 2;

            KPI.Width = 300 * xRatio;
            KPI.Height = 23 * yRatio;
            KPI.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
            KPI.FontSize = 12 * (xRatio + yRatio) / 2;

            Render.Width = 240 * xRatio;
            Render.Height = 70 * yRatio;
            Render.Margin = new Thickness(350 * xRatio, 173 * yRatio, 0, 0);

            Button.Width = 150 * xRatio;
            Button.Height = 23 * yRatio;
            Button.Margin = new Thickness(400 * xRatio, 200 * yRatio, 0, 0);
            Button.FontSize = 12 * (xRatio + yRatio) / 2;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                float xRatio = (float)this.Width / (float)OriginalWidthWindow;
                float yRatio = (float)this.Height / (float)OriginalHeightWindow;

                TextBlock.Width = 300 * xRatio;
                TextBlock.Height = 23 * yRatio;
                TextBlock.Margin = new Thickness(50 * xRatio, 50 * yRatio, 0, 0);
                TextBlock.FontSize = 12 * (xRatio + yRatio) / 2;

                Choise.Width = 300 * xRatio;
                Choise.Height = 23 * yRatio;
                Choise.Margin = new Thickness(50 * xRatio, 100 * yRatio, 0, 0);
                Choise.FontSize = 12 * (xRatio + yRatio) / 2;

                Text.Width = 300 * xRatio;
                Text.Height = 23 * yRatio;
                Text.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
                Text.FontSize = 12 * (xRatio + yRatio) / 2;

                Faculity.Width = 300 * xRatio;
                Faculity.Height = 23 * yRatio;
                Faculity.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
                Faculity.FontSize = 12 * (xRatio + yRatio) / 2;

                MON.Width = 300 * xRatio;
                MON.Height = 23 * yRatio;
                MON.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
                MON.FontSize = 12 * (xRatio + yRatio) / 2;

                KPI.Width = 300 * xRatio;
                KPI.Height = 23 * yRatio;
                KPI.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
                KPI.FontSize = 12 * (xRatio + yRatio) / 2;

                Render.Width = 240 * xRatio;
                Render.Height = 70 * yRatio;
                Render.Margin = new Thickness(350 * xRatio, 173 * yRatio, 0, 0);

                Button.Width = 150 * xRatio;
                Button.Height = 23 * yRatio;
                Button.Margin = new Thickness(400 * xRatio, 200 * yRatio, 0, 0);
                Button.FontSize = 12 * (xRatio + yRatio) / 2;
            }
        }
    }
}
