
export interface IUser {
  userName: string;
  roles:"USER"|"ADMIN" [],
}

export interface  IAuth{
  roles:string[];
  token:string
}
