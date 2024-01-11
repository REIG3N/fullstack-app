import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';
import { SharedEmployeeService } from 'src/app/services/shared-employee.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css'],
})
export class EditEmployeeComponent implements OnInit {
  employeeDetails: Employee = {
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    departement: '',
  };

  constructor(
    private route: ActivatedRoute,
    private employeesService: EmployeesService,
    private router: Router,
    public sharedList: SharedEmployeeService
  ) {}

  // -------------     Ancienne méthode avec appel API     -------------
  // ngOnInit(): void {
  //   this.route.paramMap.subscribe({
  //     next: (params) => {
  //       const id = params.get('id');
  //       console.log(id);
  //       console.log(this.sharedList.userList);
  //       console.log(this.employeeDetails);
  //       if (id) {
  //         // this.EmployeesListComponent.employee
  //         // const selectedId = (<HTMLInputElement>document.getElementById(id)).value
  //         // console.log(selectedId)
  //         this.employeesService
  //           .getEmployee(id)
  //           // this.findEmployee(id)
  //           .subscribe({
  //             next: (response) => {
  //               this.employeeDetails = response;
  //               console.log(response);
  //               console.log(this.employeeDetails);
  //             },
  //           });
  //       }
  //     },
  //   });
  // }

  ngOnInit(): void {
    this.employeeDetails = this.sharedList.employeeDetails;
  }

  updateEmployee() {
    console.log(this.employeeDetails);

    this.employeesService
      .updateEmployee(this.employeeDetails.id, this.employeeDetails)
      .subscribe({
        next: (response) => {
          this.router.navigate(['employees']);
        },
      });
  }

  deleteEmployee(id: string) {
    this.employeesService.deleteEmployee(id).subscribe({
      next: (response) => {
        this.router.navigate(['employees']);
      },
    });
  }
}
