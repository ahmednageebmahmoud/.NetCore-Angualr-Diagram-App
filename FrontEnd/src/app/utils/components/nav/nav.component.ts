import { Component, OnInit } from '@angular/core';
import { IMenu } from '../../interfaces/menu.interface';
import { MenuService } from '../../services/menu.service';
import { UtilsService } from '../../services/utils.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: []
})
export class NavComponent implements OnInit {

menu:IMenu[]=[];

constructor(private menuService:MenuService,private utilsService:UtilsService) {
}
  ngOnInit(): void {
    this.menu=this.menuService.getMenu(!this.utilsService.loggedUser.isLoggedIn);

    this.utilsService.loggedUser.userState$.subscribe(user=>{
      debugger
  this.menu=this.menuService.getMenu(!this.utilsService.loggedUser.isLoggedIn);
});
  }



}
