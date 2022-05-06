import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from '../models/project.model';
import { Employee } from '../models/employee.model';
import { ProjectEmployee } from '../models/project_employee.model';

@Injectable({
  providedIn: 'root'
})
export class QuestionService {

  constructor(private _http: HttpClient) { }

  public getProjects(): Observable<Project[]> {
    return this._http.get<Project[]>(`https://localhost:44338/api/Business/projects`);
  }
  public getEmployees(): Observable<Employee[]> {
    return this._http.get<Employee[]>(`https://localhost:44338/api/Business/employees`);
  }
  public saveProjectEmployee(projectEmployee: ProjectEmployee): Observable<ProjectEmployee[]>{
    return this._http.post<ProjectEmployee[]>(`https://localhost:44338/api/Business/saveProjectEmployee`, projectEmployee)
  }
}
