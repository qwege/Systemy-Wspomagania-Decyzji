using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace Systemy_Wspomagania_Decyzji
{
    internal class Module2Class
    {
        Double[,] fullData;
        List<Record> unassocietedRecords = new List<Record> ();
        List<Record> associetedRecords = new List<Record>();
        List<Record> skippedRecords = new List<Record> ();
        public List<Vector> vector = new List<Vector> ();
        public int uniqueclass = 0;
        public String[] headers;
        public Module2Class(Double[,] data, String[] headers) { 
            this.headers = headers;
            fullData = data;
        }

        
        public void updateClass(int header)
        {
            

            
            Record[] records = new Record[fullData.GetLength(1)];
            for (int i=0;i<records.Length;i++)
            {
                records[i]=new Record();
            }
            for (int i = 0; i < headers.Count(); i++)
            {
                if (headers[header] != headers[i])
                {
                    
                    for (int j = 0; j < records.Length; j++)
                        records[j].values.Add(fullData[i, j]);
           
                }
                else if (headers[header] == headers[i])
                {
                    for (int j = 0; j < records.Length; j++)
                        records[j].classValue = (int)fullData[i, j];
                }
            }
            List<int> uniqueClass = new List<int>();
            foreach (Record r in records) {
                bool uniqie = true;
                for (int j = 0; j < uniqueClass.Count(); j++)
                {
                    if (uniqueClass[j] == r.classValue) uniqie = false;
                }
                if (uniqie) { uniqueClass.Add(r.classValue); }
            }
            unassocietedRecords = new List<Record>();
            associetedRecords = new List<Record>();
            skippedRecords = new List<Record>();

            unassocietedRecords.AddRange(records);
         
            uniqueclass = uniqueClass.Count();
            
        }

        public void resetVector()
        {
            unassocietedRecords.AddRange(associetedRecords);
            unassocietedRecords.AddRange(skippedRecords);
            associetedRecords.Clear();
            skippedRecords.Clear();
            vector = new List<Vector>();
         
        }

        public List<Record> sortArray(List<Record> array, int leftIndex, int rightIndex,int dim)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].values[dim];
            while (i <= j)
            {
                while (array[i].values[dim] < pivot)
                {
                    i++;
                }

                while (array[j].values[dim] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    Record temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                sortArray(array, leftIndex, j,dim);
            if (i < rightIndex)
                sortArray(array, i, rightIndex,dim);
            return array;
        }
        
        public void doStep()
        {
            if (unassocietedRecords.Count == 0)
            {
                MessageBox.Show("Brak Rekordów do przydzielenia");
                return;
            }
            int nrOfDim = unassocietedRecords[0].values.Count(); // zczytanie liczby wymiarów


            int bestVectorCount = 0;
            Vector bestVector = new Vector();

            for (int i = 0; i < nrOfDim; i++) {  //dla każdego wymiaru
                unassocietedRecords = sortArray(unassocietedRecords, 0, unassocietedRecords.Count() - 1, i); //Sortowanie po wymiarze
                int borderClassDown = unassocietedRecords[0].classValue;
                int borderClassUP = unassocietedRecords[unassocietedRecords.Count()-1].classValue;
                int firstDifferentClass = -1;
                int lastDifferentClass = -1;
                for(int x =0; x< unassocietedRecords.Count();x++) // znajduje najblizsza klasę inna niż brzegowa od dołu i zapisuje jej indeks do firstDifferentClass
                {
                    if (unassocietedRecords[x].classValue != borderClassDown) {
                        firstDifferentClass = x;
                        break;
                    }
                }

                for (int x = unassocietedRecords.Count()-1; x > 0; x--) // znajduje najblizsza klasę inna niż brzegowa od góry i zapisuje jej indeks do firstDifferentClass
                {
                    if (unassocietedRecords[x].classValue != borderClassUP)
                    {
                        lastDifferentClass = x;
                        break;
                    }
                }

                //wszystkie w jednej klasie
                if (firstDifferentClass == -1) {
                    bestVectorCount = unassocietedRecords.Count();
                    bestVector = new Vector();
                    bestVector.direction = direction.UP;
                    bestVector.value = Double.MinValue;
                    bestVector.dim = 0;
                    bestVector.classVector = unassocietedRecords[0].classValue;

                    break;
                }


                //zbadanie dolnej granicy
                double limitValueDOWN = unassocietedRecords[firstDifferentClass].values[i];
                double vectorValueDOWN = Double.MinValue;
                int countOfRecordsCanBeAssignedInThisDimDown = 0;
                for (int x = 0; x < firstDifferentClass; x++) {
                    if (unassocietedRecords[x].values[i] < limitValueDOWN) { countOfRecordsCanBeAssignedInThisDimDown++;
                        vectorValueDOWN =( unassocietedRecords[x].values[i] + limitValueDOWN) /2;
                            }
                }
                //zbadanie górnej granicy
                double limitValueUP = unassocietedRecords[lastDifferentClass].values[i];
                double vectorValueUP = Double.MinValue;
                int countOfRecordsCanBeAssignedInThisDimUP = 0;
                for (int x = unassocietedRecords.Count()-1; x > lastDifferentClass; x--)
                {
                    if (unassocietedRecords[x].values[i] < limitValueUP) { countOfRecordsCanBeAssignedInThisDimUP++;
                        vectorValueUP = (unassocietedRecords[x].values[i] + limitValueUP) / 2;
                    }
                }
                // czy dolna granica jest najlepsza 
                if (countOfRecordsCanBeAssignedInThisDimDown > countOfRecordsCanBeAssignedInThisDimUP) {
                    if (countOfRecordsCanBeAssignedInThisDimDown > bestVectorCount) {
                        bestVectorCount = countOfRecordsCanBeAssignedInThisDimDown;
                        bestVector.dim = i;
                        bestVector.value = vectorValueDOWN;
                        bestVector.direction = direction.DOWN;
                        bestVector.classVector = unassocietedRecords[0].classValue;
                    }
                }
                //czy gorna granica jest najlepsza 
                else {
                    if (countOfRecordsCanBeAssignedInThisDimUP > bestVectorCount)
                    {
                        bestVectorCount = countOfRecordsCanBeAssignedInThisDimUP;
                        bestVector.dim = i;
                        bestVector.value = vectorValueUP;
                        bestVector.direction = direction.UP;
                        bestVector.classVector = unassocietedRecords[unassocietedRecords.Count()-1].classValue;
                    }
                }
            }
            //sortowanie po najlepszym wymiarze
            unassocietedRecords = sortArray(unassocietedRecords, 0, unassocietedRecords.Count() - 1, bestVector.dim);
            //oznaczanie jako przydzielone
            if (bestVector.direction == direction.UP)
            {
                for(int i=unassocietedRecords.Count()-1; i>-1; i--)
                {
                    Record temp = unassocietedRecords[unassocietedRecords.Count()-1];
                    unassocietedRecords.Remove(temp);
                    associetedRecords.Add(temp);
                }
            }
            else {
                for (int i = 0; i < bestVectorCount; i++)
                {
                    Record temp = unassocietedRecords[0];
                    unassocietedRecords.Remove(temp);
                    associetedRecords.Add(temp);
                }
            }
            //odświerzanie danych wektora
            foreach (Record r in associetedRecords) {
                if (r.values[bestVector.dim] > bestVector.value) {
                    if (bestVector.direction == direction.UP) { r.valuesForVector.Add(1); }
                    else r.valuesForVector.Add(0);
                }
                else
                {
                    if (bestVector.direction == direction.DOWN) { r.valuesForVector.Add(1); }
                    else r.valuesForVector.Add(0);
                }
            }
            foreach (Record r in unassocietedRecords)
            {
                if (r.values[bestVector.dim] > bestVector.value)
                {
                    if (bestVector.direction == direction.UP) { r.valuesForVector.Add(1); }
                    else r.valuesForVector.Add(0);
                }
                else
                {
                    if (bestVector.direction == direction.DOWN) { r.valuesForVector.Add(1); }
                    else r.valuesForVector.Add(0);
                }
            }
            vector.Add(bestVector);
           
        }

        public void doToEnd()
        {
            for (; ; ) {
                int x = unassocietedRecords.Count();
                if (x == 0) break;
                doStep();
                if (x == unassocietedRecords.Count()) break;
            }
        }

        public int getDim()
        {
            if(unassocietedRecords.Count == 0)
            {
                if (associetedRecords.Count == 0) return -1;
                    return associetedRecords[0].values.Count();
            }
            else return unassocietedRecords[0].values.Count();
        }

        public int getRecords()
        {
            return unassocietedRecords.Count()+associetedRecords.Count()+skippedRecords.Count();
        }

        internal int getSkippedRecords()
        {
            return skippedRecords.Count();
        }

        internal int getDefinedRecords()
        {
           return associetedRecords.Count();
        }

        internal void showVector()
        {

            string[] messageLines = new string[vector.Count()];
            for (int i = 0; i < vector.Count(); i++) {
                messageLines[i] = vector[i].ToString();
            }
           

            MessageBox.Show(string.Join(Environment.NewLine, messageLines));
        }

        public bool algoritmFinished()
        {
            if(getRecords()!=0)
            return unassocietedRecords.Count() == 0;
            return false;
        }
    }
    public class Record()
    {
        public List<int> valuesForVector = new List<int>();
        public int classValue;
        public List<Double> values = new List<Double>();
    }
    public class Vector()
    {
        public int dim;
        public double value;
        public direction direction;
        public int classVector;

        override
        public string ToString() {
            

            return "Wymiar: "+dim+" Wartość: "+value+" Kierunek:"+direction.ToString()+" Klasa: "+classVector;
        }
        
    }
    public enum direction
    {
        UP,DOWN
    }
}
