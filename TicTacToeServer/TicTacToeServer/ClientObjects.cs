using System.Net.Sockets;

namespace TicTacToeServer
{
    internal class ClientObjects
    {
        public uint PlayerUID { get; set; }
        public int? AccessLevel { get; set; }
        public string Name { get; set; } = "";
        public string IpAddress { get; set; } = "";
        public string GameSymbol { get; set; } = "";
        public int Wins { get; set; } = 0;
        public Lobby? IsInLobby { get; set; }
        public Lobby? Hosting { get; set; }
        public NetworkStream NetworkStream { get; set; }    
    }
}
