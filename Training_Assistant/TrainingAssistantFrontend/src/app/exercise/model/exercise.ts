import { MusclePart } from "src/app/muscle-part/model/muscle-part";
import { Type } from "./type.enum";

export class Exercise {
    id: number;
    name: string;
    burnedKcal: number;
    time: number;
    type: Type;
    muscleParts: MusclePart[];
  
    constructor(id: number, name: string, burnedKcal: number, time: number, type: Type, muscleParts: MusclePart[]) {
      this.id = id;
      this.name = name;
      this.burnedKcal = burnedKcal;
      this.time = time;
      this.type = type;
      this.muscleParts = muscleParts;
    }
  }