import { Type } from "./type.enum";

export class Exercise{
    id:number;
    name:String;
    burnedKcal:number;
    time:number;
    type:Type;

    constructor(id:number,name:String,burnedKcal:number,time:number,type:Type){
        this.id=id;
        this.name=name;
        this.burnedKcal=burnedKcal;
        this.time=time;
        this.type=type;
    }
}