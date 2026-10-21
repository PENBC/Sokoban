namespace models
{
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
}
