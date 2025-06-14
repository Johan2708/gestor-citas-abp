import { NgModule } from '@angular/core';


import { CitaRoutingModule } from './cita-routing.module';
import { CitaComponent } from './cita.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    CitaComponent
  ],
  imports: [
    SharedModule,
    CitaRoutingModule
  ]
})
export class CitaModule { }
