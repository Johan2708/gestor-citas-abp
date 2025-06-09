import { NgModule } from '@angular/core';

import { ClienteRoutingModule } from './cliente-routing.module';
import { ClienteComponent } from './cliente.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    ClienteComponent
  ],
  imports: [
    SharedModule,
    ClienteRoutingModule
  ]
})
export class ClienteModule { }
