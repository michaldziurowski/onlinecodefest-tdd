export class Gamer { 
    answers: string[];

    constructor(public id: string,public name: string){
        this.answers = [];
    }

    setAnswer(answer: string){
        this.answers.push(answer);
    }
}