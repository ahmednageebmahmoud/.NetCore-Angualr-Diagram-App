import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IAuth } from 'src/app/utils/interfaces/user.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { DiagramService } from '../diagram.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: []
})
export class CreateComponent implements OnInit {

  createForm = new FormGroup({
    name: new FormControl(null, Validators.required),
    tag: new FormControl(null, Validators.required)
  })
  isErrorSubmited = false;


  constructor(private utilsService: UtilsService, private diagramsService: DiagramService, private router: Router) {
  }

  ngOnInit(): void {
  }

  /** Create API */
  create() {
    if (this.createForm.invalid) {
      this.isErrorSubmited = true;
      this.utilsService.alert.errorMessage(null, "Enter Diagram Information");
      return;
    }

    this.diagramsService.create<IAuth>(this.createForm.value)
      .then(res => {
        this.utilsService.alert.message(res);
        if (res.isSuccess) {
        //Rout To List Page
          this.router.navigateByUrl('/diagram/list');
        }
      }).catch(error => this.utilsService.alert.canRequestError(error))

  }

}
