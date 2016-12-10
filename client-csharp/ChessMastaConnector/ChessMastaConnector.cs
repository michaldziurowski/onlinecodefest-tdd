using Quobject.SocketIoClientDotNet.Client;

namespace BS.ChessMasta
{
    public delegate void ServerMessage(string message);

    public class ChessMastaConnector
    {
        private bool _isConnected = false;
        private Socket _socket;

        public ChessMastaConnector(string serverUrl)
        {
            _socket = IO.Socket(serverUrl);
            InitializeSocket();
        }

        public event ServerMessage OnRegistered;
        public event ServerMessage OnMove;

        public void Connect(string name)
        {
            _socket.Emit("register", name);
        }

        public void SendAnswer(string answer)
        {
            _socket.Emit("answer", answer);
        }

        private void InitializeSocket()
        {
            _socket.On("registered", (msg) => OnRegistered((string) msg));
            _socket.On("move", (msg) => OnMove((string) msg));
        }
    }
}
