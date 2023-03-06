
using System;
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
            textToDigits.BackColor = Color.White;
            textToDigits.Text = "Text To Digits";
            textToDigits.SetBounds(Convert.ToInt32(tools.Width * 0.185), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            textToDigits.Font = font;
            tools.Controls.Add(textToDigits);

            Button discretize = new Button();
            discretize.BackColor = Color.White;
            discretize.Text = "Discretize";
            discretize.SetBounds(Convert.ToInt32(tools.Width * 0.275), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            discretize.Font = font;
            tools.Controls.Add(discretize);


            Button standardization = new Button();
            standardization.BackColor = Color.White;
            standardization.Text = "Standardization";
            standardization.SetBounds(Convert.ToInt32(tools.Width * 0.365), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.8));
            standardization.Font = font;
            tools.Controls.Add(standardization);

            Button changeRange = new Button();
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
            DataGridView grid = new DataGridView();
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
            DataGridView grid = new DataGridView();
            grid.SetBounds(0, 0, table.Width, Convert.ToInt32(table.Height * 0.9));
            grid.ColumnCount = data[0].Length;
            for (int i = 0; i < data[0].Length;i++) {
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
            data=Tools.loadFromExcel();
            setTable();
        }

    }
}

