import { Injectable } from '@angular/core';
import { IResponse } from '../interfaces/response.interface';
declare var Toastnotify:any;
@Injectable()
/**
 * https://www.cssscript.com/demo/toaster-snackbar-notify/
 */
export class AlertService {

  duration = 5000;

  constructor() {

  }


  message(res:IResponse<any>)
  {
    if(res.isSuccess)
    this.infoMesage(res.message);
    else
    this.errorMessage(null,res.message);
  }
  /**
   * Show Error Alert
   * @param message
   */
  errorMessage(error: any, message: string, isSilent = false): void {

    console.error(error);
    if (!isSilent) {

      let obj = {
        text: message,
        type: 'danger',
        duration: this.duration,
        allowClose: false,
        callbackOk: () => { }
      };
      Toastnotify.create(obj);
    }

  }

  /**
   * create Info Alert
   * @param message
   */
  infoMesage(message: string): void {
    let obj = {
      text: message,
      type: 'success',
      duration: this.duration,
      allowClose: false,
      callbackOk: () => { }
    };
    Toastnotify.create(obj);
  }

  /**
   * Show Message For : Observable Error When Request To Server
   * @param error
   */
  canRequestError(error: any): void {
    this.errorMessage(error,error?.error?.message|| error?.message  ||"I Can Not Access To Server");
  }

}// End Class
