using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Systemy_Wspomagania_Decyzji
{
    public partial class ModuleTwo : Form
    {
        Double[,] data;
        double[] classData;
        int classCount = 0, skippedRecords = 0, definedRecords = 0;
        string[] headers;
        Form f;
        List<List<double>> currentData;
        List<PartOfVector> vector = new List<PartOfVector>();
        public ModuleTwo(Double[,] data, String[] headers)
        {
            InitializeComponent();
            this.data = data;
            this.headers = headers;
            for (int i = 0; i < headers.Count(); i++)
            {
                chooseClassBox.Items.Add(headers[i]);
            }
            chooseClassButton.Click += updateClass;
            chooseClassBox.SelectedIndex = 0;
            classifyNewPointButton.Enabled = false;
            updateLabels();


        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            f.Close();
        }

        private void updateClass(object sender, EventArgs e)
        {
            classData = new double[data.GetLength(1)];
            currentData = new List<List<double>>();
            for (int i = 0; i < headers.Count(); i++)
            {
                if (chooseClassBox.SelectedIndex != i)
                {
                    List<double> d = new List<double>();
                    for (int j = 0; j < data.GetLength(1); j++)
                        d.Add(data[i, j]);
                    currentData.Add(d);
                }
                else if (chooseClassBox.SelectedIndex == i)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                        classData[j] = data[i, j];
                }
            }
            
              currentData.Add(classData.ToList());
            
            List<double> uniqueClass = new List<double>();
            for (int i = 0; i < classData.Length; i++)
            {
                bool uniqie = true;
                for (int j = 0; j < uniqueClass.Count(); j++)
                {
                    if (uniqueClass[j] == classData[i]) uniqie = false;
                }
                if (uniqie) { uniqueClass.Add(classData[i]); }
            }
            classCount = uniqueClass.Count();
            updateLabels();


        }

        private void updateLabels()
        {
            ilośćWymiarówLabel.Text = "Ilość Wymiarów: " + (data.GetLength(0) - 1);
            ilośćRekordówLabel.Text = "Ilość Rekordów: " + data.GetLength(1);
            ilośćKlasLabel.Text = "Ilość Klas: " + classCount;
            dlugośćWektoraLabel.Text = "Długość Wektora: " + vector.Count();
            PominięteRekordyLabel.Text = "Pominięte Rekordy: " + skippedRecords;
            zdefiniowaneRekordyLabel.Text = "Zdefiniowane Rekordy: " + definedRecords;
        }

        private void closeModuleButton_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Hide();
            this.Dispose();
        }

        private void resetVectorButton_Click(object sender, EventArgs e)
        {
            vector = new List<PartOfVector>();
            updateClass(sender, e);
            definedRecords = 0;
            skippedRecords = 0;
        }

        private void generateOneStepButton_Click(object sender, EventArgs e)
        {
            doOneStep();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Return 1 - not End , Return 0 - End
        /// </returns>
        private int doOneStep()
        {
            if (currentData == null) updateClass(null, null);
            int maxPoint = 0;
            bool up = true;
            int dim = 0;
            if (currentData.Count == 0) return 0;
            if (currentData[0].Count == 1) return 0;
            for (int i = 0; i < currentData.Count; i++)
            {
                // po każdym wymiarze --- wymiar = i
                currentData = SortArray(currentData, 0, currentData[0].Count() - 1, i);
                // posortowana tablica rosnaco według wymiaru i
                int z1 = 0;
                double classValue1 = currentData[currentData.Count() - 1][0];
                //przypisanie prostej w kierunku up
                for (; ; )
                {
                    try
                    {

                        if (currentData[currentData.Count() - 1][z1 + 1] == classValue1)
                        {
                            if (!isTheSameClass(z1 + 1, 1, i)) { break; }
                            z1++;


                        }
                        else { break; }
                    }
                    catch { break; }
                }

                if (z1 > maxPoint)
                {
                    maxPoint = z1;
                    up = true;
                    dim = i;
                }
                int z2 = 0;
                double classValue2 = currentData[currentData.Count() - 1][0];

                //przypisanie prostej w kieunku down
                for (; ; )
                {
                    try
                    {

                        if (currentData[currentData.Count() - 1][z2 + 1] == classValue1)
                        {
                            if (!isTheSameClass(z2 + 1, -1, i)) { break; }
                            z2++;


                        }
                        else { break; }
                    }
                    catch { break; }
                }
                if (z2 > maxPoint)
                {
                    maxPoint = z2;
                    up = false;
                    dim = i;
                }
            }
            // generate Part Of Vector
            currentData = SortArray(currentData, 0, currentData[0].Count() - 1, dim);
            PartOfVector partOfVector = new PartOfVector();
            partOfVector.upper = up;
            partOfVector.dimension = dim;
            if (up)
            {
                partOfVector.positionOfClass = currentData[currentData.Count - 1][0];
                try
                {
                    partOfVector.value = currentData[currentData.Count() - 1][0 + maxPoint] + currentData[currentData.Count() - 1][1 + maxPoint];
                }
                catch
                {
                    partOfVector.value = currentData[currentData.Count() - 1][0 + maxPoint] + 0.01;
                }
            }
            else
            {
                partOfVector.positionOfClass = currentData[currentData.Count - 1][currentData[currentData.Count - 1].Count-1];
                try
                {
                    partOfVector.value = currentData[currentData.Count() - 1][currentData[currentData.Count - 1].Count - maxPoint] + currentData[currentData.Count() - 1][currentData[currentData.Count - 1].Count - maxPoint - 1];
                }
                catch
                {
                    partOfVector.value = currentData[currentData.Count() - 1][currentData[currentData.Count - 1].Count - maxPoint] - 0.01;
                }
            }
            // remove assigment points
            for (int i = 0; i < currentData.Count; i++)
            {
                for (int j = 0; j < maxPoint; j++)
                {   
                    if (up)
                    currentData[i].RemoveAt(0);
                    else
                        currentData[i].RemoveAt(currentData[i].Count-1);
                }
            }
            definedRecords += maxPoint;
            return 1;
        }

        public void onClose(Form f)
        {
            this.f = f;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public List<List<double>> SortArray(List<List<double>> array, int leftIndex, int rightIndex, int positionOfList)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[positionOfList][leftIndex];
            while (i <= j)
            {
                while (array[positionOfList][i] < pivot)
                {
                    i++;
                }

                while (array[positionOfList][j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    for (int k = 0; k < array.Count; k++)
                    {
                        double temp = array[k][i];
                        array[k][i] = array[k][j];
                        array[k][j] = temp;
                    }

                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j, positionOfList);
            if (i < rightIndex)
                SortArray(array, i, rightIndex, positionOfList);
            return array;
        }
        //z - obecny indeks vector -1,1 rośnie maleje i- wymiar
        private bool isTheSameClass(int z, int vector, int i)
        {
            try
            {
                if (currentData[i][z + vector] == currentData[i][z])
                {
                    if (currentData[currentData.Count() - 1][z + vector] == currentData[currentData.Count() - 1][z])
                    {
                        return isTheSameClass(z + vector, vector, i);
                    }
                    else return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e) { return true; }

        }
    }
    public class PartOfVector
    {
        public double value;
        public int dimension;
        public bool upper;
        public double positionOfClass;



    }
}
