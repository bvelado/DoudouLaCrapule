using System.Xml.Serialization;

namespace DataLibrary
{
    [XmlRoot("Map")]
    public class Tile
    {
        public int TileIndex;
        public int PositionX;
        public int PositionY;
    }
}
