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
    .diagram-demo{
      height:350px
    }

    [type='range']{
      -webkit-appearance: none;
      width: 100%;
      height: 25px;
      outline: none;
      opacity: 0.7;
      -webkit-transition: .2s;
      transition: opacity .2s;
    }
    `
  ]
})
export class GeometryStringToolComponent implements OnInit {
  @Output('add') onAdd = new EventEmitter<any>();

  form = new FormGroup({
    color: new FormControl('#ffe74d'),

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
  shape: any;
  enterType:any="slider";
  min=0;
  max=250;
  inputType="range";

  constructor() {
  }

  ngOnInit(): void {
    this.initGOJS();
    this.applyChanges();
  }

  /**
   * Init GO JS
   */
  initGOJS() {
    this.goJsAPP = new GoJsAPP(null, 'myDiagramDemo');
    this.goJsAPP.load({})
    this.shape = this.goJsAPP.shape.add(this.buildOptions());
  }

  /** On Form Submit */
  submit() {
    this.onAdd.emit(this.buildOptions());
  }

  /** Live Demo Privew */
  applyChanges() {
    this.form.valueChanges.subscribe(va => {
      let newOptions = this.buildOptions();
      this.goJsAPP.shape.update(this.shape, 'geometryString', newOptions.geometryString)
      this.goJsAPP.shape.update(this.shape, 'fill', newOptions.fill)
    })
  }

  /** Build Options */
  buildOptions() {
    return {
      geometryString: this.buildGeometryString(),
      fill: this.form.value.color,
    }
  }

  /** Build Geometry String */
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

