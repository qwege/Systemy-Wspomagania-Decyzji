﻿namespace Systemy_Wspomagania_Decyzji
{
    partial class ModuleTwo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ilośćWymiarówLabel = new System.Windows.Forms.Label();
            this.dlugośćWektoraLabel = new System.Windows.Forms.Label();
            this.ilośćRekordówLabel = new System.Windows.Forms.Label();
            this.PominięteRekordyLabel = new System.Windows.Forms.Label();
            this.closeModuleButton = new System.Windows.Forms.Button();
            this.showVector = new System.Windows.Forms.Button();
            this.zdefiniowaneRekordyLabel = new System.Windows.Forms.Label();
            this.generateOneStepButton = new System.Windows.Forms.Button();
            this.generateToEndButton = new System.Windows.Forms.Button();
            this.chooseClassBox = new System.Windows.Forms.ComboBox();
            this.chooseClassButton = new System.Windows.Forms.Button();
            this.ilośćKlasLabel = new System.Windows.Forms.Label();
            this.resetVectorButton = new System.Windows.Forms.Button();
            this.classifyNewPointButton = new System.Windows.Forms.Button();
            this.draw2D = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ilośćWymiarówLabel
            // 
            this.ilośćWymiarówLabel.AutoSize = true;
            this.ilośćWymiarówLabel.Location = new System.Drawing.Point(101, 50);
            this.ilośćWymiarówLabel.Name = "ilośćWymiarówLabel";
            this.ilośćWymiarówLabel.Size = new System.Drawing.Size(93, 13);
            this.ilośćWymiarówLabel.TabIndex = 1;
            this.ilośćWymiarówLabel.Text = "Ilość Wymiarów: 0";
            // 
            // dlugośćWektoraLabel
            // 
            this.dlugośćWektoraLabel.AutoSize = true;
            this.dlugośćWektoraLabel.Location = new System.Drawing.Point(101, 110);
            this.dlugośćWektoraLabel.Name = "dlugośćWektoraLabel";
            this.dlugośćWektoraLabel.Size = new System.Drawing.Size(104, 13);
            this.dlugośćWektoraLabel.TabIndex = 2;
            this.dlugośćWektoraLabel.Text = "Długość Wektora: 0";
            // 
            // ilośćRekordówLabel
            // 
            this.ilośćRekordówLabel.AutoSize = true;
            this.ilośćRekordówLabel.Location = new System.Drawing.Point(101, 80);
            this.ilośćRekordówLabel.Name = "ilośćRekordówLabel";
            this.ilośćRekordówLabel.Size = new System.Drawing.Size(93, 13);
            this.ilośćRekordówLabel.TabIndex = 3;
            this.ilośćRekordówLabel.Text = "Ilość Rekordów: 0";
            // 
            // PominięteRekordyLabel
            // 
            this.PominięteRekordyLabel.AutoSize = true;
            this.PominięteRekordyLabel.Location = new System.Drawing.Point(101, 140);
            this.PominięteRekordyLabel.Name = "PominięteRekordyLabel";
            this.PominięteRekordyLabel.Size = new System.Drawing.Size(108, 13);
            this.PominięteRekordyLabel.TabIndex = 4;
            this.PominięteRekordyLabel.Text = "Pominięte Rekordy: 0";
            // 
            // closeModuleButton
            // 
            this.closeModuleButton.Location = new System.Drawing.Point(512, 48);
            this.closeModuleButton.Name = "closeModuleButton";
            this.closeModuleButton.Size = new System.Drawing.Size(177, 34);
            this.closeModuleButton.TabIndex = 5;
            this.closeModuleButton.Text = "Close Module";
            this.closeModuleButton.UseVisualStyleBackColor = true;
            this.closeModuleButton.Click += new System.EventHandler(this.closeModuleButton_Click);
            // 
            // showVector
            // 
            this.showVector.Location = new System.Drawing.Point(512, 101);
            this.showVector.Name = "showVector";
            this.showVector.Size = new System.Drawing.Size(177, 34);
            this.showVector.TabIndex = 6;
            this.showVector.Text = "Show Vector";
            this.showVector.UseVisualStyleBackColor = true;
            this.showVector.Click += new System.EventHandler(this.showVector_Click);
            // 
            // zdefiniowaneRekordyLabel
            // 
            this.zdefiniowaneRekordyLabel.AutoSize = true;
            this.zdefiniowaneRekordyLabel.Location = new System.Drawing.Point(101, 170);
            this.zdefiniowaneRekordyLabel.Name = "zdefiniowaneRekordyLabel";
            this.zdefiniowaneRekordyLabel.Size = new System.Drawing.Size(126, 13);
            this.zdefiniowaneRekordyLabel.TabIndex = 7;
            this.zdefiniowaneRekordyLabel.Text = "Zdefiniowane Rekordy: 0";
            // 
            // generateOneStepButton
            // 
            this.generateOneStepButton.Location = new System.Drawing.Point(512, 155);
            this.generateOneStepButton.Name = "generateOneStepButton";
            this.generateOneStepButton.Size = new System.Drawing.Size(177, 34);
            this.generateOneStepButton.TabIndex = 8;
            this.generateOneStepButton.Text = "Generate 1 step";
            this.generateOneStepButton.UseVisualStyleBackColor = true;
            this.generateOneStepButton.Click += new System.EventHandler(this.generateOneStepButton_Click);
            // 
            // generateToEndButton
            // 
            this.generateToEndButton.Location = new System.Drawing.Point(512, 214);
            this.generateToEndButton.Name = "generateToEndButton";
            this.generateToEndButton.Size = new System.Drawing.Size(177, 34);
            this.generateToEndButton.TabIndex = 9;
            this.generateToEndButton.Text = "Generate to end";
            this.generateToEndButton.UseVisualStyleBackColor = true;
            this.generateToEndButton.Click += new System.EventHandler(this.generateToEndButton_Click);
            // 
            // chooseClassBox
            // 
            this.chooseClassBox.FormattingEnabled = true;
            this.chooseClassBox.Location = new System.Drawing.Point(104, 256);
            this.chooseClassBox.Name = "chooseClassBox";
            this.chooseClassBox.Size = new System.Drawing.Size(183, 21);
            this.chooseClassBox.TabIndex = 10;
            // 
            // chooseClassButton
            // 
            this.chooseClassButton.Location = new System.Drawing.Point(104, 300);
            this.chooseClassButton.Name = "chooseClassButton";
            this.chooseClassButton.Size = new System.Drawing.Size(183, 22);
            this.chooseClassButton.TabIndex = 11;
            this.chooseClassButton.Text = "Choose Class Column";
            this.chooseClassButton.UseVisualStyleBackColor = true;
            // 
            // ilośćKlasLabel
            // 
            this.ilośćKlasLabel.AutoSize = true;
            this.ilośćKlasLabel.Location = new System.Drawing.Point(101, 200);
            this.ilośćKlasLabel.Name = "ilośćKlasLabel";
            this.ilośćKlasLabel.Size = new System.Drawing.Size(64, 13);
            this.ilośćKlasLabel.TabIndex = 12;
            this.ilośćKlasLabel.Text = "Ilość Klas: 0";
            // 
            // resetVectorButton
            // 
            this.resetVectorButton.Location = new System.Drawing.Point(512, 271);
            this.resetVectorButton.Name = "resetVectorButton";
            this.resetVectorButton.Size = new System.Drawing.Size(177, 34);
            this.resetVectorButton.TabIndex = 13;
            this.resetVectorButton.Text = "Reset Wector";
            this.resetVectorButton.UseVisualStyleBackColor = true;
            this.resetVectorButton.Click += new System.EventHandler(this.resetVectorButton_Click);
            // 
            // classifyNewPointButton
            // 
            this.classifyNewPointButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.classifyNewPointButton.Location = new System.Drawing.Point(512, 324);
            this.classifyNewPointButton.Name = "classifyNewPointButton";
            this.classifyNewPointButton.Size = new System.Drawing.Size(177, 34);
            this.classifyNewPointButton.TabIndex = 14;
            this.classifyNewPointButton.Text = "Classify new Point";
            this.classifyNewPointButton.UseVisualStyleBackColor = true;
            this.classifyNewPointButton.Click += new System.EventHandler(this.classifyNewPointButton_Click);
            // 
            // draw2D
            // 
            this.draw2D.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.draw2D.Location = new System.Drawing.Point(512, 379);
            this.draw2D.Name = "draw2D";
            this.draw2D.Size = new System.Drawing.Size(177, 34);
            this.draw2D.TabIndex = 15;
            this.draw2D.Text = "Draw2D";
            this.draw2D.UseVisualStyleBackColor = true;
            this.draw2D.Click += new System.EventHandler(this.draw2D_Click);
            // 
            // ModuleTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.draw2D);
            this.Controls.Add(this.classifyNewPointButton);
            this.Controls.Add(this.resetVectorButton);
            this.Controls.Add(this.ilośćKlasLabel);
            this.Controls.Add(this.chooseClassButton);
            this.Controls.Add(this.chooseClassBox);
            this.Controls.Add(this.generateToEndButton);
            this.Controls.Add(this.generateOneStepButton);
            this.Controls.Add(this.zdefiniowaneRekordyLabel);
            this.Controls.Add(this.showVector);
            this.Controls.Add(this.closeModuleButton);
            this.Controls.Add(this.PominięteRekordyLabel);
            this.Controls.Add(this.ilośćRekordówLabel);
            this.Controls.Add(this.dlugośćWektoraLabel);
            this.Controls.Add(this.ilośćWymiarówLabel);
            this.Name = "ModuleTwo";
            this.Text = "Moduł 2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label ilośćWymiarówLabel;
        private System.Windows.Forms.Label dlugośćWektoraLabel;
        private System.Windows.Forms.Label ilośćRekordówLabel;
        private System.Windows.Forms.Label PominięteRekordyLabel;
        private System.Windows.Forms.Button closeModuleButton;
        private System.Windows.Forms.Button showVector;
        private System.Windows.Forms.Label zdefiniowaneRekordyLabel;
        private System.Windows.Forms.Button generateOneStepButton;
        private System.Windows.Forms.Button generateToEndButton;
        private System.Windows.Forms.ComboBox chooseClassBox;
        private System.Windows.Forms.Button chooseClassButton;
        private System.Windows.Forms.Label ilośćKlasLabel;
        private System.Windows.Forms.Button resetVectorButton;
        private System.Windows.Forms.Button classifyNewPointButton;
        private System.Windows.Forms.Button draw2D;
    }
}