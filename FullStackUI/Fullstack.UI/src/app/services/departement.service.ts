import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Departement } from '../models/departement.model';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class DepartementService {
  baseApiUrl: string = environment.baseApiUrl;
  constructor(private http: HttpClient) { }  
  departements: Departement[] = [];


getAllDepartements(): Observable<Departement[]> {
  let AllDepartementData = this.http.get<Departement[]>(this.baseApiUrl + '/api/departments/');
  return AllDepartementData;
}

}