import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CitaComponent } from './cita.component';
import { SharedModule } from '../shared/shared.module';
import { CitaRoutingModule } from './cita-routing.module';

// If you need modal functionality, import the correct ABP modal module.
// import { AbpModalModule } from '@abp/ng.theme.shared'; // Adjust or remove this line if the module does not exist

@NgModule({
  declarations: [CitaComponent],
  imports: [
    CommonModule,
    SharedModule,
    CitaRoutingModule,
    // Add the correct modal module here if needed, e.g., AbpModalModule, after verifying its existence
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA] // Add this line if abp-modal is a web component
})
export class CitaModule { }
  