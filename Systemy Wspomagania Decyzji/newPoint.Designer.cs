namespace Systemy_Wspomagania_Decyzji
{
    partial class newPoint
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
            this.topLabel = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.submit = new System.Windows.Forms.Button();
            this.newPointAssigmentClassLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // topLabel
            // 
            this.topLabel.AutoSize = true;
            this.topLabel.Location = new System.Drawing.Point(51, 40);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(92, 13);
            this.topLabel.TabIndex = 0;
            this.topLabel.Text = "Fill new point data";
            // 
            // dataPanel
            // 
            this.dataPanel.AutoScroll = true;
            this.dataPanel.Location = new System.Drawing.Point(54, 87);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(346, 316);
            this.dataPanel.TabIndex = 1;
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(54, 452);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 2;
            this.submit.Text = "Confirm";
            this.submit.UseVisualStyleBackColor = true;
            // 
            // newPointAssigmentClassLabel
            // 
            this.newPointAssigmentClassLabel.AutoSize = true;
            this.newPointAssigmentClassLabel.Location = new System.Drawing.Point(173, 461);
            this.newPointAssigmentClassLabel.Name = "newPointAssigmentClassLabel";
            this.newPointAssigmentClassLabel.Size = new System.Drawing.Size(0, 13);
            this.newPointAssigmentClassLabel.TabIndex = 3;
            // 
            // newPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 498);
            this.Controls.Add(this.newPointAssigmentClassLabel);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.topLabel);
            this.Name = "newPoint";
            this.Text = "New Point";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label newPointAssigmentClassLabel;
    }
}