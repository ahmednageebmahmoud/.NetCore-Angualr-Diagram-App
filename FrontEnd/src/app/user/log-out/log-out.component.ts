import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IAuth } from 'src/app/utils/interfaces/user.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { UserService } from '../user.service';

@Component({
  selector: 'app-logout',
  template: '',
  styleUrls: []
})
export class LogOutComponent implements OnInit {
  constructor(private utilsService: UtilsService, private router: Router) {

  }
  ngOnInit(): void {
  //Remvoe Access Token In Cookies
  this.utilsService.storage.accessToken = null;
  //Reload user information and emit an event to update the user state.
  this.utilsService.loggedUser.loadUserInformation();
  //Rout To Home Page
  this.router.navigateByUrl('/');
  this.utilsService.alert.infoMesage("Log Out Success Fully")
  }


}
