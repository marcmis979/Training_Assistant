export class User{
    id:number;
    name:string;
    surname:string;
    sex:boolean;
    age:number;
    height:number;
    weight:number;
    targetWeight:number;
    tempo:number;
    email:string;
    
    constructor(id:number, name:string,surname:string,sex:boolean,age:number,height:number,weight:number,
        targetWeight:number,tempo:number,email:string)
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
            this.email=email;
        }
}