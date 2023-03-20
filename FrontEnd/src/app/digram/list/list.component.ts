import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IDigram } from 'src/app/utils/interfaces/digram.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { DigramService } from '../digram.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: []
})
export class ListComponent implements OnInit {

  digrams:IDigram[] =[];
  isLoading = false;

  constructor(private utilsService: UtilsService, private digramService: DigramService, private router: Router) {

  }
  ngOnInit(): void {

  }

  /** Log In API */
  logIn() {
this.isLoading=true;
    this.digramService.list<IDigram[]>()
      .then(res => {
        this.utilsService.alert.message(res);
        if (res.isSuccess) {
          this.digrams=res.result
        }
      }).catch(error => this.utilsService.alert.canRequestError(error))
      .finally(()=>{
this.isLoading=true;
      })

  }

}
