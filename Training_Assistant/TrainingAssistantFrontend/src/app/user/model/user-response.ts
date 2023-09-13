export class UserResponse{
    name:string;
    surname:string;
    sex:boolean;
    age:number;
    height:number;
    weight:number;
    targetWeight:number;
    tempo:number;
    email:string;
    password:string;
    
    constructor(name:string,surname:string,sex:boolean,age:number,height:number,weight:number,
        targetWeight:number,tempo:number,email:string, password:string)
        {
            this.name=name;
            this.surname=surname;
            this.sex=sex;
            this.age=age;
            this.height=height;
            this.weight=weight;
            this.targetWeight=targetWeight;
            this.tempo=tempo;
            this.email=email;
            this.password=password;
        }
}