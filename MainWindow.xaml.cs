using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataBase
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private double OriginalHeightWindow = 470;
        private double OriginalWidthWindow = 1220;
        List<Person> PersonsInBase = new List<Person>();   
        private int Index = 1;

        public MainWindow()
        {
            InitializeComponent();
            Title = "Датабаза";
            // Add columns
            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 50,
                Header = "№",
                DisplayMemberBinding = new System.Windows.Data.Binding("Index")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Прізвище",
                DisplayMemberBinding = new System.Windows.Data.Binding("Surname")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Ім'я",
                DisplayMemberBinding = new System.Windows.Data.Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "По батькові",
                DisplayMemberBinding = new System.Windows.Data.Binding("SecondName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Факультет",
                DisplayMemberBinding = new System.Windows.Data.Binding("Faculty")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Нагорода КПІ",
                DisplayMemberBinding = new System.Windows.Data.Binding("KPIdiploma")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "№ протоколу",
                DisplayMemberBinding = new System.Windows.Data.Binding("IDOfDiploma")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Рік видачі",
                DisplayMemberBinding = new System.Windows.Data.Binding("YearOfKPI")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Нагорода МОН",
                DisplayMemberBinding = new System.Windows.Data.Binding("MONdiploma")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Рік видачі",
                DisplayMemberBinding = new System.Windows.Data.Binding("YearOfMON")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100,
                Header = "Прогнозування",
                DisplayMemberBinding = new System.Windows.Data.Binding("Prognosis")
            });
        }

        private void AddPerson(Person person)
        {
            person.Index = Index;
            Index++;
            this.listView.Items.Add(person);
        }

        private void ExportName_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "C:";
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = dialog.SelectedPath;
                }
                else
                {
                    return;
                }
            }

            var excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            var workSheet = excelApp.Worksheets[1];
            workSheet.Cells[1, "A"] = "№";
            workSheet.Cells[1, "B"] = "Призвіще";
            workSheet.Cells[1, "C"] = "Ім`я";
            workSheet.Cells[1, "D"] = "По батькові";
            workSheet.Cells[1, "E"] = "Факультет";
            workSheet.Cells[1, "F"] = "Нагорода КПІ";
            workSheet.Cells[1, "G"] = "№ протоколу";
            workSheet.Cells[1, "H"] = "Рік видачі";
            workSheet.Cells[1, "I"] = "Нагорода МОН";
            workSheet.Cells[1, "J"] = "Рік видачі";
            workSheet.Cells[1, "K"] = "Прогнозування";

            for (int row = 0; row < listView.Items.Count; row++)
            {
                workSheet.Cells[row + 2, "A"] = (row + 1).ToString();
                workSheet.Cells[row + 2, "B"] = ((Person)listView.Items[row]).Surname;
                workSheet.Cells[row + 2, "C"] = ((Person)listView.Items[row]).Name;
                workSheet.Cells[row + 2, "D"] = ((Person)listView.Items[row]).SecondName;
                workSheet.Cells[row + 2, "E"] = ((Person)listView.Items[row]).Faculty;
                workSheet.Cells[row + 2, "F"] = ((Person)listView.Items[row]).KPIdiploma;
                workSheet.Cells[row + 2, "G"] = ((Person)listView.Items[row]).IDOfDiploma;
                workSheet.Cells[row + 2, "H"] = ((Person)listView.Items[row]).YearOfKPI;
                workSheet.Cells[row + 2, "I"] = ((Person)listView.Items[row]).MONdiploma;
                workSheet.Cells[row + 2, "J"] = ((Person)listView.Items[row]).YearOfMON;
                workSheet.Cells[row + 2, "K"] = ((Person)listView.Items[row]).Prognosis;
            }
            workSheet.Columns[1].AutoFit();
            workSheet.Columns[2].AutoFit();
            workSheet.Columns[3].AutoFit();
            workSheet.Columns[4].AutoFit();
            workSheet.Columns[5].AutoFit();
            workSheet.Columns[6].AutoFit();
            workSheet.Columns[7].AutoFit();
            workSheet.Columns[8].AutoFit();
            workSheet.Columns[9].AutoFit();
            workSheet.Columns[10].AutoFit();
            workSheet.Columns[11].AutoFit();
            excelApp.Workbooks[1].SaveAs(filePath + "\\output.xlsx");
            excelApp.Workbooks.Close();
            Process.Start(filePath + "\\output.xlsx");

        }


        private void ImportName_Click(object sender, RoutedEventArgs e)
        {

            string filePath = ""; 
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "(*.xlsx)|*.xlsx";
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    filePath = dialog.FileName;
                }
                else
                {
                    return;
                }
            }

            Workbook wb;
            Worksheet ws;
            var excelApp = new Excel.Application();
            wb = excelApp.Workbooks.Open(filePath);
            ws = wb.Worksheets[1];

            PersonsInBase.Clear();
            listView.Items.Clear();
            Index = 1;
            int row = 2; 
            while(ws.Cells[row, "A"].Value != null)
            {
                Person person = new Person();
                person.Surname = ws.Cells[row, "B"].Value.ToString();
                person.Name = ws.Cells[row, "C"].Value.ToString();
                person.SecondName = ws.Cells[row, "D"].Value.ToString();
                person.Faculty = ws.Cells[row, "E"].Value.ToString();
                person.KPIdiploma = ws.Cells[row, "F"].Value.ToString();
                person.IDOfDiploma = ws.Cells[row, "G"].Value.ToString();
                person.YearOfKPI = ws.Cells[row, "H"].Value.ToString();
                person.MONdiploma = ws.Cells[row, "I"].Value.ToString();
                person.YearOfMON = ws.Cells[row, "J"].Value.ToString();
                person.Prognosis = ws.Cells[row, "K"].Value.ToString();
                AddPerson(person);
                PersonsInBase.Add(person);
                row++;
            }
            wb.Close();
        }
        private void FindName_Click(object sender, RoutedEventArgs e)
        {
            AddName.IsEnabled = false;
            DeleteName.IsEnabled = false;
            PrognosisName.IsEnabled = false;
            Find win4 = new Find();
            win4.ShowDialog();
            listView.Items.Clear();
            Index = 1;
            if(win4.DialogResult == true)
            {
                ReturnData data = win4.ReturnData();
                foreach(Person i in PersonsInBase)
                    switch (data.choise)
                    {
                        case 1:
                            if (i.Name == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                        case 2:
                            if (i.Surname == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                        case 3:
                            if (i.SecondName == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                        case 4:
                            if (i.Faculty == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                        case 5:
                            if (i.KPIdiploma == Person.KPIdiplomas[Int32.Parse(data.find)])
                            {
                                AddPerson(i);
                            }
                            break;
                        case 6:
                            if (i.IDOfDiploma == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                        case 7:
                            if (i.YearOfKPI == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                        case 8:
                            if (i.MONdiploma == Person.MONdiplomas[Int32.Parse(data.find)])
                            {
                                AddPerson(i);
                            }
                            break;
                        case 9:
                            if (i.YearOfMON == data.find)
                            {
                                AddPerson(i);
                            }
                            break;
                    }
            }
        }

        private void AddName_Click(object sender, RoutedEventArgs e)
        {
            AddPerson win2 = new AddPerson();
            win2.ShowDialog();
            if (win2.DialogResult == true)
            {
                PersonsInBase.Add(win2.ReturnData());
                AddPerson(win2.ReturnData());
            }
            win2.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.WindowState != WindowState.Maximized)
            {
                float xRatio = (float)this.Width / (float)OriginalWidthWindow;
                float yRatio = (float)this.Height / (float)OriginalHeightWindow;

                AddName.Width = 110 * xRatio;
                AddName.Height = 23 * yRatio;
                AddName.Margin = new Thickness(1083 * xRatio, 24 * yRatio, 0, 0);
                AddName.FontSize = 12 * (xRatio + yRatio) / 2;

                FindName.Width = 110 * xRatio;
                FindName.Height = 23 * yRatio;
                FindName.Margin = new Thickness(1083 * xRatio, 60 * yRatio, 0, 0);
                FindName.FontSize = 12 * (xRatio + yRatio) / 2;

                DeleteName.Width = 110 * xRatio;
                DeleteName.Height = 23 * yRatio;
                DeleteName.Margin = new Thickness(1083 * xRatio, 96 * yRatio, 0, 0);
                DeleteName.FontSize = 12 * (xRatio + yRatio) / 2;

                PrognosisName.Width = 110 * xRatio;
                PrognosisName.Height = 23 * yRatio;
                PrognosisName.Margin = new Thickness(1083 * xRatio, 132 * yRatio, 0, 0);
                PrognosisName.FontSize = 12 * (xRatio + yRatio) / 2;

                DeleteFilterName.Width = 110 * xRatio;
                DeleteFilterName.Height = 23 * yRatio;
                DeleteFilterName.Margin = new Thickness(1083 * xRatio, 168 * yRatio, 0, 0);
                DeleteFilterName.FontSize = 12 * (xRatio + yRatio) / 2;

                ImportName.Width = 110 * xRatio;
                ImportName.Height = 23 * yRatio;
                ImportName.Margin = new Thickness(1083 * xRatio, 391 * yRatio, 0, 0);
                ImportName.FontSize = 12 * (xRatio + yRatio) / 2;

                ExportName.Width = 110 * xRatio;
                ExportName.Height = 23 * yRatio;
                ExportName.Margin = new Thickness(951 * xRatio, 391 * yRatio, 0, 0);
                ExportName.FontSize = 12 * (xRatio + yRatio) / 2;

                listView.Width = 1050 * xRatio;
                listView.Height = 336 * yRatio;
                listView.Margin = new Thickness(11 * xRatio, 24 * yRatio, 0, 0);
                listView.FontSize = 12 * (xRatio + yRatio) / 2;

                var gridView = new GridView();
                this.listView.View = gridView;
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 25 * xRatio,
                    Header = "№",
                    DisplayMemberBinding = new System.Windows.Data.Binding("Index")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 100 * xRatio,
                    Header = "Прізвище",
                    DisplayMemberBinding = new System.Windows.Data.Binding("Surname")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 60 * xRatio,
                    Header = "Ім'я",
                    DisplayMemberBinding = new System.Windows.Data.Binding("Name")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 100 * xRatio,
                    Header = "По батькові",
                    DisplayMemberBinding = new System.Windows.Data.Binding("SecondName")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 40 * xRatio,
                    Header = "Факультет",
                    DisplayMemberBinding = new System.Windows.Data.Binding("Faculty")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 160 * xRatio,
                    Header = "Нагорода КПІ",
                    DisplayMemberBinding = new System.Windows.Data.Binding("KPIdiploma")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 100 * xRatio,
                    Header = "№ протоколу",
                    DisplayMemberBinding = new System.Windows.Data.Binding("IDOfDiploma")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 50 * xRatio,
                    Header = "Рік видачі",
                    DisplayMemberBinding = new System.Windows.Data.Binding("YearOfKPI")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 160 * xRatio,
                    Header = "Нагорода МОН",
                    DisplayMemberBinding = new System.Windows.Data.Binding("MONdiploma")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 50 * xRatio,
                    Header = "Рік видачі",
                    DisplayMemberBinding = new System.Windows.Data.Binding("YearOfMON")
                });
                gridView.Columns.Add(new GridViewColumn
                {
                    Width = 200 * xRatio,
                    Header = "Прогнозування",
                    DisplayMemberBinding = new System.Windows.Data.Binding("Prognosis")
                });
            }
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if(this.WindowState == WindowState.Maximized)
            {
                this.Width = System.Windows.SystemParameters.PrimaryScreenWidth;
                this.Height = System.Windows.SystemParameters.PrimaryScreenHeight;

            }
            if(this.WindowState == WindowState.Normal)
            {
                this.Width = OriginalWidthWindow;
                this.Height = OriginalHeightWindow;
            }
            float xRatio = (float)this.Width / (float)OriginalWidthWindow;
            float yRatio = (float)this.Height / (float)OriginalHeightWindow;

            AddName.Width = 110 * xRatio;
            AddName.Height = 23 * yRatio;
            AddName.Margin = new Thickness(1083 * xRatio, 24 * yRatio, 0, 0);
            AddName.FontSize = 12 * (xRatio + yRatio) / 2;

            FindName.Width = 110 * xRatio;
            FindName.Height = 23 * yRatio;
            FindName.Margin = new Thickness(1083 * xRatio, 60 * yRatio, 0, 0);
            FindName.FontSize = 12 * (xRatio + yRatio) / 2;

            DeleteName.Width = 110 * xRatio;
            DeleteName.Height = 23 * yRatio;
            DeleteName.Margin = new Thickness(1083 * xRatio, 96 * yRatio, 0, 0);
            DeleteName.FontSize = 12 * (xRatio + yRatio) / 2;

            PrognosisName.Width = 110 * xRatio;
            PrognosisName.Height = 23 * yRatio;
            PrognosisName.Margin = new Thickness(1083 * xRatio, 132 * yRatio, 0, 0);
            PrognosisName.FontSize = 12 * (xRatio + yRatio) / 2;

            DeleteFilterName.Width = 110 * xRatio;
            DeleteFilterName.Height = 23 * yRatio;
            DeleteFilterName.Margin = new Thickness(1083 * xRatio, 168 * yRatio, 0, 0);
            DeleteFilterName.FontSize = 12 * (xRatio + yRatio) / 2;

            ImportName.Width = 110 * xRatio;
            ImportName.Height = 23 * yRatio;
            ImportName.Margin = new Thickness(1083 * xRatio, 391 * yRatio, 0, 0);
            ImportName.FontSize = 12 * (xRatio + yRatio) / 2;

            ExportName.Width = 110 * xRatio;
            ExportName.Height = 23 * yRatio;
            ExportName.Margin = new Thickness(951 * xRatio, 391 * yRatio, 0, 0);
            ExportName.FontSize = 12 * (xRatio + yRatio) / 2;

            listView.Width = 1050 * xRatio;
            listView.Height = 336 * yRatio;
            listView.Margin = new Thickness(11 * xRatio, 24 * yRatio, 0, 0);
            listView.FontSize = 12 * (xRatio + yRatio) / 2;

            var gridView = new GridView();
            this.listView.View = gridView;
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 25 * xRatio,
                Header = "№",
                DisplayMemberBinding = new System.Windows.Data.Binding("Index")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100 * xRatio,
                Header = "Прізвище",
                DisplayMemberBinding = new System.Windows.Data.Binding("Surname")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 60 * xRatio,
                Header = "Ім'я",
                DisplayMemberBinding = new System.Windows.Data.Binding("Name")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100 * xRatio,
                Header = "По батькові",
                DisplayMemberBinding = new System.Windows.Data.Binding("SecondName")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 40 * xRatio,
                Header = "Факультет",
                DisplayMemberBinding = new System.Windows.Data.Binding("Faculty")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 160 * xRatio,
                Header = "Нагорода КПІ",
                DisplayMemberBinding = new System.Windows.Data.Binding("KPIdiploma")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 100 * xRatio,
                Header = "№ протоколу",
                DisplayMemberBinding = new System.Windows.Data.Binding("IDOfDiploma")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 50 * xRatio,
                Header = "Рік видачі",
                DisplayMemberBinding = new System.Windows.Data.Binding("YearOfKPI")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 160 * xRatio,
                Header = "Нагорода МОН",
                DisplayMemberBinding = new System.Windows.Data.Binding("MONdiploma")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 50 * xRatio,
                Header = "Рік видачі",
                DisplayMemberBinding = new System.Windows.Data.Binding("YearOfMON")
            });
            gridView.Columns.Add(new GridViewColumn
            {
                Width = 200 * xRatio,
                Header = "Прогнозування",
                DisplayMemberBinding = new System.Windows.Data.Binding("Prognosis")
            });
        }

        private void DeleteName_Click(object sender, RoutedEventArgs e)
        {
            Delete win3 = new Delete();
            win3.ShowDialog();
            if (win3.DialogResult == true)
            {
                if (win3.ReturnData() - 1 < PersonsInBase.Count())
                {
                    PersonsInBase.RemoveAt(win3.ReturnData() - 1);
                }
            }
            listView.Items.Clear();
            Index = 1;
            foreach (Person i in PersonsInBase)
            {
                AddPerson(i);
            }
        }

        private void PrognosisName_Click(object sender, RoutedEventArgs e)
        {
            AddName.IsEnabled = false;
            DeleteName.IsEnabled = false;
            FindName.IsEnabled = false;
            listView.Items.Clear();
            Index = 1;
            for(int i = 1; i < 11; i++)
            {
                foreach(Person person in PersonsInBase)
                {
                    if (person.KPIdiploma == Person.KPIdiplomas[i] && person.YearOfKPI != "2022")
                    {
                        AddPerson(person);
                    }
                }
            }
            for (int i = 1; i < 7; i++)
            {
                foreach (Person person in PersonsInBase)
                {
                    if (person.MONdiploma == Person.MONdiplomas[i] && person.YearOfMON != "2022")
                    {
                        AddPerson(person);
                    }
                }
            }
        }

        private void DeleteFilterName_Click(object sender, RoutedEventArgs e)
        {
            AddName.IsEnabled = true;
            DeleteName.IsEnabled = true;
            PrognosisName.IsEnabled = true;
            FindName.IsEnabled = true;
            listView.Items.Clear();
            Index = 1;
            foreach (Person i in PersonsInBase)
            {
                AddPerson(i);
            }
        }
    }
}
