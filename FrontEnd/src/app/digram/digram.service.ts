import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {  firstValueFrom as _ } from "rxjs";
import { IResponse } from "../utils/interfaces/response.interface";

@Injectable()
export class DigramService {


  constructor(private http: HttpClient) { }

  create<T>(info:any): Promise<IResponse<T>> {
    return _(this.http.post(`api/digram/create`,info)) as Promise<IResponse<T>>
  }

  
  list<T>(): Promise<IResponse<T>> {
    return _(this.http.get(`api/digram/list`)) as Promise<IResponse<T>>
  }
  

}//End Class
