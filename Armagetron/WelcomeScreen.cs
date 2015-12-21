using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KpoVaja01
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            this.TopMost = true;
            this.BringToFront();

            NavodilaTxt.BackColor = Color.Transparent;
            GreenKonTxt.BackColor = Color.Transparent;
            BlueKonTxt.BackColor = Color.Transparent;
            SpaceTxt.BackColor = Color.Transparent;

            pictureBoxA.BackColor = Color.Transparent;
            pictureBoxD.BackColor = Color.Transparent;
            pictureBoxLeft.BackColor = Color.Transparent;
            pictureBoxRight.BackColor = Color.Transparent;
        }

        private void WelcomeScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                this.Close();
        }

        private void WelcomeScreen_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }
    }
}
