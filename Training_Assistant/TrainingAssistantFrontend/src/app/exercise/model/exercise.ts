import { Type } from "./type.enum";
import { MusclePartResponse } from "src/app/muscle-part/model/muscle-part-response";

export class Exercise {
    id: number;
    name: string;
    burnedKcal: number;
    time: number;
    type: Type;
    muscleParts: MusclePartResponse[];
  
    constructor(id: number, name: string, burnedKcal: number, time: number, type: Type, muscleParts: MusclePartResponse[]) {
      this.id = id;
      this.name = name;
      this.burnedKcal = burnedKcal;
      this.time = time;
      this.type = type;
      this.muscleParts = muscleParts;
    }
  }