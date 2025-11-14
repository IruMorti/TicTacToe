using System.Diagnostics.SymbolStore;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

namespace TicTacToeServer
{
    public enum IndicatorID
    {
        addAcc = 656,
        joinLobby = 371,
        lobbyRequest = 749,
        createLobby = 267,
        lobbyList = 945,
        leaveALobby = 666,
        playerList = 892,
        gameInfo = 383,
        playerStats = 352,
        chatting = 802,
        failInfo = 404,
    }

    public enum FailCodes
    {
        loginFail = 1,
        createLobbyFail = 2,                
        joinFail = 4,
        passwordFail = 5,
    }

    internal class Server
    {
        private static List<ClientObjects> playerList = new List<ClientObjects>();
        private static List<ClientObjects> unknownUsers = new List<ClientObjects>();
        private static List<Lobby> lobbyList = new List<Lobby>();
        private static Logger logger = new Logger();

        private static void Main(string[] args)
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, 58000);
            Socket server = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(iPEndPoint);
            server.Listen();
            logger.Log("|MSG| Server is running!");           
            AcceptClient(server);
        }

        private static void AcceptClient(Socket server)
        {
            while (true)
            {
                try
                {
                    Socket newConnect = server.Accept();
                    new Thread(() =>
                    {
                        ClientObjects co = new ClientObjects();
                        co.NetworkStream = new NetworkStream(newConnect);
                        unknownUsers.Add(co);
                        logger.Log($"|MSG| A client is connected | Ip-Address: {newConnect.RemoteEndPoint}.");
                        ServerManagment(co);
                    }).Start();
                }
                catch
                {
                    logger.Log("|MSG| A client tryed to connect.");
                }
            }
        }
       
        private static ClientObjects LoginClient(ClientObjects co, string[] playerInfo)
        {
            if (playerInfo[0] != "")
            {
                try
                {
                    co.PlayerUID = GenUID();
                    co.Name = playerInfo[0];
                    co.IpAddress = co.NetworkStream.Socket.RemoteEndPoint?.ToString() ?? "";
                    logger.Log($"|MSG| Name: {co.Name} | IpAddress: {co.IpAddress} | is connected.");
                    playerList.Add(co);
                    logger.Log($"|MSG| Online player: {playerList.Count}");
                    Send([co.PlayerUID.ToString(), co.Name], co, IndicatorID.addAcc);
                    LobbyRefresh();
                    return co;
                }
                catch (Exception ex)
                {
                    Send("1", co, IndicatorID.failInfo);
                    logger.Log("Fail-user-login: " + ex);
                }
            }
            DisconnectClient(co);
            return co;
        }

        private static uint GenUID()
        {
            while (true)
            {
                uint id = (uint)new Random().Next(100000000, 999999999);
                if (playerList.Find(i => i.PlayerUID == id) == null)
                    return id;
            }
        }


        private static void CreateLobby(ClientObjects co, string[] lobbyInfos)
        {
            try
            {
                if (LobbyNameCheck(lobbyInfos[0]) == false && co.IsInLobby == null)
                {                    
                    Lobby lobby = new Lobby();
                    int loId = new Random().Next(100000, 10000000);

                    lobby.lobbyId = loId;
                    lobby.lobbyName = lobbyInfos[0];
                    lobby.lobbyPassword = lobbyInfos[1];                                                          
                    co.Hosting = lobby;
                    co.IsInLobby = lobby;
                    lobby.playerList.Add(co);
                    lobbyList.Add(lobby);
                    LobbyRefresh();
                    Send(lobby.lobbyName, co, IndicatorID.createLobby);
                    logger.Log($"|MSG| Lobby: {lobby.lobbyName} created | From: {co.Name}.");                                        
                }
                else { }
            }
            catch
            {
                Send(((int)FailCodes.createLobbyFail).ToString(), co, IndicatorID.failInfo);
            }
        }

        private static bool LobbyNameCheck(string lobbyName)
        {
            foreach (var lobby in lobbyList)
            {
                if (lobby.lobbyName == lobbyName)
                    return true;
            }
            return false;
        }

        private static void LobbyRequest(ClientObjects co, string[] lobbyIndex)
        {
            try
            {
                if (lobbyIndex.Length != 1) 
                    throw new Exception();
                var lobby = lobbyList[Convert.ToInt32(lobbyIndex[0])];
                if (lobby.playerList.Count != 2 && co.IsInLobby == null && lobby.playerList[0].NetworkStream.Socket.Connected == true)
                {
                    //Exist password true / false.
                    if (lobby.lobbyPassword != "")
                        Send("true", co, IndicatorID.lobbyRequest);
                    else
                        Send("false", co, IndicatorID.lobbyRequest);
                }
                else if (lobby.playerList.Count == 2 && co.IsInLobby == null)
                {   
                    //Send it if the lobby is full with players
                    Send("full", co, IndicatorID.lobbyRequest);
                }
            }
            catch
            {
                //Send it if it no longer exists.
                Send(((int)FailCodes.joinFail).ToString(), co, IndicatorID.failInfo);
            }
        }

        private static void JoinLobby(ClientObjects co, string[] lobbyJoinInfo)
        {
            try
            {
                var lobby = lobbyList[Convert.ToInt32(lobbyJoinInfo[0])];
                if (lobby.playerList.Count != 2 && co.IsInLobby == null)
                {
                    if (lobby.lobbyPassword == lobbyJoinInfo[1])
                    {
                        lobby.playerList.Add(co);                        
                        co.IsInLobby = lobby;
                        logger.Log($"|MSG| {co.Name} join the lobby: {lobby.lobbyName} | Player: {lobby.playerList.Count}/2.");                        
                        RollSymbol(co);
                        foreach (var player in lobby.playerList)
                            Send("", player, IndicatorID.joinLobby);
                        StatsManagment(co, lobby);
                        LobbyRefresh();
                    }                   
                }                
            }
            catch
            {
                //Send it if it no longer exists.
                Send(((int)FailCodes.joinFail).ToString(), co, IndicatorID.failInfo);
            }
        }

        private static void StatsManagment(ClientObjects co, Lobby lobby)
        {
            try
            {
                string[] stats = new string[7];
                for (int i = 0; i < lobby.playerList.Count; i++)
                {
                    stats[i] = lobby.playerList[i].Name;
                    stats[i + 2] = lobby.playerList[i].GameSymbol;
                    stats[i + 4] = lobby.playerList[i].Wins.ToString();
                }
                stats[6] = lobby.startSymbol;

                foreach (var player in lobby.playerList)
                {
                    Send(stats, player, IndicatorID.playerStats);
                }
            }
            catch
            {
                logger.Log("|ERROR| Failed to build stats array.");
                LeaveALobby(co);
            }
        }

        private static void RollSymbol(ClientObjects co)
        {
            if (co.IsInLobby == null) return;
            string[] symbol1 = { "X", "O" };
            string[] symbol2 = { "O", "X" };
            string[] selectedSymbols;

            //Selects an array by random number
            Random random = new Random();
            int randomValue = random.Next(0, 2);            
            if (randomValue == 0)            
                selectedSymbols = symbol1;
            else
                selectedSymbols = symbol2;

            //Gives her symbols to the players in the lobby
            for (int i = 0; i < co.IsInLobby.playerList.Count; i++)
            {
                co.IsInLobby.playerList[i].GameSymbol = selectedSymbols[i];
                logger.Log($"|MSG| {co.IsInLobby.playerList[i].Name } roll: {co.IsInLobby.playerList[i].GameSymbol}");
            }
            //Selects the start symbol
            co.IsInLobby.startSymbol = selectedSymbols[random.Next(0, 2)];
            logger.Log($"|MSG| Startsymbol: {co.IsInLobby.startSymbol}");
        }

        private static void LobbyChat(ClientObjects co, string lobbyChatMsg)
        {            
            string[] msgBuild = new string[3];
            if (co.IsInLobby != null)
            {
                msgBuild[0] = co.PlayerUID.ToString();
                msgBuild[1] = co.Name;      //Return the playername of the msg
                msgBuild[2] = lobbyChatMsg; //MSG
                logger.Log($"|USER| {co.Name} > {lobbyChatMsg}");
                foreach (var player in co.IsInLobby.playerList)
                {
                    if (player != null)
                        Send(msgBuild, player, IndicatorID.chatting);
                }
            }            
        }

        private static void LobbyRefresh()
        {           
            string[] lobbyListForClients = new string[lobbyList.Count];
            string[] playerListForClients = new string[lobbyList.Count];
            for (int i = 0; i < lobbyList.Count; i++)
            {                
                if (lobbyList[i].lobbyPassword == "")                
                    lobbyListForClients[i] = $"{lobbyList[i].lobbyName}\t\t{lobbyList[i].playerList.Count}/2\tOpen";                                                    
                else                
                    lobbyListForClients[i] = $"{lobbyList[i].lobbyName}\t\t{lobbyList[i].playerList.Count}/2\tClosed";

                if (lobbyList[i].playerList.Count == 2)
                    playerListForClients[i] = $"{lobbyList[i].playerList[0].Name}, {lobbyList[i].playerList[1].Name}";
                else
                    playerListForClients[i] = $"{lobbyList[i].playerList[0].Name}";
            }
            foreach (var player in playerList)
            {                
                Send(lobbyListForClients, player, IndicatorID.lobbyList);
                Send(playerListForClients, player, IndicatorID.playerList);                
            }
        }

        private static void LobbyManagment(ClientObjects co, string[] gameResources)
        {            
            //if null = exeption, [0] set feld [1] = winnig combination
            if (gameResources.Length != 1 || co.IsInLobby == null) return;
            string[]? felder = co.IsInLobby.Game(co, gameResources[0]);
            if (felder != null)
            {
                if (felder.Length == 1)
                {
                    foreach (var player in co.IsInLobby.playerList)
                        Send(new string[] { co.GameSymbol, felder[0] }, player, IndicatorID.gameInfo);
                }
                else if (felder.Length == 2)
                {
                    //The player has won                    
                    logger.Log($"|MSG| {co.Name} won the game.");
                    foreach (var player in co.IsInLobby.playerList)
                        Send(new string[] { co.GameSymbol, felder[0], felder[1] }, player, IndicatorID.gameInfo);                                       
                    
                    RollSymbol(co);
                }
                StatsManagment(co, co.IsInLobby);
            }
        }

        private static void LeaveALobby(ClientObjects co)
        {
            try
            {
                if (co.Hosting != null)
                {
                    lobbyList.Remove(co.Hosting);
                    logger.Log($"|MSG| Lobby: {co.Hosting.lobbyName} closed.");                   
                    if (co.Hosting.playerList.Count == 2)
                    {
                        co.Hosting.playerList[1].IsInLobby = null;                        
                        Send("", co.Hosting.playerList[1], IndicatorID.leaveALobby);
                    }
                }
                else if (co.IsInLobby != null)
                {
                    var lobby = co.IsInLobby;
                    lobby.playerList.Remove(co);
                    logger.Log($"|MSG| {co.Name} left the lobby: {lobby.lobbyName} | Player: {lobby.playerList.Count}/2");
                }
            }
            catch (Exception ex) 
            {
                logger.Log(ex.ToString());
            }
            LobbyRefresh();
            co.IsInLobby = null;
        }

        private static void DisconnectClient(ClientObjects co)
        {
            try
            {
                playerList.Remove(co);
                unknownUsers.Remove(co);
                LeaveALobby(co);
                co.NetworkStream.Socket.Close();                
            
                if (co.Name == null)
                    logger.Log($"|MSG| A client is disconneted.");
                else
                {
                    logger.Log($"|MSG| Name: {co.Name} | Ip-Address: {co.IpAddress} | is disconneted.");
                    logger.Log($"|MSG| Online player: {playerList.Count}");
                }
            }
            catch
            {
                logger.Log($"|FAIL| To disconneted {co.Name}.");
            }
        }
       
        private static void ServerManagment(ClientObjects co)
        {            
            while (co.NetworkStream.Socket.Connected)
            {
                try
                {
                    ReceivingData receivingData = Receive(co);
                    switch (receivingData.indicatorID)
                    {
                        case (int)IndicatorID.gameInfo:
                            LobbyManagment(co, receivingData.recStrArray);
                            break;
                        case (int)IndicatorID.addAcc:
                            co = LoginClient(co, receivingData.recStrArray);
                            break;
                        case (int)IndicatorID.lobbyRequest:
                            LobbyRequest(co, receivingData.recStrArray);
                            break;
                        case (int)IndicatorID.joinLobby:
                            JoinLobby(co, receivingData.recStrArray);
                            break;
                        case (int)IndicatorID.createLobby:
                            CreateLobby(co, receivingData.recStrArray);
                            break;                                                   
                        case (int)IndicatorID.chatting:
                            LobbyChat(co, receivingData.recStrArray[0]);
                            break;
                        case (int)IndicatorID.leaveALobby:
                            LeaveALobby(co);
                            break;
                    }
                }
                catch
                {
                    logger.Log("|ERROR| Failed to managed client informations.");
                }
            }
        }

        //Receive and Send Informations

        private static void Send(string data,ClientObjects co, IndicatorID inId)
        {
            Send(new string[] { data }, co, inId);
        }

        private static void Send(string[] data, ClientObjects co, IndicatorID inId)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF32, true))
                    {
                        bw.Write(data.Length);
                        bw.Write((int)inId);

                        for (int i = 0; i < data.Length; i++)
                        {
                            bw.Write(data[i]);
                        }
                        bw.Flush();
                        co.NetworkStream.Write(ms.ToArray());
                    }
                }
            }
            catch (IOException)
            {
                DisconnectClient(co);                
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());                
            }
        }

        private static ReceivingData Receive(ClientObjects co)
        {
            try
            {
                ReceivingData received = new ReceivingData();
                using (BinaryReader br = new BinaryReader(co.NetworkStream, Encoding.UTF32, true))
                {                    
                    int recLength = br.ReadInt32();                    
                    received.indicatorID = br.ReadInt32();

                    if (recLength < 50 && recLength != 0 && received.indicatorID != null)
                    {
                        received.recStrArray = new string[recLength];
                        for (int i = 0; i < recLength; i++)
                        {
                            received.recStrArray[i] = br.ReadString();
                        }
                    }                    
                    return received;
                }
            }
            catch (IOException)
            {
                DisconnectClient(co);
                return new ReceivingData();
            }
            catch (Exception ex)
            {
                logger.Log(ex.ToString());
                return new ReceivingData();
            }
        }
    }
}