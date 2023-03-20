import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IAuth } from 'src/app/utils/interfaces/user.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { DigramService } from '../digram.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: []
})
export class CreateComponent implements OnInit {

  createForm = new FormGroup({
    userName: new FormControl(null, Validators.required),
    password: new FormControl(null, Validators.required)
  })
  isErrorSubmited = false;


  constructor(private utilsService: UtilsService, private digramService: DigramService, private router: Router) {
  }

  ngOnInit(): void {
  }

  /** Log In API */
  logIn() {
    if (this.createForm.invalid) {
      this.isErrorSubmited = true;
      this.utilsService.alert.errorMessage(null, "Enter Digram Information");
      return;
    }

    this.digramService.create<IAuth>(this.createForm.value)
      .then(res => {
        this.utilsService.alert.message(res);
        if (res.isSuccess) {
        //Rout To List Page
          this.router.navigateByUrl('/digram/list');
        }
      }).catch(error => this.utilsService.alert.canRequestError(error))

  }

}
