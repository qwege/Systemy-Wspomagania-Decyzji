using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Systemy_Wspomagania_Decyzji
{
    public partial class newPoint : Form
    {
        TextBox[] datas;
        List<String> h;
        List<Vector> vectors;
        int classNumber;
        public newPoint(String[] headers, List<Vector> vector, int numberOfClass)
        {
            h = headers.ToList();
            vectors = vector;
            classNumber = numberOfClass;
            InitializeComponent();
            h.RemoveAt(numberOfClass);
            dataPanel.AutoScrollMinSize = new Size(h.Count() * 50 + 160, 300);
            datas = new TextBox[h.Count()];
            for (int i = 0; i < h.Count(); i++)
            {

                Label lbl = new Label();
                lbl.Text = h[i];
                lbl.SetBounds(30, 50 * i + 30, 50, 30);
                dataPanel.Controls.Add(lbl);
                datas[i] = new TextBox();
                datas[i].SetBounds(100, 50 * i + 30, 100, 30);
                dataPanel.Controls.Add(datas[i]);
            }
            submit.Click += AssignClass;
        }

        private void AssignClass(object sender, EventArgs e)
        {
            Record r = new Record();

            for (int i = 0; i < datas.Length; i++)
            {
                Double b;
                if (Double.TryParse(datas[i].Text, out b))
                {

                    r.values.Add(b);
                }
                else
                {
                    MessageBox.Show(h[i] + " isn`t Number");
                    return;
                }
            }
            for (int i = 0; i < vectors.Count; i++)
            {
                if (r.values[vectors[i].dim] > vectors[i].value && vectors[i].direction == direction.UP) r.valuesForVector.Add(1);
                else if (r.values[vectors[i].dim] < vectors[i].value && vectors[i].direction == direction.UP) r.valuesForVector.Add(0);
                else if (r.values[vectors[i].dim] < vectors[i].value && vectors[i].direction == direction.DOWN) r.valuesForVector.Add(1);
                else if (r.values[vectors[i].dim] > vectors[i].value && vectors[i].direction == direction.DOWN) r.valuesForVector.Add(0);
            }
            for (int i = 0; i < r.valuesForVector.Count; i++)
            {
                if (r.valuesForVector[i] == 1)
                {
                    r.classValue = vectors[i].classVector;
                    break;
                }
            }
            newPointAssigmentClassLabel.Text = "New point is class: " + r.classValue;

        }
    }
        
}
