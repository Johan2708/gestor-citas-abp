import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './cliente.component';
import { authGuard, permissionGuard } from '@abp/ng.core';

const routes: Routes = [
  { path: '', 
    component: ClienteComponent,
    canActivate: [authGuard, permissionGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClienteRoutingModule { }
