namespace Board
{
    using models;
    public class Board
    {
        public Dictionary<int[], IEntities> desk = new Dictionary<int[], IEntities>();
        private static Player player;
        public Player GetPlayer()
        {
            if (player == null)
                player = new Player();
            return player;
        }
        public void FillBoard(List<IEntities> filllist)
        {
            foreach (var entity in filllist)
            {
                if (entity.Printer == "0_0")
                {
                    GetPlayer();
                    player.Pos = entity.Pos;
                }
                desk.Add(entity.Pos, entity);
            }
        }
        private bool PushBox(IEntities box, int[] move)
        {
            int[] newpos = { box.Pos[0] +move[0], box.Pos[1] +move[1] };
            if (!desk.ContainsKey(newpos))
            {
                desk[box.Pos] = null;
                desk.Add(newpos, box);
                return true;
            }
            return false;
        }
        public bool PlayerMove(int[] move)
        {
            int[] newpos = { player.Pos[0] + move[0], player.Pos[1] + move[1] };
            if(!desk.ContainsKey(newpos))
            {
                player.Pos = newpos;
                desk[player.Pos] = null;
                desk.Add(newpos, player);
                return true;
            }
            if (desk[newpos].Printer == "[x]")
            {
                if(PushBox(desk[newpos], move))
                {
                    PlayerMove(move);
                    return true;
                }
                return false;
            }
            return false;
        }
        public IEntities GetEntity(string)
        {

        }
    }
}
