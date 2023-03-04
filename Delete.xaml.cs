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
    /// Логика взаимодействия для Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        private double OriginalHeightWindow = 300;
        private double OriginalWidthWindow = 300;
        public Delete()
        {
            InitializeComponent();
            Title = "Видалити людину";
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                float xRatio = (float)this.Width / (float)OriginalWidthWindow;
                float yRatio = (float)this.Height / (float)OriginalHeightWindow;

                Text.Width = 280 * xRatio;
                Text.Height = 92 * yRatio;
                Text.Margin = new Thickness(10 * xRatio, 43 * yRatio, 0, 0);
                Text.FontSize = 12 * (xRatio + yRatio) / 2;

                TextBlock.Width = 150 * xRatio;
                TextBlock.Height = 23 * yRatio;
                TextBlock.Margin = new Thickness(75 * xRatio, 100 * yRatio, 0, 0);
                TextBlock.FontSize = 12 * (xRatio + yRatio) / 2;

                Button.Width = 200 * xRatio;
                Button.Height = 77 * yRatio;
                Button.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
                Button.FontSize = 12 * (xRatio + yRatio) / 2;

                Render.Width = 300 * xRatio;
                Render.Height = 110 * yRatio;
                Render.Margin = new Thickness(0 * xRatio, 135 * yRatio, 0, 0);
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

            Text.Width = 280 * xRatio;
            Text.Height = 92 * yRatio;
            Text.Margin = new Thickness(10 * xRatio, 43 * yRatio, 0, 0);
            Text.FontSize = 12 * (xRatio + yRatio) / 2;

            TextBlock.Width = 150 * xRatio;
            TextBlock.Height = 23 * yRatio;
            TextBlock.Margin = new Thickness(75 * xRatio, 100 * yRatio, 0, 0);
            TextBlock.FontSize = 12 * (xRatio + yRatio) / 2;

            Button.Width = 200 * xRatio;
            Button.Height = 77 * yRatio;
            Button.Margin = new Thickness(50 * xRatio, 150 * yRatio, 0, 0);
            Button.FontSize = 12 * (xRatio + yRatio) / 2;

            Render.Width = 300 * xRatio;
            Render.Height = 110 * yRatio;
            Render.Margin = new Thickness(0 * xRatio, 135 * yRatio, 0, 0);
        }

        private void Render_MouseEnter(object sender, MouseEventArgs e)
        {
            Button.IsEnabled = false;
            if (TextBlock.Text != "" && Int32.TryParse(TextBlock.Text, out int a) && Int32.Parse(TextBlock.Text) > 0)
            {
                Button.IsEnabled = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public int ReturnData()
        {
            return Int32.Parse(TextBlock.Text);
        }
    }
}
