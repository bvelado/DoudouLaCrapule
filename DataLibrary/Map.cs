using System.Collections.Generic;
using System.Xml.Serialization;

namespace DataLibrary
{
    public class Map
    {
        public int MapWidth;
        public int MapHeight;
        public int TileWidth;
        public int TileHeight;
        public string TileSetPath;

        [XmlArray("Tiles"), XmlArrayItem(typeof(Tile), ElementName = "Tile")]
        public List<Tile> Tiles;
    }
}
