import { NgModule } from '@angular/core';

import { ClienteRoutingModule } from './cliente-routing.module';
import { ClienteComponent } from './cliente.component';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    ClienteComponent
  ],
  imports: [
    SharedModule,
    ClienteRoutingModule,
    NgbDatepickerModule
  ]
})
export class ClienteModule { }
