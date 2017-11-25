using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
using RogueSharp;

namespace Spec.Core
{
    public class MapGenerator
    {
        private readonly int _width;
        private readonly int _height;

        private readonly DungeonMap _map;

        // making a new mapgen needs the dimensions of the maps it will create
        public MapGenerator( int width, int height)
        {
            _width = width;
            _height = height;
            _map = new DungeonMap();
        }

        // generate a new map
        public DungeonMap CreateMap()
        {
            // init every cell in the map by setting walk, transparency and explored to true
            _map.Initialize(_width, _height);
            foreach ( Cell cell in _map.GetAllCells() )
            {
                _map.SetCellProperties(cell.X, cell.Y, true, true, true);
            }

            // set the first and last rows in the map to not be transparent or walk
            foreach (Cell cell in _map.GetCellsInRows(0, _height - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            // set the first and last columns in the map to not be transparent or walk
            foreach (Cell cell in _map.GetCellsInColumns(0, _width - 1))
            {
                _map.SetCellProperties(cell.X, cell.Y, false, false, true);
            }

            return _map;
        }
    }
}
