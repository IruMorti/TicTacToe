namespace TicTacToeServer
{
    internal class Lobby
    {
        public int lobbyId {  get; set; }
        public string lobbyName { get; set; }
        public string lobbyPassword { get; set; }

        public List<ClientObjects> playerList = new List<ClientObjects>();
        public string startSymbol = "";
        private string[] TicTacToeField = new string[9];        
        
        public Lobby()
        { }

        public string[]? Game(ClientObjects co, string? gameResources)
        {
            try
            {
                string[] field8WinningCombination = new string[1];                
                int feldIndex = Convert.ToInt32(gameResources);
                
                if (feldIndex >= 0 && feldIndex <= 8 && startSymbol == co.GameSymbol)
                {
                    if (TicTacToeField[feldIndex] == null)
                    {
                        TicTacToeField[feldIndex] = co.GameSymbol;
                        if (startSymbol == "X")
                            startSymbol = "O";
                        else if (startSymbol == "O")
                            startSymbol = "X";

                        string? win = IsWinningCombination(co);
                        if (win != null)
                        {
                            TicTacToeField = new string[9];
                            field8WinningCombination = ["", win]; //Winning symbol x or o
                            co.Wins++;
                        }

                        field8WinningCombination[0] = feldIndex.ToString();
                        foreach (string field in TicTacToeField)
                        {
                            if (field == null)
                                return field8WinningCombination;
                        }
                        TicTacToeField = new string[9];
                        return field8WinningCombination = [feldIndex.ToString(), "0,0,0"];
                    }                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);                
            }
            return null;
        }
        
        private string? IsWinningCombination(ClientObjects co)
        {
            //| 0 1 2 |
            //| 3 4 5 |
            //| 6 7 8 |            
            string[] tf = TicTacToeField;
            string sy = co.GameSymbol;           
           
            for (int i = 0; i < 9; i += 3)
            {
                if (tf[i] == sy && tf[i + 1] == sy && tf[i + 2] == sy)
                    return $"{i},{i + 1},{i + 2}";
            }

            for (int i = 0; i < 3; i++)
            {
                if (tf[i] == sy && tf[i + 3] == sy && tf[i + 6] == sy)
                    return $"{i},{i + 3},{i + 6}";
            }

            if (tf[0] == sy && tf[4] == sy && tf[8] == sy)
                return $"{0},{4},{8}";
            else if (tf[2] == sy && tf[4] == sy && tf[6] == sy)
                return $"{2},{4},{6}";
            
            return null;
        }
    }
}
