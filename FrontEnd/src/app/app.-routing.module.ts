import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AnonymouslyCanActive } from './utils/services/guard/anonymously-canactive';
import { GurdCanActive } from './utils/services/guard/gurd-canactive';

const routes: Routes = [
  {
    path: '',
    pathMatch: "full",
    component: HomeComponent
  },
  {
    path: 'user',
    loadChildren: () => import('./user/user.module').then(m => m.UserModule)
  },
  {
    path: 'diagram',
    loadChildren: () => import('./diagram/diagram.module').then(m => m.DiagramModule),
  canActivate: [GurdCanActive] 
  }
]


@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
