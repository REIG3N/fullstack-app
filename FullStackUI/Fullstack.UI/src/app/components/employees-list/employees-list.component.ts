import { Component, Input, OnInit, Output } from '@angular/core';
import { Employee } from '../../models/employee.model';
import { EmployeesService } from '../../services/employees.service';
import { SharedEmployeeService } from 'src/app/services/shared-employee.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.css'],
})
export class EmployeesListComponent implements OnInit {
  @Input() employees: Employee[] = [];
  constructor(
    private employeesService: EmployeesService,
    private shareEmployees: SharedEmployeeService
  ) {}

  ngOnInit(): void {
    this.employeesService.getAllEmployees().subscribe({
      next: (employees) => {
        this.employees = employees;
        
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  AddEmployee(EmployeeToStock: Employee) {
    this.shareEmployees.employeeDetails = EmployeeToStock; 
  }
}
