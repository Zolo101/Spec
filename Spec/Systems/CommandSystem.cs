using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;
using Thing.Core;
using Spec.Core;

namespace Spec.Systems
{
    public class CommandSystem
    {
        // Return value is true if the player was able to move
        // false when the player couldn't move, such as trying to move into a wall
        public bool MovePlayer(Direction direction)
        {
            int x = Program.Player.X;
            int y = Program.Player.Y;

            switch (direction)
            {
                case Direction.Up:
                    {
                        y = Program.Player.Y - 1;
                        break;
                    }
                case Direction.Down:
                    {
                        y = Program.Player.Y + 1;
                        break;
                    }
                case Direction.Left:
                    {
                        x = Program.Player.X - 1;
                        break;
                    }
                case Direction.Right:
                    {
                        x = Program.Player.X + 1;
                        break;
                    }
                default:
                    {
                        return false;
                    }
            }

            if (Program.WorldMap.SetActorPosition(Program.Player, x, y))
            {
                return true;
            }

            return false;
        }
    }
}
