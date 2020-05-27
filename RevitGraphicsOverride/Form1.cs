using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitGraphicsOverride
{
    public partial class Form1 : Form
    {
        public bool searchAllProject = false;
        public bool selectElems = true;
        public bool showResults = false;

        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = buttonOk;
            this.CancelButton = buttonCancel;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            searchAllProject = radioButtonAllProject.Checked;
            selectElems = checkBoxSelectElements.Checked;
            showResults = checkBoxShowResults.Checked;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
