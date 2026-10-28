using System.Threading.Tasks.Dataflow;

namespace models
{
    public static class DataConverter
    {
        public static Dictionary<string, Type> Chars = new Dictionary<string, Type>()
        {
            ["[x]"] = typeof(Box),
            ["0_0"] = typeof(Player),
            ["|I|"] = typeof(Wall),
            [" X "] = typeof(Cross),
            ["   "] = typeof(FreeSpace)
        };
    }
    public interface IEntities
    {
        public string Printer { get; }
        public int[] Pos {  get; set; }
    }
    public class Box : IEntities
    {
        public string Printer { get { return "[x]"; } }
        public int[] Pos { get; set; }
    }
    public class Player : IEntities
    {
        public string Printer { get { return "0_0"; } }
        public int[] Pos { get; set; }
    }
    public class Wall : IEntities
    {
        public string Printer { get { return "|I|"; } }
        public int[] Pos { get; set; }
    }
    public class Cross : IEntities
    {
        public string Printer { get { return " X "; } }
        public int[] Pos { get; set; }
    }
    public class FreeSpace : IEntities
    {
        public string Printer { get { return "   "; } }
        public int[] Pos { get; set; }
    }
}
