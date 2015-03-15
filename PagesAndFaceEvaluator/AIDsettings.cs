using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagesAndFaceEvaluator
{
    public partial class AIDsettings : Form
    {
        public AIDsettings()
        {
            InitializeComponent();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            if (aidTextBox.Text != "" || aidTextBox.Text != null)
                ConfigHelper.ChangeValue(ConfigHelper.ConfigKey.AID.ToString(), aidTextBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
