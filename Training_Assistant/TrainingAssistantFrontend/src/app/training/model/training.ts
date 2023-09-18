import { Exercise } from "src/app/exercise/model/exercise";

export class Training{
    id:number;
    name:string;
    days:number;
    exercises:Exercise[];

    constructor(id:number,name:string,days:number,exercises:Exercise[]){
        this.id=id;
        this.name=name;
        this.days=days;
        this.exercises=exercises;
    }
}