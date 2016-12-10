import * as io from "socket.io-client"

export class ChessMastaClient {
    private socket : SocketIOClient.Socket;
    
    serverUrl: string;
    name: string;
    answer: string;
    initialized: boolean = false;
    messages: string[] = [];

    init() {
        this.socket = io.connect(this.serverUrl);
        this.socket.on('move',  (move) => this.addReceivedMessage(move));
        this.socket.on('registered', (board) => this.addReceivedMessage(board));
        this.socket.emit('register', this.name);     
           
        this.initialized = true;
    }

    sendAnswer(){
        this.socket.emit('answer', this.answer);
    }

    addReceivedMessage(move){
        this.messages.push(move);
    }
}