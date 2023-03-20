import { Injectable } from '@angular/core';
import { IMenu } from '../interfaces/menu.interface';

@Injectable()
export class MenuService {

  private   menu: IMenu[] = [
    {
      name: "Login",
      isAnonymous: true,
      url: '/user/log-in'
    },
    {
      name: "Digrams",
      isAnonymous: true,
      url: '/digram/list'
    },
    {
      name: "Create Digram",
      isAnonymous: true,
      url: '/digram/create'
    },
    {
      name: "Log Out",
      isAnonymous: false,
      url: '/user/log-out'
    }
  ];

  getMenu(isAnonymous:boolean){
return this.menu.filter(c=> c.isAnonymous==isAnonymous);
  }
}
