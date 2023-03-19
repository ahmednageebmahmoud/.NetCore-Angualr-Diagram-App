import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnonymouslyCanActive } from '../utils/services/guard/anonymously-canactive';
import { GurdCanActive } from '../utils/services/guard/gurd-canactive';
import { LogInComponent } from './log-in/log-in.component';
import { LogOutComponent } from './log-out/log-out.component';

  const routes: Routes = [
  {
    path:"log-in",
    component:LogInComponent,
    canActivate:[AnonymouslyCanActive]
  },
  {
    path:"log-out",
    component:LogOutComponent,
    canActivate:[GurdCanActive]
  }
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
