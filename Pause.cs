using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardWar {
    public partial class Pause : Form {
        public Pause() {
            InitializeComponent();
        }

        private void buExit_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Abort;
            this.Close();
        }

        private void buResume_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Retry;
            this.Close();
        }

        private void Pause_Load(object sender, EventArgs e) {
            this.Left = CardWar.frMain.ActiveForm.Left + (frMain.ActiveForm.Width/2-this.Width/2);
            this.Top = frMain.ActiveForm.Top + (frMain.ActiveForm.Height / 2 - this.Height / 2);
        }
    }
}
