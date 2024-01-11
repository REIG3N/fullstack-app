import { Component, OnInit } from '@angular/core';
import { Departement } from 'src/app/models/departement.model';
import { DepartementService } from 'src/app/services/departement.service';
import { SharedEmployeeService } from 'src/app/services/shared-employee.service';

@Component({
  selector: 'app-departement-list',
  templateUrl: './departement-list.component.html',
  styleUrls: ['./departement-list.component.css']
})
export class DepartementListComponent implements OnInit {
  departements: Departement[] = [];
  constructor(
    private departementsService: DepartementService,
    private shareEmployees: SharedEmployeeService

  ) { }

  ngOnInit(): void {
    this.departementsService.getAllDepartements().subscribe({
      next: (departement) => {
        this.departements = departement;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  AddDepartement(DepartementToStock: Departement) {
    this.shareEmployees.departementDetails = DepartementToStock; 
    console.log(DepartementToStock)
    console.log(this.shareEmployees.departementDetails)
  }

}
