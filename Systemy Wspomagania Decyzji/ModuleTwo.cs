﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Systemy_Wspomagania_Decyzji
{
    public partial class ModuleTwo : Form
    {
        Module2Class module;
       
        Form f;
        public ModuleTwo(Double[,] data, String[] headers)
        {
            InitializeComponent();
            module = new Module2Class(data, headers);
            for (int i = 0; i < headers.Count(); i++)
            {
                chooseClassBox.Items.Add(headers[i]);
            }
            chooseClassButton.Click += updateClass;
            chooseClassBox.SelectedIndex = 0;
            updateLabels();


        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            f.Close();
        }

        private void updateClass(object sender, EventArgs e)
        {
            module.updateClass(chooseClassBox.SelectedIndex);
            updateLabels();


        }

        private void updateLabels()
        {
            ilośćWymiarówLabel.Text = "Ilość Wymiarów: " + module.getDim() ;
            ilośćRekordówLabel.Text = "Ilość Rekordów: " + module.getRecords();
            ilośćKlasLabel.Text = "Ilość Klas: " + module.uniqueclass;
            dlugośćWektoraLabel.Text = "Długość Wektora: " + module.vector.Count();
            PominięteRekordyLabel.Text = "Pominięte Rekordy: " + module.getSkippedRecords();
            zdefiniowaneRekordyLabel.Text = "Zdefiniowane Rekordy: " + module.getDefinedRecords();
            if(module.algoritmFinished()) classifyNewPointButton.Enabled = true;
            else classifyNewPointButton.Enabled = false;
        }

        private void closeModuleButton_Click(object sender, EventArgs e)
        {
            f.Show();
            this.Hide();
            this.Dispose();
        }

        private void resetVectorButton_Click(object sender, EventArgs e)
        {
            module.resetVector();
            updateLabels();
        }

        private void generateOneStepButton_Click(object sender, EventArgs e)
        {
            module.doStep();
            updateLabels();
        }

        
        
        public void onClose(Form f)
        {
            this.f = f;
        }

        private void generateToEndButton_Click(object sender, EventArgs e)
        {
            module.doToEnd();
            updateLabels();
        }

        private void showVector_Click(object sender, EventArgs e)
        {
            var thread = new Thread(() =>
            {
               module.showVector();
                });
            thread.Start();
        }

        private void classifyNewPointButton_Click(object sender, EventArgs e)
        {
            newPoint n = new newPoint(module.headers, module.vector,chooseClassBox.SelectedIndex);
            n.Visible = true;
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
