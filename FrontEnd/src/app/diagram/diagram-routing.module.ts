import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BuilderComponent } from './builder/builder.component';
import { ListComponent } from './list/list.component';

  const routes: Routes = [
    {
      path:"",
      component:ListComponent,
    },
  {
    path:"list",
    component:ListComponent,
  },
  {
    path:"create",
    component:BuilderComponent,
    data:{pageState:"create"}
  },
  {
    path:"edit/:id",
    component:BuilderComponent,
    data:{pageState:"edit"}
    },
  {
    path:"downlaod/:id",
    component:BuilderComponent,
    data:{pageState:"downlaod"}
  },
]


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DiagramRoutingModule { }
