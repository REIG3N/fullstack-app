import { Injectable } from '@angular/core';
import { Employee } from '../models/employee.model';
import { BehaviorSubject } from 'rxjs';
import { Departement } from '../models/departement.model';

@Injectable({
  providedIn: 'root',
})
export class SharedEmployeeService {
  constructor() {}
  public employeeDetails: Employee = {
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    departement: '',
  };

  public departementDetails: Departement = {
    id: '',
    name: '',
  }
}
