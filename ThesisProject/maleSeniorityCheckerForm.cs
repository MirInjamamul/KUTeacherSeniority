using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThesisProject
{
    public partial class maleSeniorityCheckerForm : Form
    {
        private String gender;
        public maleSeniorityCheckerForm(String gender)
        {
            this.gender = gender;
            InitializeComponent();
        }

        private void maleSeniorityCheckerForm_Load(object sender, EventArgs e)
        {
            label1.Text = gender;
        }
    }
}
