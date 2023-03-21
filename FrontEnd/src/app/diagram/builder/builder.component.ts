import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IDiagram } from 'src/app/utils/interfaces/diagram.interface';
import { UtilsService } from 'src/app/utils/services/utils.service';
import { DiagramService } from '../diagram.service';
declare var GoJsAPP: any;

@Component({
  selector: 'app-builder',
  templateUrl: './builder.component.html',
  styleUrls: []
})
export class BuilderComponent implements OnInit {

  createForm = new FormGroup({
    name: new FormControl(null, Validators.required),
    tag: new FormControl(null, Validators.required)
  })
  isErrorSubmited = false;
  goJsAPP: any;
  pageState: "create" | "downlaod" | "edit" = "create";
  id: number = null as any;
  constructor(private utilsService: UtilsService, private diagramsService: DiagramService,
    private activiatedRouter: ActivatedRoute, private router: Router) {
  }

  ngOnInit(): void {
    //Read Page State
    this.activiatedRouter.data
      .subscribe((dt: any) => this.pageState = dt.pageState);
    //Read Daigram Id
    this.activiatedRouter.params
      .subscribe((pm: any) => {
        this.id = pm.id;
        if (this.id)
          this.query();
      });
    //Image GO JS
    this.initGOJS();
  }

  /** Get Diagram API */
  query() {
    this.diagramsService.get<IDiagram>(this.id)
      .then(res => {
        if (res.isSuccess) {
          this.createForm.controls.tag.setValue(res.result.tag as any);
          this.createForm.controls.name.setValue(res.result.name as any);
        } else {
          this.utilsService.alert.message(res);
        }
      }).catch(error => this.utilsService.alert.canRequestError(error))

  }
  /** Create API */
  create() {

    if (this.createForm.invalid) {
      this.isErrorSubmited = true;
      this.utilsService.alert.errorMessage(null, "Enter Diagram Information");
      return;
    }

    this.diagramsService.create({
      ...this.createForm.value,
      diagram: this.goJsAPP.save()
    })
      .then(res => {
        this.utilsService.alert.message(res);
        if (res.isSuccess) {
          //Rout To List Page
          this.router.navigateByUrl('/diagram/list');
        }
      }).catch(error => this.utilsService.alert.canRequestError(error))

  }

  /**
   * Downlaod Image
   */
  downlaodImage() {
    this.goJsAPP.export.image(this.createForm.controls.tag)
  }

  /**
   * Image GO JS
   */
  initGOJS() {
    this.goJsAPP = new GoJsAPP('myPaletteDiv', 'myDiagramDiv');
    this.goJsAPP.load({})
  }
}