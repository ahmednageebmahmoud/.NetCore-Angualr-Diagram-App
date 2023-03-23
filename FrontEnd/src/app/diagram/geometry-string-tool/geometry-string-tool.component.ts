import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
declare var GoJsAPP: any;

@Component({
  selector: 'app-geometry-string-tool',
  templateUrl: './geometry-string-tool.component.html',
  styles: [
    `
    input{
      width: 100px;
    border: none;
    border-bottom: 1px solid #f00;
    background: #fff0c1;
    outline: none;
    }
    `
  ]
})
export class GeometryStringToolComponent implements OnInit {
  @Output('add') onAdd = new EventEmitter<any>();

  form = new FormGroup({
    color: new FormControl('white'),

    m: new FormGroup({
      x: new FormControl(0),
      y: new FormControl(0)
    }),
    l1: new FormGroup({
      x: new FormControl(100),
      y: new FormControl(0)
    }),
    l2: new FormGroup({
      x: new FormControl(100),
      y: new FormControl(100)
    }),
    q1: new FormGroup({
      x1: new FormControl(100),
      y1: new FormControl(100),
      x: new FormControl(0),
      y: new FormControl(100)
    }),
    q2: new FormGroup({
      x1: new FormControl(100),
      y1: new FormControl(100),
      x: new FormControl(0),
      y: new FormControl(100)
    })
  })
  goJsAPP: any;

  constructor() {
  }

  ngOnInit(): void {
this.initGOJS();
  }

  /**
   * Init GO JS
   */
  initGOJS() {
    this.goJsAPP = new GoJsAPP(null, 'myDiagramDemo');
    this.goJsAPP.load({})
   this.goJsAPP.addShep(this.buildOptions())
  }


  submit() {

    this.onAdd.emit(this.buildOptions());
  }

  buildOptions() {
    return {
      geometryString: this.buildGeometryString(),
      fill: this.form.value.color
    }
  }
  buildGeometryString() {
    return 'F ' +
      `M${this.form.value.m?.x} ${this.form.value.m?.y} ` +
      `L${this.form.value.l1?.x} ${this.form.value.l1?.y} ` +
      `Q${this.form.value.q1?.x1} ${this.form.value.q1?.y1} ${this.form.value.q1?.x} ${this.form.value.q1?.y} ` +
      `L${this.form.value.l2?.x} ${this.form.value.l2?.y} ` +
      `Q${this.form.value.q2?.x1} ${this.form.value.q2?.y1} ${this.form.value.q2?.x} ${this.form.value.q2?.y} ` +
      'z';
  }
}

