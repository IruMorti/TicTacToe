using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace OnlineTicTacToe
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
        lobbyIsFull = 3,        
        joinFail = 4,
        passwordFail = 5,
    }

    public class GameEngine
    {
        private string userName;
        public uint UID { get; set; }
        private string connectedAddress;
        private readonly int port = 58000;                
        private NetworkStream networkStream;
        private bool selfDisconnect = false;
        private string[] lobbyList;
        private string[] oldLobbyList;
        private string[] playerList;       
        private PlayerStats playerStats = new PlayerStats();       

        public event EventHandler<string>? OnLogin;
        public event EventHandler<string[]>? OnLobbyRefresh;
        public event EventHandler<string>? OnJoinLobby;
        public event EventHandler<string>? OnLobbyRequest;
        public event EventHandler<string>? OnConfirmLobbyCreate;
        public event EventHandler<string>? OnDisconnect;
        public event EventHandler<string>? OnInfoMsg;
        public event EventHandler<string[]>? OnSetField;
        public event EventHandler<string>? OnResetFields;
        public event EventHandler<string[]>? OnSetWinnigCobination;
        public event EventHandler<string>? OnLobbyLeave;
        public event EventHandler<string[]>? OnChatMsg;
        public event EventHandler<string>? OnError;
        public event EventHandler<string>? OnGameStart;
        public event EventHandler<PlayerStats>? OnStatsChange;
        public GameEngine()
        { }

        public async Task<bool> Connect(string ipAddress)
        {
            try
            {
                if (ipAddress.IndexOf(" ") >= 0)
                    throw new Exception();

                IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                Socket client = new Socket(iPEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                CancellationTokenSource cts = new CancellationTokenSource();
                var abortTimer = new System.Timers.Timer(3000);
                abortTimer.Elapsed += (s, e) => { cts.Cancel(); };
                abortTimer.AutoReset = false;
                abortTimer.Start();

                await client.ConnectAsync(iPEndPoint, cts.Token);
                if (!client.Connected)
                    return false;

                connectedAddress = ipAddress;
                networkStream = new NetworkStream(client);
                new Thread(() => ClientManagment()).Start();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async void Reconnect()
        {
            if (await Connect(connectedAddress) == true)
                CreateNewUser(userName);
        }

        public void CreateNewUser(string username)
        {
            if (username.IndexOf(" ") == -1 && username.Length >= 4 && username.Length <= 12)
                Send(username, IndicatorID.addAcc);
            else
                OnInfoMsg?.Invoke(this, "No spaces, 4 - 12 character.");
        }

        private void UserConfirmation(string[] userInfos)
        {
            UID = Convert.ToUInt32(userInfos[0]);
            userName = userInfos[1];
            OnLogin?.Invoke(this, $"Server: {connectedAddress}, with {userInfos[1]} connected.");            
        }


        //The check must be done on the server side
        public bool CrateLobby(string lobbyName, string lobbyPassword)
        {
            if (lobbyName.IndexOf(" ") == -1 && lobbyName.Length >= 4 && lobbyName.Length <= 15)
            {
                if (lobbyPassword.IndexOf(" ") == -1 && lobbyPassword.Length <= 12)
                {
                    int nameLen = 16;
                    nameLen -= lobbyName.Length;
                    for (int j = 0; j < nameLen; j++)
                    {
                        lobbyName += " ";
                    }                   
                    Send(new string[] { lobbyName, lobbyPassword }, IndicatorID.createLobby);
                    return true;
                }
                else
                {
                    //Event
                }
            }
            else
            {
                //Event
            }
            return false;
        }

        public void LobbyRequest(int lobbyIndex)
        {
            Send(lobbyIndex.ToString(), IndicatorID.lobbyRequest);
        }
        
        public void LobbyJoin(int lobbyIndex, string lobbyPassword)
        {           
            Send([lobbyIndex.ToString(), lobbyPassword], IndicatorID.joinLobby);
        }

        public void LobbyLeave()
        {
            Send("", IndicatorID.leaveALobby);
        }

        public int? RefreshLobbyList(string? currentLobby)
        {
            int? newIndex = null;
            if (currentLobby == "")
                oldLobbyList = [""];

            if (lobbyList != null && oldLobbyList != lobbyList)
            {
                oldLobbyList = lobbyList;
                OnLobbyRefresh?.Invoke(this, lobbyList);
                for (int i = 0; i < lobbyList.Length; i++)
                {                   
                    if (lobbyList[i] == currentLobby)
                        newIndex = i;
                }
            }
            return newIndex;
        }

        public string GetPlayerName(int currentLobbyIndex)
        {
            if (currentLobbyIndex != -1 && currentLobbyIndex < playerList.Length)
                return playerList[currentLobbyIndex];

            return "";
        }
                           
        public void SendGameResources(int feldIndex)
        {            
            Send((feldIndex - 1).ToString(), IndicatorID.gameInfo);
        }

        public void SendChatMsg(string msg)
        {
            Send(msg, IndicatorID.chatting);
        }

        public void Disconnect()
        {
            try
            {
                networkStream.Socket.Close();
                selfDisconnect = true;
            }
            catch { }
        }

        private void FeldManagment(string[] fieldDescription)
        {
            try
            {                
                if (fieldDescription.Length == 2)
                    OnSetField?.Invoke(this, fieldDescription);
                else if (fieldDescription.Length == 3)
                {
                    OnSetField?.Invoke(this, fieldDescription);
                    string[] winnigCobination = fieldDescription[fieldDescription.Length - 1].Split(',');
                    
                    if (winnigCobination[0] == "0" && winnigCobination[1] == "0" && winnigCobination[2] == "0")
                        OnResetFields?.Invoke(this, "");
                    else
                        OnSetWinnigCobination?.Invoke(this, winnigCobination);                    
                }
            }
            catch 
            {
                OnError?.Invoke(this, $"Failed to set feld");
            }
        }

        private void StatsManagment(string[] stats)
        {
            try
            {                
                //Name of player one
                if (stats[0] != "")
                    playerStats.player1 = stats[0];
                
                //Name of player two
                if (stats[1] != "")
                    playerStats.player2 = stats[1];
                
                //Symbol of play one
                if (stats[2] != "")
                    playerStats.player1Symbol = stats[2];
                
                //Symbol of player two
                if (stats[3] != "")
                    playerStats.player2Symbol = stats[3];
               
                //Wins from player one
                if (stats[4] != "")
                    playerStats.player1Won = stats[4];
                
                //Wins from player two
                if (stats[5] != "")
                    playerStats.player2Won = stats[5];
                
                //Startsymbol
                if (stats[6] != "")
                    playerStats.startSymbol = stats[6];
                
                OnStatsChange?.Invoke(this, playerStats);
            }
            catch 
            {
                OnError?.Invoke(this, "Failed stats managment.");
            }
        }

        private void FailManagment(string failIndicator)
        {
            switch (Convert.ToInt32(failIndicator))
            {
                case (int)FailCodes.loginFail:
                    OnError?.Invoke(this, "");
                    break;
                case (int)FailCodes.createLobbyFail:
                    OnError?.Invoke(this, "");
                    break;
                case (int)FailCodes.joinFail:
                    OnError?.Invoke(this, "The lobby may no longer exist!");
                    break;
                case (int)FailCodes.passwordFail:
                    OnError?.Invoke(this, "");
                    break;
            }
        }

        private void ClientManagment()
        {
            while (networkStream.Socket.Connected)
            {
                try
                {
                    ReceivingData receivingData = Receive();                                                                                   
                    switch (receivingData.indicatorID)
                    {
                        case ((int)IndicatorID.gameInfo):
                            FeldManagment(receivingData.received);
                            break;
                        case ((int)IndicatorID.playerStats):
                            StatsManagment(receivingData.received);
                            break;
                        case ((int)IndicatorID.lobbyList):                          
                            lobbyList = receivingData.received;                            
                            break;
                        case ((int)IndicatorID.playerList):
                            playerList = receivingData.received;
                            break;
                        case ((int)IndicatorID.addAcc):
                            UserConfirmation(receivingData.received);
                            break;
                        case ((int)IndicatorID.lobbyRequest):
                            OnLobbyRequest?.Invoke(this, receivingData.received[0]);
                            break;
                        case ((int)IndicatorID.joinLobby):
                            OnGameStart?.Invoke(this, "");
                            break;
                        case ((int)IndicatorID.createLobby):
                            OnConfirmLobbyCreate?.Invoke(this, receivingData.received[0]);
                            break;
                        case ((int)IndicatorID.leaveALobby):
                            OnLobbyLeave?.Invoke(this, "");
                            break;
                        case (int)IndicatorID.chatting:
                            OnChatMsg?.Invoke(this, receivingData.received);
                            break;
                        case ((int)IndicatorID.failInfo):
                            FailManagment(receivingData.received[0]);
                            break;
                        default:
                            throw new Exception();
                    }
                }
                catch
                {
                    if (networkStream.Socket.Connected == false && userName != null && selfDisconnect == false)                    
                        OnDisconnect?.Invoke(this, $"Server: {connectedAddress}, with {userName} disconnected.");                                            
                    else if (networkStream.Socket.Connected == false && userName == null && selfDisconnect == false)
                        OnError?.Invoke(this, "Server disconnect.\nPleace restart your game.");
                }
            }
        }

        //Receive and Send Informations

        private void Send(string data, IndicatorID inId)
        {
            Send(new string[] { data }, inId);
        }

        private void Send(string[] data, IndicatorID inId)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF32, true))
                    {
                        bw.Write(data.Length);
                        bw.Write(((int)inId));

                        for (int i = 0; i < data.Length; i++)
                        {
                            bw.Write(data[i]);
                        }
                        bw.Flush();
                        networkStream.Write(ms.ToArray());
                    }
                }
            }
            catch (IOException)
            {
                return;
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex.ToString());
            }
        }

        private ReceivingData Receive()
        {
            try
            {
                ReceivingData received = new ReceivingData();
                using (BinaryReader br = new BinaryReader(networkStream, Encoding.UTF32, true))
                {                    
                    int recLength = br.ReadInt32();                    
                    received.indicatorID = br.ReadInt32();

                    if (recLength < 50 && recLength != 0 && received.indicatorID != null)
                    {
                        received.received = new string[recLength];
                        for (int i = 0; i < recLength; i++)
                        {
                            received.received[i] = br.ReadString();
                        }
                    }                    
                    return received;
                }
            }
            catch (IOException)
            {
                return new ReceivingData();
            }
            catch (Exception ex)
            {
                OnError?.Invoke(this, ex.ToString());
                return new ReceivingData();
            }
        }
    }
}