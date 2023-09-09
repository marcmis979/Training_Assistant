import { Type } from "./type.enum";

export class ExerciseResponse{
    name:String;
    burnedKcal:number;
    time:number;
    type:Type;

    constructor(name:String,burnedKcal:number,time:number,type:Type){
        this.name=name;
        this.burnedKcal=burnedKcal;
        this.time=time;
        this.type=type;
    }
}