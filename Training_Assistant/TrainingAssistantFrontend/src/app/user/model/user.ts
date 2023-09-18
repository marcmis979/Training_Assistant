import { TrainingPlan } from "src/app/training-plan/model/training-plan";

export class User{
        id: number;
        name: string;
        surname: string;
        sex: boolean;
        age: number;
        height: number;
        weight: number;
        targetWeight: number;
        tempo: number;
        password: string;
        email: string;
        isAdmin: boolean;
        trainingPlan:TrainingPlan;

    constructor(id:number, name:string,surname:string,sex:boolean,age:number,height:number,weight:number,
        targetWeight:number,tempo:number, password: string,email:string, isAdmin: boolean,trainingPlan:TrainingPlan)
        {
            this.id=id;
            this.name=name;
            this.surname=surname;
            this.sex=sex;
            this.age=age;
            this.height=height;
            this.weight=weight;
            this.targetWeight=targetWeight;
            this.tempo=tempo;
            this.password=password;
            this.email=email;
            this.isAdmin=isAdmin;
            this.trainingPlan=trainingPlan;
        }
}