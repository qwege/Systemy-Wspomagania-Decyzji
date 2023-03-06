
using System;
using System.Drawing;
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
            Button loadTextData = new Button();
            loadTextData.BackColor= Color.White;
            loadTextData.Text = "Load Text Data";
            loadTextData.SetBounds(Convert.ToInt32(tools.Width * 0.02), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(loadTextData);

            Button loadExcelData = new Button();
            loadExcelData.BackColor= Color.White;
            loadExcelData.Text = "Load Excel Data";
            loadExcelData.SetBounds(Convert.ToInt32(tools.Width * 0.115), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(loadExcelData);

            Button TextToDigits = new Button();
            TextToDigits.BackColor= Color.White;
            TextToDigits.Text = "Text To Digits";
            TextToDigits.SetBounds(Convert.ToInt32(tools.Width * 0.21), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(TextToDigits);

            Button Discretize = new Button();
            Discretize.BackColor = Color.White;
            Discretize.Text = "Discretize";
            Discretize.SetBounds(Convert.ToInt32(tools.Width * 0.305), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(Discretize);


            Button Standardization = new Button();
            Standardization.BackColor = Color.White;
            Standardization.Text = "Standardization";
            Standardization.SetBounds(Convert.ToInt32(tools.Width * 0.4), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(Standardization);

            Button ChangeRange = new Button();
            ChangeRange.BackColor = Color.White;
            ChangeRange.Text = "Change Range";
            ChangeRange.SetBounds(Convert.ToInt32(tools.Width * 0.495), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(ChangeRange);

            Button ShowFiltered = new Button();
            ShowFiltered.BackColor = Color.White;
            ShowFiltered.Text = "Show Filtered";
            ShowFiltered.SetBounds(Convert.ToInt32(tools.Width * 0.59), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(ShowFiltered);

            Button Diagram2D = new Button();
            Diagram2D.BackColor = Color.White;
            Diagram2D.Text = "Show 2D Diagram";
            Diagram2D.SetBounds(Convert.ToInt32(tools.Width * 0.685), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(Diagram2D);

            Button Diagram3D = new Button();
            Diagram3D.BackColor = Color.White;
            Diagram3D.Text = "Show 3D Diagram";
            Diagram3D.SetBounds(Convert.ToInt32(tools.Width * 0.78), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(Diagram3D);

            Button Histogram = new Button();
            Histogram.BackColor = Color.White;
            Histogram.Text = "Show Histogram";
            Histogram.SetBounds(Convert.ToInt32(tools.Width * 0.875), Convert.ToInt32(tools.Height * 0.05), Convert.ToInt32(tools.Width * 0.09), Convert.ToInt32(tools.Height * 0.9));
            tools.Controls.Add(Histogram);
        }
        private void intiTable()
        {
            DataGridView grid = new DataGridView();
            grid.SetBounds(0,0,table.Width,Convert.ToInt32(table.Height*0.9));
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
            grid.ScrollBars=ScrollBars.Both;
            table.Controls.Add(grid);
        }
        private void setTable(String[][] data)
        {
            throw new NotImplementedException();
        }

    }
}
