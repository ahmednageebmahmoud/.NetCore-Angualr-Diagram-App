import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import {  firstValueFrom as _ } from "rxjs";
import { IResponse } from "../utils/interfaces/response.interface";

@Injectable()
export class DiagramService {


  constructor(private http: HttpClient) { }

  create<T>(info:any): Promise<IResponse<T>> {
    return _(this.http.post(`api/Diagram`,info)) as Promise<IResponse<T>>
  }

  edit<T>(info:any): Promise<IResponse<T>> {
    return _(this.http.put(`api/Diagram`,info)) as Promise<IResponse<T>>
  }
  
  get<T>(id:number): Promise<IResponse<T>> {
    return _(this.http.get(`api/Diagram?id=${id}`)) as Promise<IResponse<T>>
  }
  
  
  delete<T>(id:any): Promise<IResponse<T>> {
    return _(this.http.delete(`api/Diagram?id=${id}`)) as Promise<IResponse<T>>
  }
  
  list<T>(): Promise<IResponse<T>> {
    return _(this.http.get(`api/Diagram/list`)) as Promise<IResponse<T>>
  }
  

}//End Class
