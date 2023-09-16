import { MusclePart } from "src/app/muscle-part/model/muscle-part";
import { Type } from "./type.enum";

export class ExerciseResponse{
    name:String;
    burnedKcal:number;
    time:number;
    type:Type;
    muscleParts:MusclePart[];

    constructor(name:String,burnedKcal:number,time:number,type:Type,muscleParts:MusclePart[]){
        this.name=name;
        this.burnedKcal=burnedKcal;
        this.time=time;
        this.type=type;
        this.muscleParts=muscleParts;
    }
}