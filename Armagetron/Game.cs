using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace KpoVaja01
{
    class Game
    {
        // Nastavitve igre.
        private Player player;
        private bool state;
        private int screenHeight;
        private int screenWidth;

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

        public Game()
        {
            this.greenPaths = new List<Tuple<int, int>>();
            this.bluePaths = new List<Tuple<int, int>>();
        }

        public Game(int height, int width)
        {
            // Inicializacija začeznim pozicij za oba igralca.
            this.greenX = width / 2 - 105;
            this.greenY = height / 2 + 4;
            this.blueX = width / 2 + 105;
            this.blueY = height / 2 + 4;

            this.greenAngle = 0;
            this.blueAngle = 0;
            this.state = false;
            this.greenPaths = new List<Tuple<int, int>>();
            this.bluePaths = new List<Tuple<int, int>>();
            this.screenHeight = height;
            this.screenWidth = width;
            this.player = new Player();
        }

        /// <summary>
        /// Glavna zanke igre, kjer se dodajajo nove poti in preverja stanje igre.
        /// </summary>
        /// <param name="sender"></param>
        public void Run(MainGameScreen sender)
        {
            while (!this.state)
            {
                this.greenX = player.SetPositionX(this.greenX, this.greenAngle);
                this.greenY = player.SetPositionY(this.greenY, this.greenAngle);
                this.blueX = player.SetPositionX(this.blueX, this.blueAngle);
                this.blueY = player.SetPositionY(this.blueY, this.blueAngle);

                this.greenPaths.Add(new Tuple<int, int>(this.greenX, this.greenY));
                this.bluePaths.Add(new Tuple<int, int>(this.blueX, this.blueY));

                if ((this.greenX == this.blueX) && (this.greenY == this.blueY))
                {
                    this.state = true;
                    sender.NewGame("Rezultat igre je neodlocen.\nAli zelite igrati novo igro?");
                    break;
                }

                if (player.CheckBorders(this.bluePaths, new Tuple<int, int>(this.greenX, this.greenY), this.screenHeight, this.screenWidth))
                {
                    this.state = true;
                    sender.BluePoints++;
                    sender.NewGame("Zmagal je moder igralec.\nAli zelite igrati novo igro?");
                    break;
                }

                if (player.CheckBorders(this.greenPaths, new Tuple<int, int>(this.blueX, this.blueY), this.screenHeight, this.screenWidth))
                {
                    this.state = true;
                    sender.GreenPoints++;
                    sender.NewGame("Zmagal je zelen igralec.\nAli zelite igrati novo igro?");
                    break;
                }

                sender.RefreshMethod();
                Thread.Sleep(1);
            }
        }
    }
}
