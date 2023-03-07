
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

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
            showFiltered.Text = "Show Filtered";
            showFiltered.SetBounds(Convert.ToInt32(tools.Width * 0.545), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            showFiltered.Font = font;
            tools.Controls.Add(showFiltered);

            Button diagram2D = new Button();
            diagram2D.BackColor = Color.White;
            diagram2D.Text = "Show 2D Diagram";
            diagram2D.SetBounds(Convert.ToInt32(tools.Width * 0.635), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            diagram2D.Font = font;
            tools.Controls.Add(diagram2D);

            Button diagram3D = new Button();
            diagram3D.BackColor = Color.White;
            diagram3D.Text = "Show 3D Diagram";
            diagram3D.SetBounds(Convert.ToInt32(tools.Width * 0.725), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            diagram3D.Font = font;
            tools.Controls.Add(diagram3D);

            Button histogram = new Button();
            histogram.BackColor = Color.White;
            histogram.Text = "Show Histogram";
            histogram.SetBounds(Convert.ToInt32(tools.Width * 0.815), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            histogram.Font = font;
            tools.Controls.Add(histogram);

            Button save = new Button();
            save.BackColor = Color.White;
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
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                values.Add(Convert.ToDouble(grid[colNr, i].Value));
            }
            values = Tools.changeRange(values,minNewRange,maxNewRange);
            for (int i = 0; i < grid.Rows.Count - 1; i++)
            {
                grid[grid.ColumnCount - 1, i].Value = values[i];
            }
        }
    }
}

