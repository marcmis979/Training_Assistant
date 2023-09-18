import { TrainingPlan } from "src/app/training-plan/model/training-plan";

export interface UserResponse
    {
        token: string;
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
    }