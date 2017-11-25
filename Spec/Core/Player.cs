using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;
using Thing.Core;

namespace Spec.Core
{
    class Player : Actor
    {
        public Player()
        {
            Awareness = 15;
            Name = "Atom";
            Color = Colors.Player;
            Symbol = '@';
            X = 10;
            Y = 10;
        }
    }
}
