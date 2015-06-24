using System;
using System.Windows.Forms;

namespace ProjectEuler.UI.WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            var startTime = DateTime.Now;
            var problem11 = new Business.Problem11();
            var answer = problem11.Solve();
            var stopTime = DateTime.Now;
            var duration = stopTime - startTime;
            lblAnswer1.Text = string.Format("The greatest product of 4 entries, is {0}", answer);
            lblAnswer2.Text = string.Format("Solution took {0} ms", duration.TotalMilliseconds);
        }
    }
}