import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { IDiagram } from 'src/app/utils/interfaces/diagram.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { DiagramService } from '../diagram.service';
@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: []
})
export class ListComponent implements OnInit {

  diagrams: IDiagram[] = [];
  isLoading = false;
  isSuccessRequest = false;

  constructor(private utilsService: UtilsService, private diagramsService: DiagramService, private router: Router) {

  }
  ngOnInit(): void {
    this.query();
  }

  /** Load Diagrams API */
  query() {
    this.isLoading = true;
    this.isSuccessRequest = false;

    this.diagramsService.list<IDiagram[]>()
      .then(res => {
        this.isSuccessRequest = res.isSuccess;

        if (res.isSuccess) {
          this.diagrams = res.result
        } else {

          this.utilsService.alert.message(res);
        }
      }).catch(error => {
        this.isSuccessRequest = false;

        this.utilsService.alert.canRequestError(error)
      }
      )
      .finally(() => {
        this.isLoading = false;

      })
  }


  
  /** Delete Diagram API */
  delete(diagram:IDiagram) {
     diagram.isDeleting = true;
    this.diagramsService.delete(diagram.id)
      .then(res => {
        this.utilsService.alert.message(res);
        if (res.isSuccess) {
          this.diagrams.splice(this.diagrams.findIndex(c=> c.id==diagram.id),1);
        } 
      }).catch(error => {
        this.utilsService.alert.canRequestError(error)
      }
      )
      .finally(() => {
        diagram.isDeleting = false;
      })

  }
}
