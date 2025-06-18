import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CitaComponent } from './cita.component';
import { SharedModule } from '../shared/shared.module';
import { CitaRoutingModule } from './cita-routing.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [CitaComponent],
  imports: [
    SharedModule,
    CitaRoutingModule,
    NgbDatepickerModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA] // Add this line if abp-modal is a web component
})
export class CitaModule { }
  