using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace KpoVaja01
{
    public partial class MainGameScreen : Form
    {
        private Game game;
        private int greenPoints = 0;
        private int bluePoints = 0;

        public int GreenPoints
        {
            get { return greenPoints; }
            set { greenPoints = value; }
        }

        public int BluePoints
        {
            get { return bluePoints; }
            set { bluePoints = value; }
        }

        public MainGameScreen()
        {
            InitializeComponent();
            GreenPlayer.BackColor = Color.Transparent;
            BluePlayer.BackColor = Color.Transparent;

            game = new Game();

            WelcomeScreen ws = new WelcomeScreen();
            ws.Show();
            ws.FormClosed += new FormClosedEventHandler(WelcomeScreenFormClosed);
        }

        void WelcomeScreenFormClosed(object sender, FormClosedEventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            DoubleBuffered = true;

            game = new Game(screenHeight, screenWidth);
            GreenPlayer.Text = "Zelen igralec: " + this.greenPoints;
            BluePlayer.Text = "Moder igralec: " + this.bluePoints;

            var thread = new Thread(() => game.Run(this));
            thread.Start();
        }

        /// <summary>
        /// Metoda za barvanje poti.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;

            foreach (var t in game.GreenPaths)
            {
                g.FillRectangle(Brushes.Green, new Rectangle(t.Item1, t.Item2, 3, 3));
            }

            foreach (var t in game.BluePaths)
            {
                g.FillRectangle(Brushes.Blue, new Rectangle(t.Item1, t.Item2, 3, 3));
            }
        }

        /// <summary>
        /// Metoda za dolocanje pozicije zelenega in modrega igralca.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    game.GreenAngle -= 90;
                    if (game.GreenAngle % 360 == 0)
                    {
                        game.GreenAngle = 0;
                    }
                    break;
                case Keys.D:
                    game.GreenAngle += 90;
                    if (game.GreenAngle % 360 == 0)
                    {
                        game.GreenAngle = 0;
                    }
                    break;
                case Keys.Left:
                    game.BlueAngle -= 90;
                    if (game.BlueAngle % 360 == 0)
                    {
                        game.BlueAngle = 0;
                    }
                    break;
                case Keys.Right:
                    game.BlueAngle += 90;
                    if (game.BlueAngle % 360 == 0)
                    {
                        game.BlueAngle = 0;
                    }
                    break;
                case Keys.Escape:
                    game.State = true;
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        public void NewGame(string message)
        {
            DialogResult dialogResult = MessageBox.Show(message, "Igra je zakljucena!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Initialize();
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Exit();
            }
        }

        public void RefreshMethod()
        {
            this.Refresh();
        }

        private void MainGameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.State = true;
        }
    }
}