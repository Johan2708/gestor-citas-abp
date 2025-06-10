import { NgModule } from '@angular/core';

import { ProfesionalesRoutingModule } from './profesionales-routing.module';
import { ProfesionalesComponent } from './profesionales.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ProfesionalesComponent
  ],
  imports: [
    SharedModule,
    ProfesionalesRoutingModule
  ]
})
export class ProfesionalesModule { }