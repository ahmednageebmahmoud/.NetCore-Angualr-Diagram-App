import { EventEmitter, Injectable } from '@angular/core';
import jwtDecode from 'jwt-decode';
import { IUser } from '../interfaces/user.interface';
import { StorageService } from './storage.service';

// Must Be Provided in Rool Because We Use UserStates In All Apps To Refresh The Menu And So On, Don't Forget That
@Injectable({providedIn:"root"})

export class LoggedUserService {
  /** Is Current User Is Logged In */
  isLoggedIn = false;

  /** Current Logged User Information */
  loogedUserInfo: IUser = null as any;

  /** User State Will Emit Every Time We Decode User Information From Access Toek */
  userState$ = new EventEmitter();

  constructor(private storage: StorageService) {

  }
  /**
   * Reload user information and emit an event to update the user state.
   */
  loadUserInformation() {
    let accessToken = this.storage.accessToken;
    if (!accessToken || accessToken == "") {
      this.isLoggedIn = false;
      this.loogedUserInfo = null as any;
      this.userState$.emit()
      return
    }
    this.loogedUserInfo = jwtDecode<IUser>(accessToken);
    this.isLoggedIn = true;
    this.userState$.emit();
    console.log(this.loogedUserInfo);
  }


}// End Class
