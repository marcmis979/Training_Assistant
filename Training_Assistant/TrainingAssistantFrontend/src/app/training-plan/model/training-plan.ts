import { Training } from "src/app/training/model/training";

export class TrainingPlan{
    id:number;
    name:string;
    trainings:Training[];

    constructor(id:number,name:string,trainings:Training[]){
        this.id=id;
        this.name=name;
        this.trainings=trainings;
    }
}