import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';
import { Observable } from 'rxjs';
import { SharedEmployeeService } from './shared-employee.service';
import { DepartementService } from './departement.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeesService {
  baseApiUrl: string = environment.baseApiUrl;
  departementId: string = this.shareEmployees.departementDetails.id;
  constructor(
    private http: HttpClient,
    private shareEmployees: SharedEmployeeService,
    ) {}  
  employees: Employee[] = [];

 getAllEmployees(): Observable<Employee[]> {
  let AllEmployeeData = this.http.get<Employee[]>(this.baseApiUrl + `/api/department/${this.departementId}/employee`);
  console.log(this.baseApiUrl + `/api/department/${this.departementId}/employee/`)
  return AllEmployeeData;
}
  
  addEmployee(addEmployeeRequest: Employee): Observable<Employee>  {
    addEmployeeRequest.id ='00000000-0000-0000-0000-000000000000'
    return this.http.post<Employee>(this.baseApiUrl + '/api/employees/', addEmployeeRequest);
  }
  getEmployee(id: string): Observable<Employee> {
    return this.http.get<Employee>(this.baseApiUrl + '/api/employees/' + id)
  }

  updateEmployee(id: string, updateEmployeeRequest: Employee): Observable<Employee>  {
    return this.http.put<Employee>(this.baseApiUrl + '/api/employees/' + id, updateEmployeeRequest)
  }

  deleteEmployee(id: string): Observable<Employee>  {
    return this.http.delete<Employee>(this.baseApiUrl + '/api/employees/' + id)

  }








  
}

