import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

  const routes: Routes = [
  {
path:'',
pathMatch:"full",
component:HomeComponent
  },
  {
    path:'user',
    loadChildren:() => import('./user/user.module').then(m => m.UserModule)
      }
]


@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }