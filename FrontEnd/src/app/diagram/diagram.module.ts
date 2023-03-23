import { NgModule } from '@angular/core';
import { UtilsModule } from '../utils/utils.module';
import { BuilderComponent } from './builder/builder.component';
import { DiagramRoutingModule } from './diagram-routing.module';
import { DiagramService } from './diagram.service';
import { GeometryStringToolComponent } from './geometry-string-tool/geometry-string-tool.component';
 import { ListComponent } from './list/list.component';


@NgModule({
  imports: [DiagramRoutingModule,UtilsModule],
  exports: [],
  declarations: [BuilderComponent,ListComponent,GeometryStringToolComponent],
  providers: [DiagramService],
})
export class DiagramModule { }
