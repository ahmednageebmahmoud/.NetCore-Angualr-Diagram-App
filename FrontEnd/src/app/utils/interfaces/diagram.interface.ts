import { IAction } from "./i.actions.interface";

export interface IDiagram extends IAction{
    id:number;
    name:string;
    tag:string;
    jsonDiagram:string;
    
}