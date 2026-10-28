using Board;
internal class Programm
{
    //public void Draw()
    public static void Main( string[] args )
    {
        string a = File.ReadAllText("C://Users/Admin/sokoban/saves/lvl1.txt");
        Space level = new Space();
        string[] lines = a.Split("\r\n");
        for(int i = 0; i < lines.Length; i++)
        {
            string[] printers = lines[i].Split(",");
            for (int j = 0; j < printers.Length; j++)
            {
                int[] pos = {i, j};
                level.FillBoard(printers[j], pos);
            }
        }
        Console.WriteLine(a);
    }
}
