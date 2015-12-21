using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KpoVaja01
{
    class Player
    {
        public int SetPositionX(int posX, int posAngle)
        {
            if ((posAngle == 90) || (posAngle == -270))
            {
                posX = posX + 3;
            }
            else if ((posAngle == 270) || (posAngle == -90))
            {
                posX = posX - 3;
            }

            return posX;
        }

        public int SetPositionY(int posY, int posAngle)
        {
            if (posAngle == 0)
            {
                posY = posY - 3;
            }
            else if ((posAngle == 180) || (posAngle == -180))
            {
                posY = posY + 3;
            }

            return posY;
        }

        public bool CheckBorders(List<Tuple<int, int>> listTup, Tuple<int, int> tup, int height, int width)
        {
            int index = listTup.FindIndex(t => t.Item1 == tup.Item1 && t.Item2 == tup.Item2);

            if ((index != -1) || (tup.Item1 < 0) || (tup.Item1 > width) || (tup.Item2 > height) || (tup.Item2 < 0))
            {
                return true;
            }

            return false;
        }
    }
}
