import { NgModule } from '@angular/core';
import { ProfesionalesRoutingModule } from './profesionales-routing.module';
import { ProfesionalesComponent } from './profesionales.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    ProfesionalesComponent
  ],
  imports: [
    SharedModule,
    ProfesionalesRoutingModule,
    NgbDatepickerModule
  ]
})
export class ProfesionalesModule { }