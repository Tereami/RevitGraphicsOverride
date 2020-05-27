namespace RevitGraphicsOverride
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonAllProject = new System.Windows.Forms.RadioButton();
            this.radioButtonCurrentVIew = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxSelectElements = new System.Windows.Forms.CheckBox();
            this.checkBoxShowResults = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonCurrentVIew);
            this.groupBox1.Controls.Add(this.radioButtonAllProject);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Поиск переопределенных элементов:";
            // 
            // radioButtonAllProject
            // 
            this.radioButtonAllProject.AutoSize = true;
            this.radioButtonAllProject.Location = new System.Drawing.Point(8, 42);
            this.radioButtonAllProject.Name = "radioButtonAllProject";
            this.radioButtonAllProject.Size = new System.Drawing.Size(116, 17);
            this.radioButtonAllProject.TabIndex = 0;
            this.radioButtonAllProject.Text = "По всему проекту";
            this.radioButtonAllProject.UseVisualStyleBackColor = true;
            // 
            // radioButtonCurrentVIew
            // 
            this.radioButtonCurrentVIew.AutoSize = true;
            this.radioButtonCurrentVIew.Checked = true;
            this.radioButtonCurrentVIew.Location = new System.Drawing.Point(6, 19);
            this.radioButtonCurrentVIew.Name = "radioButtonCurrentVIew";
            this.radioButtonCurrentVIew.Size = new System.Drawing.Size(118, 17);
            this.radioButtonCurrentVIew.TabIndex = 1;
            this.radioButtonCurrentVIew.TabStop = true;
            this.radioButtonCurrentVIew.Text = "По текущему виду";
            this.radioButtonCurrentVIew.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.checkBoxShowResults);
            this.groupBox2.Controls.Add(this.checkBoxSelectElements);
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "После поиска:";
            // 
            // checkBoxSelectElements
            // 
            this.checkBoxSelectElements.AutoSize = true;
            this.checkBoxSelectElements.Checked = true;
            this.checkBoxSelectElements.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSelectElements.Location = new System.Drawing.Point(6, 19);
            this.checkBoxSelectElements.Name = "checkBoxSelectElements";
            this.checkBoxSelectElements.Size = new System.Drawing.Size(130, 17);
            this.checkBoxSelectElements.TabIndex = 0;
            this.checkBoxSelectElements.Text = "Выделить элементы";
            this.checkBoxSelectElements.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowResults
            // 
            this.checkBoxShowResults.AutoSize = true;
            this.checkBoxShowResults.Location = new System.Drawing.Point(6, 42);
            this.checkBoxShowResults.Name = "checkBoxShowResults";
            this.checkBoxShowResults.Size = new System.Drawing.Size(100, 17);
            this.checkBoxShowResults.TabIndex = 0;
            this.checkBoxShowResults.Text = "Вывести отчёт";
            this.checkBoxShowResults.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(12, 174);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.Location = new System.Drawing.Point(165, 174);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "Далее";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 209);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Шаг 1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonCurrentVIew;
        private System.Windows.Forms.RadioButton radioButtonAllProject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxShowResults;
        private System.Windows.Forms.CheckBox checkBoxSelectElements;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
    }
}