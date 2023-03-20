import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {  firstValueFrom as _ } from "rxjs";
import { IResponse } from "../utils/interfaces/response.interface";

@Injectable()
export class DiagramService {


  constructor(private http: HttpClient) { }

  create<T>(info:any): Promise<IResponse<T>> {
    return _(this.http.post(`api/diagram/create`,info)) as Promise<IResponse<T>>
  }

  
  list<T>(): Promise<IResponse<T>> {
    return _(this.http.get(`api/diagram/list`)) as Promise<IResponse<T>>
  }
  

}//End Class
