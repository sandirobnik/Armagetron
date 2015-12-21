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
    public partial class Form1 : Form
    {
        // Nastavitve igre.
        private bool state;

        // Nastavitve za zelenega igralca.
        private int greenX;
        private int greenY;
        private int greenAngle;
        private List<Tuple<int, int>> greenPaths;

        // Nastavitve za modrega igralca.
        private int blueX;
        private int blueY;
        private int blueAngle;
        private List<Tuple<int, int>> bluePaths;

        public bool State
        {
            get { return state; }
            set { state = value; }
        }

        public int GreenX
        {
            get { return greenX; }
            set { greenX = value; }
        }

        public int GreenY
        {
            get { return greenY; }
            set { greenY = value; }
        }

        public int GreenAngle
        {
            get { return greenAngle; }
            set { greenAngle = value; }
        }

        public List<Tuple<int, int>> GreenPaths
        {
            get { return greenPaths; }
            set { greenPaths = value; }
        }

        public int BlueX
        {
            get { return blueX; }
            set { blueX = value; }
        }

        public int BlueY
        {
            get { return blueY; }
            set { blueY = value; }
        }

        public int BlueAngle
        {
            get { return blueAngle; }
            set { blueAngle = value; }
        }

        public List<Tuple<int, int>> BluePaths
        {
            get { return bluePaths; }
            set { bluePaths = value; }
        }

        public Form1()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            // Inicializacija začeznim pozicij za oba igralca.
            greenX = Screen.PrimaryScreen.Bounds.Width / 2 - 105;
            greenY = Screen.PrimaryScreen.Bounds.Height / 2 + 4;
            blueX = Screen.PrimaryScreen.Bounds.Width / 2 + 105;
            blueY = Screen.PrimaryScreen.Bounds.Height / 2 + 4;

            greenAngle = 0;
            blueAngle = 0;
            greenPaths = new List<Tuple<int, int>>();
            bluePaths = new List<Tuple<int, int>>();
            state = false;

            var thread = new Thread(Run);
            thread.Start();

            DoubleBuffered = true;
        }

        // Metoda za barvanje poti.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            foreach (var t in greenPaths)
            {
                g.FillEllipse(Brushes.Green, t.Item1, t.Item2, 15, 15);
            }

            foreach (var t in bluePaths)
            {
                g.FillEllipse(Brushes.Blue, t.Item1, t.Item2, 15, 15);
            }
        }

        private void Run()
        {
            // Glavna zanke igre, kjer se dodajajo nove poti in preverja stanje igre.
            Game game = new Game();
            while (!state)
            {
                this.greenX = game.SetPositionX(greenX, greenAngle);
                this.greenY = game.SetPositionY(greenY, greenAngle);
                this.blueX = game.SetPositionX(blueX, blueAngle);
                this.blueY = game.SetPositionY(blueY, blueAngle);

                greenPaths.Add(new Tuple<int, int>(greenX, greenY));
                bluePaths.Add(new Tuple<int, int>(blueX, blueY));

                if ((greenX == blueX) && (greenY == blueY))
                {
                    state = true;
                    NewGame("Rezultat igre je neodlocen.\nAli zelite igrati novo igro?");
                    break;
                }

                GreenCheckBorders(new Tuple<int, int>(greenX, greenY));

                BlueCheckBorders(new Tuple<int, int>(blueX, blueY));

                this.Refresh();
                Thread.Sleep(200);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Dolocanje pozicije zelenega in modrega igralca.
            switch (e.KeyCode)
            {
                case Keys.A:
                    greenAngle -= 90;
                    if (greenAngle % 360 == 0)
                    {
                        greenAngle = 0;
                    }
                    break;
                case Keys.S:
                    greenAngle += 90;
                    if (greenAngle % 360 == 0)
                    {
                        greenAngle = 0;
                    }
                    break;
                case Keys.Left:
                    blueAngle -= 90;
                    if (blueAngle % 360 == 0)
                    {
                        blueAngle = 0;
                    }
                    break;
                case Keys.Right:
                    blueAngle += 90;
                    if (blueAngle % 360 == 0)
                    {
                        blueAngle = 0;
                    }
                    break;
                case Keys.Escape:
                    state = true;
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }

        private void GreenCheckBorders(Tuple<int, int> tup)
        {
            // Preverjanje mej za zelenega igralca.
            int index = bluePaths.FindIndex(t => t.Item1 == tup.Item1 && t.Item2 == tup.Item2);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            if ((index != -1) || (greenY < 0) || (greenX > width) || (greenY > height) || (greenX < 0))
            {
                state = true;
                NewGame("Zmagal je moder igralec.\nAli zelite igrati novo igro?");
            }
        }

        private void BlueCheckBorders(Tuple<int, int> tup)
        {
            // Preverjanje mej za modrega igralca.
            int index = greenPaths.FindIndex(t => t.Item1 == tup.Item1 && t.Item2 == tup.Item2);
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;

            if ((index != -1) || (blueY < 0) || (blueX > width) || (blueY > height) || (blueX < 0))
            {
                state = true;
                NewGame("Zmagal je zelen igralec.\nAli zelite igrati novo igro?");
            }
        }

        private void NewGame(string message)
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
    }
}