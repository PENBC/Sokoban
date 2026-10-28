namespace Board
{
    using models;
    public class Space
    {
        public Dictionary<int[], IEntities> desk = new Dictionary<int[], IEntities>();
        public List<Cross> wincondition= new List<Cross>();
        private static Player player;
        public Player GetPlayer()
        {
            if (player == null)
                player = new Player();
            return player;
        }
        public void FillBoard(string text, int[] pos)
        {
            IEntities entity = GetEntity(text);
            entity.Pos = pos;
            if (entity is Player)
            {
                GetPlayer();
                player.Pos = entity.Pos;
                desk.Add(entity.Pos, new FreeSpace());
            }
            else if (entity is Cross)
            {
                wincondition.Add(entity as Cross);
                desk.Add(entity.Pos, new FreeSpace());
            }
            else
            {
                desk.Add(entity.Pos, entity);
            }
        }
        private bool PushBox(IEntities box, int[] move)
        {
            int[] newpos = { box.Pos[0] +move[0], box.Pos[1] +move[1] };
            if (desk[newpos] is FreeSpace)
            {
                desk[box.Pos] = new FreeSpace();
                desk[newpos] = box;
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
                desk[player.Pos] = new FreeSpace();
                desk.Add(newpos, player);
                return true;
            }
            if (desk[newpos] is Box)
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
        private IEntities GetEntity(string printer)
        {
            return (IEntities)Activator.CreateInstance(DataConverter.Chars[printer]);
        }
        public bool CheckWin()
        {
            foreach (Cross cross in wincondition)
            {
                if (!(desk[cross.Pos] is Box))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
