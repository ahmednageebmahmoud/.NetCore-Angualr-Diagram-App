import { NgModule } from '@angular/core';
import { UtilsModule } from '../utils/utils.module';
import { LogInComponent } from './log-in/log-in.component';
import { LogOutComponent } from './log-out/log-out.component';
import { UserRoutingModule } from './user-routing.module';
import { UserService } from './user.service';


@NgModule({
  imports: [UserRoutingModule,UtilsModule],
  exports: [],
  declarations: [LogInComponent,LogOutComponent],
  providers: [UserService],
})
export class UserModule { }
