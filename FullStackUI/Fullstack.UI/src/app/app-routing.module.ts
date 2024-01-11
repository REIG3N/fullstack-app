import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesListComponent } from './components/employees-list/employees-list.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EditEmployeeComponent } from './components/edit-employee/edit-employee.component';
import { DepartementListComponent } from './components/departement-list/departement-list.component';
import { EditDepartementComponent } from './components/edit-departement/edit-departement.component';

const routes: Routes = [
  {
    path:'',
    component: DepartementListComponent,
  },
  {
    path:'employees',
    component: EmployeesListComponent,
  },  
  {
    path:'employees/add',
    component: AddEmployeeComponent,
  },
  {
    path:'employees/edit/:id',
    component: EditEmployeeComponent,
  },
  {
    path:'department',
    component: DepartementListComponent,
  },  
  {
    path:'departments/:departementid',
    component: EditDepartementComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
