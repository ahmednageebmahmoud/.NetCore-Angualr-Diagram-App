import { Component } from '@angular/core';
import { UtilsService } from '../utils/services/utils.service';

@Component({
  selector: 'app-root',
  templateUrl: './home.component.html',

})
export class HomeComponent {
  /**
   *
   */
  constructor(public utilsService:UtilsService) {
    
  }
}
