import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IAuth } from 'src/app/utils/interfaces/user.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './log-in.component.html',
  styleUrls: []
})
export class LogInComponent implements OnInit {

  loginForm = new FormGroup({
    userName: new FormControl(null, Validators.required),
    password: new FormControl(null, Validators.required)
  })
  isErrorSubmited = false;
  isLoading=false;

  constructor(private utilsService: UtilsService, private userService: UserService, private router: Router) {

  }
  ngOnInit(): void {

  }

  /** Log In API */
  logIn() {
    if (this.loginForm.invalid) {
      this.isErrorSubmited = true;
      this.utilsService.alert.errorMessage(null, "Enter Login Information");
      return;
    }
    this.loginForm.disable();
    this.isLoading=true;
    this.userService.login<IAuth>(this.loginForm.value)
      .then(res => {
        this.utilsService.alert.message(res);
        if (res.isSuccess) {
          //Save Access Token In Cookies
          this.utilsService.storage.accessToken = res.result.token;
          //Reload user information and emit an event to update the user state.
          this.utilsService.loggedUser.loadUserInformation();
          //Route To Home Page
          this.router.navigateByUrl('/');
        }
      }).catch(error => this.utilsService.alert.canRequestError(error))
      .finally(() => {
        this.loginForm.enable();
    this.isLoading=false;
  })
  }
}
