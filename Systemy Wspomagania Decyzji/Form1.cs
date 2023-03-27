
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection.Emit;
using System.Windows.Forms;
using ZedGraph;
using System.Windows.Forms.Integration;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using System.Windows.Documents;

namespace Systemy_Wspomagania_Decyzji
{
    public partial class SWD : Form
    {
        Panel tools;
        Panel table;
        Object[][] data;
        DataGridView grid;
        public SWD()
        {
            InitializeComponent();

            tools = new Panel();
            tools.SetBounds(0, 0, Screen.FromControl(this).Bounds.Width, Convert.ToInt32(Screen.FromControl(this).Bounds.Height * 0.1));
            tools.BackColor = Color.Beige;
            this.Controls.Add(tools);

            table = new Panel();
            table.SetBounds(0, Convert.ToInt32(Screen.FromControl(this).Bounds.Height * 0.1), Screen.FromControl(this).Bounds.Width, Convert.ToInt32(Screen.FromControl(this).Bounds.Height * 0.9));
            table.BackColor = Color.LightGray;
            this.Controls.Add(table);

            initTools();
            intiTable();

        }



        private void initTools()
        {
            Font font = new Font("myFont", 14, FontStyle.Italic);

            Button loadTextData = new Button();
            loadTextData.Click += loadtxt;
            loadTextData.BackColor = Color.White;
            loadTextData.Text = "Load Text Data";
            loadTextData.SetBounds(Convert.ToInt32(tools.Width * 0.005), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            loadTextData.Font = font;
            tools.Controls.Add(loadTextData);

            Button loadExcelData = new Button();
            loadExcelData.Click += loadExcel;
            loadExcelData.BackColor = Color.White;
            loadExcelData.Text = "Load Excel Data";
            loadExcelData.SetBounds(Convert.ToInt32(tools.Width * 0.095), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            loadExcelData.Font = font;
            tools.Controls.Add(loadExcelData);

            Button textToDigits = new Button();
            textToDigits.Click += textDigits;
            textToDigits.BackColor = Color.White;
            textToDigits.Text = "Text To Digits";
            textToDigits.SetBounds(Convert.ToInt32(tools.Width * 0.185), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            textToDigits.Font = font;
            tools.Controls.Add(textToDigits);

            Button discretize = new Button();
            discretize.Click += dyscretizeColumn;
            discretize.BackColor = Color.White;
            discretize.Text = "Discretize";
            discretize.SetBounds(Convert.ToInt32(tools.Width * 0.275), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            discretize.Font = font;
            tools.Controls.Add(discretize);


            Button standardization = new Button();
            standardization.Click += sandarization;
            standardization.BackColor = Color.White;
            standardization.Text = "Standarization";
            standardization.SetBounds(Convert.ToInt32(tools.Width * 0.365), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            standardization.Font = font;
            tools.Controls.Add(standardization);

            Button changeRange = new Button();
            changeRange.Click += changerange;
            changeRange.BackColor = Color.White;
            changeRange.Text = "Change Range";
            changeRange.SetBounds(Convert.ToInt32(tools.Width * 0.455), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            changeRange.Font = font;
            tools.Controls.Add(changeRange);

            Button showFiltered = new Button();
            showFiltered.BackColor = Color.White;
            showFiltered.Click += displayPercent;
            showFiltered.Text = "Display Percent";
            showFiltered.SetBounds(Convert.ToInt32(tools.Width * 0.545), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            showFiltered.Font = font;
            tools.Controls.Add(showFiltered);

            Button diagram2D = new Button();
            diagram2D.BackColor = Color.White;
            diagram2D.Text = "Show 2D Diagram";
            diagram2D.Click += draw2d;
            diagram2D.SetBounds(Convert.ToInt32(tools.Width * 0.635), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            diagram2D.Font = font;
            tools.Controls.Add(diagram2D);

            Button diagram3D = new Button();
            diagram3D.BackColor = Color.White;
            diagram3D.Text = "Show 3D Diagram";
            diagram3D.BackColor = Color.Red;
            diagram3D.SetBounds(Convert.ToInt32(tools.Width * 0.725), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            diagram3D.Font = font;
            tools.Controls.Add(diagram3D);

            Button histogram = new Button();
            histogram.BackColor = Color.White;
            histogram.Text = "Show Histogram";
            histogram.Click += histogramCreate;
            histogram.SetBounds(Convert.ToInt32(tools.Width * 0.815), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            histogram.Font = font;
            tools.Controls.Add(histogram);

            Button save = new Button();
            save.BackColor = Color.White;
            save.Click += saveClick;
            save.Text = "Save";
            save.SetBounds(Convert.ToInt32(tools.Width * 0.905), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            save.Font = font;
            tools.Controls.Add(save);
        }



        private void intiTable()
        {
            grid = new DataGridView();
            grid.SetBounds(0, 0, table.Width, Convert.ToInt32(table.Height * 0.9));
            grid.ColumnCount = 1;
            grid.Columns[0].Name = "Empty";
            grid.Rows.Add("Empty Data");
            grid.CellValueChanged += updateCnvert;
            grid.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.GridColor = Color.Black;
            grid.RowHeadersVisible = false;
            grid.ScrollBars = ScrollBars.Both;
            table.Controls.Add(grid);
        }


        private void setTable()
        {
            table.Controls.Clear();
            grid = new DataGridView();
            grid.SetBounds(0, 0, table.Width, Convert.ToInt32(table.Height * 0.9));
            grid.ColumnCount = data[0].Length;
            for (int i = 0; i < data[0].Length; i++)
            {
                grid.Columns[i].Name = Tools.columnHeaders[i];
            }
            foreach (Object[] o in data)
            {
                grid.Rows.Add(o);
            }
            grid.AutoSizeRowsMode =
            DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grid.CellValueChanged -= updateCnvert;
            grid.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.GridColor = Color.Black;
            grid.RowHeadersVisible = false;
            grid.ScrollBars = ScrollBars.Both;
            table.Controls.Add(grid);
        }
        private void loadtxt(object sender, EventArgs e)
        {
            data = Tools.loadTxt();
            setTable();
        }
        private void loadExcel(object sender, EventArgs e)
        {
            data = Tools.loadFromExcel();
            setTable();
        }
        private void textDigits(object sender, EventArgs e)
        {
            List<Object> obj = new List<object>();
            int colNr = grid.CurrentCell.ColumnIndex;
            grid.Columns.Add("a1", "Digitts of " + grid.Columns[colNr].HeaderText);
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                int j;
                bool exist = false;
                for (j = 0; j < obj.Count; j++)
                {
                    if (grid[colNr, i].Value.ToString() == obj[j].ToString())
                    {
                        exist = true;
                        break;

                    }
                }
                if (!exist) { obj.Add(grid[colNr, i].Value); }
                grid[grid.ColumnCount - 1, i].Value = j + 1;
            }

        }
        private void dyscretizeColumn(object sender, EventArgs e)
        {
            int colNr = grid.CurrentCell.ColumnIndex;
            Form2 f2 = new Form2();
            if (grid[colNr, 0].Value.GetType() == typeof(double) || grid[colNr, 0].Value.GetType() == typeof(int) || grid[colNr, 0].Value.GetType() == typeof(DateTime))
            {
                f2.Width = 500;
                f2.Height = 300;
                f2.numberOfDyscretize = new TextBox();
                f2.numberOfDyscretize.KeyPress += onlyNumbersListener;
                f2.numberOfDyscretize.SetBounds(100, 100, 300, 60);
                f2.Controls.Add(f2.numberOfDyscretize);
                Button close = new Button();
                close.Text = "Submit";
                close.Click += dyscretize;
                close.SetBounds(200, 200, 100, 50);
                f2.Controls.Add(close);
                f2.Show();
            }
            else
            {
                MessageBox.Show("Values from this column can`t be discretized.");
            }
        }
        private void dyscretize(object sender, EventArgs e)
        {
            Form2 o = (Form2)((Button)sender).Parent;
            List<Object> obj = new List<object>();
            int colNr = grid.CurrentCell.ColumnIndex;
            grid.Columns.Add("a1", "Discretize of " + grid.Columns[colNr].HeaderText);
            if (grid[colNr, 0].Value.GetType() != typeof(DateTime))
            {
                double min = double.MaxValue, max = double.MinValue;
                for (int i = 0; i < grid.Rows.Count - 1; i++)
                {

                    if (Convert.ToDouble(grid[colNr, i].Value) > max)
                    {
                        max = Convert.ToDouble(grid[colNr, i].Value);

                    }
                    if (Convert.ToDouble(grid[colNr, i].Value) < min)
                    {
                        min = Convert.ToDouble(grid[colNr, i].Value);

                    }

                }
                double diff = max - min;
                int count = Convert.ToInt32(o.numberOfDyscretize.Text) - 1;
                double blockdiff = diff / count;
                for (int i = 0; i < grid.Rows.Count - 1; i++)
                {
                    grid[grid.ColumnCount - 1, i].Value = (int)((Convert.ToDouble(grid[colNr, i].Value) - min) / blockdiff) + 1;
                }

            }
            else
            {
                // add datetime
            }
            o.Close();
            o.Dispose();

        }
        private void onlyNumbersListener(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void sandarization(object sender, EventArgs e)
        {

            int colNr = grid.CurrentCell.ColumnIndex;
            double a;
            bool succes = double.TryParse(grid[colNr, 0].Value.ToString(), out a);
            if (succes)
            {
                grid.Columns.Add("a1", "Standarization of " + grid.Columns[colNr].HeaderText);
                List<double> list = new List<double>();
                for (int i = 0; i < grid.Rows.Count - 1; i++)
                {
                    list.Add(Convert.ToDouble(grid[colNr, i].Value));
                }
                double aryt = Tools.arytmet(list);
                double odch = Tools.standardDeviation(list);

                for (int i = 0; i < grid.Rows.Count - 1; i++)
                {
                    grid[grid.ColumnCount - 1, i].Value = (double)(Convert.ToDouble(grid[colNr, i].Value) - aryt) / odch;
                }

            }
            else
            {
                MessageBox.Show("Values from this column can`t be standarized.");
            }

        }
        private void changerange(object sender, EventArgs e)
        {
            int colNr = grid.CurrentCell.ColumnIndex;
            Form2 f2 = new Form2();
            double s;

            if (double.TryParse(grid[colNr, 0].Value.ToString(), out s))
            {
                f2.Width = 500;
                f2.Height = 300;
                System.Windows.Forms.Label minLabel = new System.Windows.Forms.Label();
                minLabel.Text = "MIN";
                minLabel.SetBounds(100, 70, 50, 30);
                f2.Controls.Add(minLabel);
                f2.changeRangemin = new TextBox();
                f2.changeRangemin.KeyPress += onlyNumbersListener;
                f2.changeRangemin.SetBounds(100, 100, 100, 60);
                f2.Controls.Add(f2.changeRangemin);
                System.Windows.Forms.Label maxLabel = new System.Windows.Forms.Label();
                maxLabel.Text = "MAX";
                maxLabel.SetBounds(250, 70, 50, 30);
                f2.Controls.Add(maxLabel);
                f2.changeRangemax = new TextBox();
                f2.changeRangemax.KeyPress += onlyNumbersListener;
                f2.changeRangemax.SetBounds(250, 100, 100, 60);
                f2.Controls.Add(f2.changeRangemax);
                Button close = new Button();
                close.Text = "Submit";
                close.Click += changerangesubmit;
                close.SetBounds(200, 200, 100, 50);
                f2.Controls.Add(close);
                f2.Show();
            }
            else
            {
                MessageBox.Show("Values from this column can`t be discretized.");
            }
        }

        private void changerangesubmit(object sender, EventArgs e)
        {
            Form2 o = (Form2)((Button)sender).Parent;
            double minNewRange = Convert.ToDouble(o.changeRangemin.Text);
            double maxNewRange = Convert.ToDouble(o.changeRangemax.Text);
            int colNr = grid.CurrentCell.ColumnIndex;
            List<double> values = new List<double>();
            grid.Columns.Add("a1", "ChangeRange of " + grid.Columns[colNr].HeaderText);
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                values.Add(Convert.ToDouble(grid[colNr, i].Value));
            }
            values = Tools.changeRange(values, minNewRange, maxNewRange);
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                grid[grid.ColumnCount - 1, i].Value = values[i];
            }

            o.Close();
            o.Dispose();
        }
        private void displayPercent(object sender, EventArgs e)
        {
            int colNr = grid.CurrentCell.ColumnIndex;
            Form2 f2 = new Form2();
            double s;

            if (double.TryParse(grid[colNr, 0].Value.ToString(), out s))
            {
                f2.Width = 500;
                f2.Height = 300;
                System.Windows.Forms.Label percentLabel = new System.Windows.Forms.Label();
                percentLabel.Text = "Set Percent (0-100)";
                percentLabel.SetBounds(100, 70, 50, 30);
                f2.Controls.Add(percentLabel);
                f2.percent = new TextBox();
                f2.percent.KeyPress += onlyNumbersListener;
                f2.percent.SetBounds(100, 100, 100, 60);
                f2.Controls.Add(f2.percent);
                f2.percentOf = new ComboBox();
                f2.percentOf.Items.AddRange(new string[] { "Top", "Down", "Margin" });
                f2.percentOf.SetBounds(200, 100, 50, 60);
                f2.Controls.Add(f2.percentOf);
                Button close = new Button();
                close.Text = "Submit";
                close.Click += displayPercentsubmit;
                close.SetBounds(200, 200, 100, 50);
                f2.Controls.Add(close);
                f2.Show();
            }
            else
            {
                MessageBox.Show("Values from this column aren`t Numbers.");
            }
        }

        private void displayPercentsubmit(object sender, EventArgs e)
        {
            Form2 o = (Form2)((Button)sender).Parent;
            String type = (String)o.percentOf.SelectedItem;
            double percent = Convert.ToDouble(o.percent.Text);
            if (percent > 100 || percent < 0) MessageBox.Show("Invalid Percent");
            else
            {
                int colNr = grid.CurrentCell.ColumnIndex;
                int rowC = grid.RowCount - 1;
                double[] list = new double[rowC];
                for (int i = 0; i < rowC; i++)
                {
                    list[i] = Convert.ToDouble(grid[colNr, i].Value);
                    grid[colNr, i].Style.BackColor = Color.White;
                }
                list = SortArray(list, 0, list.Length - 1);

                for (int i = 0; i < rowC; i++)
                {
                    if (type.Equals("Down"))
                    {
                        double lastVal = list[(int)((list.Length - 1) * percent / 100)];
                        if (Convert.ToDouble(grid[colNr, i].Value) <= lastVal) grid[colNr, i].Style.BackColor = Color.GreenYellow;
                    }
                    else if (type.Equals("Top"))
                    {
                        double lastVal = list[(int)((list.Length - 1) - (list.Length - 1) * percent / 100)];
                        if (Convert.ToDouble(grid[colNr, i].Value) >= lastVal) grid[colNr, i].Style.BackColor = Color.GreenYellow;
                    }
                    else if (type.Equals("Margin"))
                    {
                        double minVal = list[(int)((list.Length - 1) * percent / 200)];
                        double maxVal = list[(int)((list.Length - 1) - (list.Length - 1) * percent / 200)];
                        if (Convert.ToDouble(grid[colNr, i].Value) <= minVal || Convert.ToDouble(grid[colNr, i].Value) >= maxVal) grid[colNr, i].Style.BackColor = Color.GreenYellow;
                    }
                }
            }

            o.Close();
            o.Dispose();
        }

        private double[] SortArray(double[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    double temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }

        private void draw2d(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Width = 550;
            f2.Height = 650;

            System.Windows.Forms.Label firstColumn = new System.Windows.Forms.Label();
            firstColumn.Text = "First Column ( X )";
            firstColumn.SetBounds(10, 10, 100, 30);
            f2.Controls.Add(firstColumn);

            f2.selectColumn1 = new ComboBox();
            f2.selectColumn1.SetBounds(10, 55, 100, 40);

            for (int i = 0; i < grid.ColumnCount; i++)
            {
                f2.selectColumn1.Items.Add(grid.Columns[i].HeaderText);
            }
            f2.selectColumn1.SelectedIndex = 0;
            f2.selectColumn1.SelectedIndexChanged += drawAgain;
            f2.Controls.Add(f2.selectColumn1);

            System.Windows.Forms.Label secoundColumn = new System.Windows.Forms.Label();
            secoundColumn.Text = "Second Column ( Y )";
            secoundColumn.SetBounds(120, 10, 100, 30);
            f2.Controls.Add(secoundColumn);

            f2.selectColumn2 = new ComboBox();
            f2.selectColumn2.SetBounds(120, 55, 100, 40);
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                f2.selectColumn2.Items.Add(grid.Columns[i].HeaderText);
            }
            f2.selectColumn2.SelectedIndex = 0;
            f2.selectColumn2.SelectedIndexChanged += drawAgain;
            f2.Controls.Add(f2.selectColumn2);



            System.Windows.Forms.Label classColumn = new System.Windows.Forms.Label();
            classColumn.Text = "Class Kolumn";
            classColumn.SetBounds(220, 10, 100, 30);
            f2.Controls.Add(classColumn);

            f2.selectClassColumn = new ComboBox();
            f2.selectClassColumn.SetBounds(220, 55, 100, 40);
            for (int i = 0; i < grid.ColumnCount; i++)
            {
                f2.selectClassColumn.Items.Add(grid.Columns[i].HeaderText);
            }
            f2.selectClassColumn.SelectedIndex = 0;
            f2.selectClassColumn.SelectedIndexChanged += drawAgain;
            f2.Controls.Add(f2.selectClassColumn);

            Button submit = new Button();
            submit.Text = "Close";
            submit.SetBounds(360, 10, 120, 80);
            submit.Click += close;
            f2.Controls.Add(submit);

            f2.zedGraphControl = new ZedGraphControl();
            f2.zedGraphControl.SetBounds(0, 100, 500, 500);
            f2.Controls.Add(f2.zedGraphControl);

            draw(f2.zedGraphControl, grid.Columns[0].HeaderText, grid.Columns[0].HeaderText, grid.Columns[0].HeaderText);

            f2.Show();

        }

        private void drawAgain(object sender, EventArgs e)
        {
            Form2 o = (Form2)((ComboBox)sender).Parent;
            draw(o.zedGraphControl, (string)o.selectColumn1.SelectedItem, (string)o.selectColumn2.SelectedItem, (string)o.selectClassColumn.SelectedItem);
        }

        private void draw(ZedGraphControl drawPanel, String col1Header, String col2Header, String classheader)
        {
            List<double> data1 = new List<double>();
            List<double> data2 = new List<double>();
            List<String> class1 = new List<String>();
            List<String> classUniqe = new List<String>();
            try
            {
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].HeaderText.Equals(col1Header))
                    {
                        for (int j = 0; j < grid.RowCount - 1; j++)
                        {
                            data1.Add(Convert.ToDouble(grid[i, j].Value));
                        }
                        break;
                    }
                }
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].HeaderText.Equals(col2Header))
                    {
                        for (int j = 0; j < grid.RowCount - 1; j++)
                        {
                            data2.Add(Convert.ToDouble(grid[i, j].Value));
                        }
                        break;
                    }
                }
                for (int i = 0; i < grid.Columns.Count; i++)
                {
                    if (grid.Columns[i].HeaderText.Equals(classheader))
                    {
                        for (int j = 0; j < grid.RowCount - 1; j++)
                        {
                            class1.Add(Convert.ToString(grid[i, j].Value));
                        }
                        break;
                    }
                }

                for (int i = 0; i < class1.Count; i++)
                {
                    bool existed = false;
                    foreach (String s in classUniqe)
                    {
                        if (class1[i] == s) existed = true;
                    }
                    if (!existed)
                    {
                        classUniqe.Add(class1[i]);
                    }


                }





                double Xmax = double.MinValue, Ymax = double.MinValue, Xmin = double.MaxValue, Ymin = double.MaxValue;
                foreach (double d in data1)
                {
                    if (d > Xmax) Xmax = d;
                    if (d < Xmin) Xmin = d;
                }
                foreach (double d in data2)
                {
                    if (d > Ymax) Ymax = d;
                    if (d < Ymin) Ymin = d;
                }
                // clear old curves
                drawPanel.GraphPane.CurveList.Clear();

                // clear old Y axes and manually add new ones
                drawPanel.GraphPane.YAxisList.Clear();

                // add a traditional Y axis
                drawPanel.GraphPane.AddYAxis(col2Header);
                var firstAxis = drawPanel.GraphPane.YAxisList[0];
                



                if (classUniqe.Count > 8)
                {
                    // plot the data as curves
                    var curve1 = drawPanel.GraphPane.AddCurve("Too much class", data1.ToArray(), data2.ToArray(), Color.Blue);
                    curve1.YAxisIndex = 0;
                    drawPanel.GraphPane.Title.Text = col1Header + " & " + col2Header;
                    curve1.Line.IsVisible = false;
                }
                else
                {
                    Color[] colors = new Color[] { Color.Red, Color.Blue,Color.Brown,Color.DarkGreen,Color.DarkViolet,Color.Black,Color.Orange,Color.DarkCyan};
                    for (int i = 0; i < classUniqe.Count; i++)
                    {
                        List<double> classData1 = new List<double>();
                        List<double> classData2 = new List<double>();

                        for (int j = 0; j < class1.Count; j++)
                        {
                            if (class1[j] == classUniqe[i]) { 
                                classData1.Add(data1[j]);
                                classData2.Add(data2[j]);
                            }
                        }

                        var curve1 = drawPanel.GraphPane.AddCurve(classUniqe[i], data1.ToArray(), data2.ToArray(), colors[i]);
                        curve1.YAxisIndex = 0;
                        curve1.Line.IsVisible = false;
                    }

                }
                drawPanel.GraphPane.Title.Text = col1Header + " & " + col2Header;




                // style the plot
                drawPanel.GraphPane.Title.Text = $"2D Graph";
                drawPanel.GraphPane.XAxis.Title.Text = col1Header;

                // auto-axis and update the display
                drawPanel.GraphPane.XAxis.ResetAutoScale(drawPanel.GraphPane, CreateGraphics());
                drawPanel.GraphPane.YAxis.ResetAutoScale(drawPanel.GraphPane, CreateGraphics());
                drawPanel.Refresh();

            }
            catch (FormatException ex)
            {
                MessageBox.Show("Data from column isn`t Numbers");
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Data from column isn`t Numbers");
            }
            catch (OverflowException ex)
            {
                MessageBox.Show("Data from column isn`t Numbers");
            }

        }
        private void histogramCreate(object sender, EventArgs e)
        {
            int colNr = grid.CurrentCell.ColumnIndex;
            Form2 f2 = new Form2();
            f2.Width = 1500;
            f2.Height = 500;
            List<histogramData> histList = new List<histogramData>();


            List<String> values = new List<String>();

            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                values.Add(Convert.ToString(grid[colNr, i].Value));
            }
            for (int i = 0; i < values.Count; i++)
            {
                bool added = false;
                for (int j = 0; j < histList.Count; j++)
                {
                    if (values[i] == histList[j].data)
                    {
                        histList[j].count++;
                        added = true;
                    }
                }
                if (!added)
                {
                    histogramData h = new histogramData();
                    h.data = values[i];
                    h.count = 1;
                    histList.Add(h);
                }
            }
            if (histList.Count > 15) { MessageBox.Show("First Discretize values from this column!"); }
            else
            {
                double max = 0;
                for (int i = 0; i > histList.Count; i++)
                {
                    if (histList[i].count > max) max = histList[i].count;
                }

                f2.zedGraphControl = new ZedGraphControl();
                f2.zedGraphControl.SetBounds(0, 0, 1400, 400);
                f2.zedGraphControl.GraphPane.YAxis.Title.Text = "data";
                f2.zedGraphControl.GraphPane.XAxis.Title.Text = "Count";
                Color[] colors = new Color[] { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple };

                for (int i = 0; i < histList.Count; i++)
                {
                    PointPairList spl1 = new PointPairList(new double[] { 0.1 * i }, new double[] { histList[i].count });
                    BarItem myBar = f2.zedGraphControl.GraphPane.AddBar(histList[i].data, spl1, colors[i % 5]);
                }
                f2.zedGraphControl.RestoreScale(f2.zedGraphControl.GraphPane);
                f2.Controls.Add(f2.zedGraphControl);

                f2.Show();
            }
        }

        private void saveClick(object sender, EventArgs e)
        {
            Object[,] data = new object[grid.ColumnCount, grid.RowCount];
            for (int i = 0; i < grid.ColumnCount; i++)
            {

                for (int j = 0; j < grid.RowCount; j++)
                {
                    data[i, j] = grid[i, j].Value;
                }
            }
            Tools.saveData(data, grid.ColumnCount, grid.RowCount);

        }

        private void close(object sender, EventArgs e)
        {
            Form2 o = (Form2)((Button)sender).Parent;
            o.Close();
            o.Dispose();
        }



        private void updateCnvert(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                try
                {
                    double ignore;
                    bool isDouble = Double.TryParse(grid[i, 0].Value.ToString(), out ignore);
                    DateTime ignor;
                    bool isDate = DateTime.TryParse(grid[i, 0].Value.ToString(), out ignor);
                    if (isDouble)
                    {
                        for (int j = 0; j < grid.RowCount - 1; j++)
                        {
                            grid[i, j].Value = Double.Parse(grid[i, j].Value.ToString());
                        }
                    }
                    else if (isDate)
                    {
                        for (int j = 0; j < grid.RowCount - 1; j++)
                        {
                            grid[i, j].Value = DateTime.Parse(grid[i, j].Value.ToString());
                        }
                    }
                }
                catch (NullReferenceException ex) { }
            }
        }
    }
    public partial class histogramData
    {
        public String data;
        public double count;

    }
}

