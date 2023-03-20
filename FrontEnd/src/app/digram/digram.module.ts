import { NgModule } from '@angular/core';
import { UtilsModule } from '../utils/utils.module';
import { CreateComponent } from './create/create.component';
import { DigramRoutingModule } from './digram-routing.module';
import { DigramService } from './digram.service';
import { ListComponent } from './list/list.component';


@NgModule({
  imports: [DigramRoutingModule,UtilsModule],
  exports: [],
  declarations: [CreateComponent,ListComponent],
  providers: [DigramService],
})
export class DigramModule { }
