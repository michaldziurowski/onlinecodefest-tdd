var express = require('express');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var presenterId;

app.use(express.static(__dirname));

app.get('/', function(req, res){
  res.sendFile(__dirname + '/index.html');
});

io.on('connection', function(socket){
  socket.on('presenter', function(msg){
    console.log('Presenter registered with id '+ socket.id);
    if(!presenterId){
      presenterId = socket.id;
    }
  });

  socket.on('register', function(name){
    notifyPresenterGamerRegistered(socket.id, name);
  });

  socket.on('answer', function(answer){
    notifyPresenterAnswer(socket.id, answer);
  }); 

  socket.on('move', function(move){
    notifyGamers(move);
  });  

  socket.on('board', function(boardMessage){
    sendBoardToGamer(boardMessage.gamerId, boardMessage.board);
  });

  socket.on('disconnect', function(msg){
    notifyPresenterGamerDisconnected(socket.id);
  });  
});

function notifyPresenterGamerRegistered(gamerId, gamerName){
  io.to(presenterId).emit('gamerRegistered', {id: gamerId, name: gamerName});
}

function notifyPresenterGamerDisconnected(gamerId){
  io.to(presenterId).emit('gamerDisconnected', gamerId);
}

function notifyPresenterAnswer(gamerId, answer){
  io.to(presenterId).emit('gamerAnswer', {id: gamerId, answer: answer});
}

function notifyGamers(move){
  io.emit('move', move);
}

function sendBoardToGamer(gamerId, board){
  io.to(gamerId).emit('registered', board);
}

http.listen(3000, function(){
  console.log('listening on *:3000');
});
