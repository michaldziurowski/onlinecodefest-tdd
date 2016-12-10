/// <reference path='gamer.ts'/>

import * as io from "socket.io-client"
import { Gamer } from "gamer"

export class ChessMastaPresenter {
    private socket: SocketIOClient.Socket;

    private _board: any;
    gamers: Gamer[] = [];
    move: string = '';    

    attached() {
        this.socket = io.connect();

        this.socket.on('gamerRegistered', (msg) => {
            this.addGamer(msg);
            this.sendBoard(msg.id);
        });

        this.socket.on('gamerDisconnected', (gamerId) => this.removeGamer(gamerId));

        this.socket.on('gamerAnswer', (gamerAnswer) => this.setGamerAnswer(gamerAnswer));

        this.socket.emit('presenter', true);
        
        this.initBoard();
    }

    sendMove(){
        this.socket.emit('move', this.move);
        this.move = '';
    }

    private initBoard(){
		var ruyLopez = 'r1bqkbnr/pppp1ppp/2n5/1B2p3/4P3/5N2/PPPP1PPP/RNBQK2R';
        this._board = ChessBoard('board1',ruyLopez);
    }

    private setGamerAnswer(gamerAnswer){
        var gamerIdx = this.getGamerIdx(gamerAnswer.id);
        var gamer = this.gamers[gamerIdx];
        gamer.setAnswer(gamerAnswer.answer);
    }

    private getGamerIdx(id: string) {
        for (var i = 0; i < this.gamers.length; i++)
            if (this.gamers[i].id == id)
                return i;
    }

    private addGamer(gamerData: Gamer) {
        var gamer = new Gamer(gamerData.id, gamerData.name);
        this.gamers.push(gamer);
    }

    private removeGamer(gamerId: string){
        var gamerIdx = this.getGamerIdx(gamerId);
        this.gamers.splice(gamerIdx,1);
    }

    private sendBoard(gamerId){
        this.socket.emit('board', {gamerId: gamerId, board: JSON.stringify(this._board.position())});
    }
}
