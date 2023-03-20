import { NgModule } from '@angular/core';
import { UtilsModule } from '../utils/utils.module';
import { CreateComponent } from './create/create.component';
import { DiagramRoutingModule } from './diagram-routing.module';
import { DiagramService } from './diagram.service';
import { ListComponent } from './list/list.component';


@NgModule({
  imports: [DiagramRoutingModule,UtilsModule],
  exports: [],
  declarations: [CreateComponent,ListComponent],
  providers: [DiagramService],
})
export class DiagramModule { }
