using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Systemy_Wspomagania_Decyzji
{
    public partial class Form2 : Form
    {
        public TextBox numberOfDyscretize;
        public TextBox changeRangemin;
        public TextBox changeRangemax;
        public TextBox percent;
        public ComboBox percentOf;
        public ComboBox selectColumn1;
        public ComboBox selectColumn2;
        public ZedGraphControl zedGraphControl;
        public Form2()
        {
            InitializeComponent();
        }
    }
    public class DrawPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)

        {

            base.OnPaint(e);

        }
    }
}
