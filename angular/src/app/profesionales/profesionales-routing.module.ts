import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfesionalesComponent } from './profesionales.component';
import { permission } from 'process';
import { authGuard, permissionGuard } from '@abp/ng.core';


const routes: Routes = [{ path: '', component: ProfesionalesComponent, canActivate: [authGuard, permissionGuard] }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfesionalesRoutingModule { }