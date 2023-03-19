import { Component, OnInit } from '@angular/core';
import { UtilsService } from './utils/services/utils.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  /**
   *
   */
  constructor(private utilsService:UtilsService) {

  }
  ngOnInit(): void {
  this.utilsService.loggedUser.loadUserInformation();
  }

}
