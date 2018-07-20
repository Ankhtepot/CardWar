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
    public partial class Options : Form {
        public Options() {
            InitializeComponent();
        }
        private int speed;
        private int waiting;
        private int rounds;
        const int WM = 250; //Waiting Multiplier
        const int SM = 5; //Speed Multiplier
        

        private void Options_Load(object sender, EventArgs e) {
            speed = CardDeck.Settings.Speed;
            waiting = frMain.Settings.waitTime;
            rounds = frMain.Settings.MaxRounds;
            trbSpeed.Value = speed / SM;
            trbWaiting.Value = waiting/WM;
            trbRounds.Value = rounds;
            lbSpeed.Text = speed.ToString();
            lbWaiting.Text = waiting.ToString();
            lbRounds.Text = rounds.ToString();
        }

        private void trbRounds_Scroll(object sender, EventArgs e) {
            lbRounds.Text = trbRounds.Value.ToString();
        }

        private void trbSpeed_Scroll(object sender, EventArgs e) {
            lbSpeed.Text = (trbSpeed.Value * SM).ToString();
        }

        private void trbWaiting_Scroll(object sender, EventArgs e) {
            lbWaiting.Text = (trbWaiting.Value * WM).ToString();
        }

        private void buOK_Click(object sender, EventArgs e) {
            CardDeck.Settings.Speed = trbSpeed.Value*SM;
            frMain.Settings.MaxRounds = trbRounds.Value;
            frMain.Settings.waitTime = trbWaiting.Value*WM;            
            this.Close();
        }

        private void buCancel_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
