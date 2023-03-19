/**
 * Reponse Data From Server Inter Face
 */
export interface IResponse<T> {
    isSuccess :boolean;
          message:string;
           result:T;
}


