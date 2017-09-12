using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataLibrary
{
    public class Map
    {
        public int MapColumns;
        public int MapRows;
        public int TileWidth;
        public int TileHeight;
        public string TilesetPath;
        public int TilesetColumns;
        public int TilesetRows;
        
        public Tile[] Tiles;
    }
}
