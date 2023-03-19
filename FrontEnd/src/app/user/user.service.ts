import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {  firstValueFrom as _ } from "rxjs";
import { IResponse } from "../utils/interfaces/response.interface";

@Injectable()
export class UserService {


  constructor(private http: HttpClient) { }

  login<T>(info:any): Promise<IResponse<T>> {
    return _(this.http.post(`api/Auth/login`,info)) as Promise<IResponse<T>>
  }

}//End Class
