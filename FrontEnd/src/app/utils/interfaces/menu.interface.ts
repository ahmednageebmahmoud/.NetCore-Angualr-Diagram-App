export interface IMenu{
name:string,
url:string,
isAnonymous:boolean,
roleState?:"USER"|"ADMIN";
}
