import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { firstValueFrom as _ } from "rxjs";
import { AlertService } from "./alert.service";
import { LoggedUserService } from "./logged.user.service";
import { StorageService } from "./storage.service";

@Injectable()
export class UtilsService {
  /**
   *
   * @param alert Alert Service
   */
  constructor(
     public loggedUser: LoggedUserService,
    public alert: AlertService,
    public storage: StorageService) { }

}
