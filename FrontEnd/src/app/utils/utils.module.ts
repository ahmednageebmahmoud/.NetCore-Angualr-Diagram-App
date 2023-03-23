import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { NavComponent } from './components/nav/nav.component';
import { AlertService } from './services/alert.service';
import { MenuService } from './services/menu.service';
import { StorageService } from './services/storage.service';
import { UtilsService } from './services/utils.service';


const components=[
  NavComponent
]
@NgModule({
  declarations: components,
  imports: [
    RouterModule,
    FormsModule      ,
    CommonModule,
    ReactiveFormsModule

  ],
  providers: [
    CookieService,
    MenuService,
    AlertService,
    UtilsService,
    StorageService,
  ],
  exports:[...components,CommonModule,ReactiveFormsModule,FormsModule],
})
export class UtilsModule { }
