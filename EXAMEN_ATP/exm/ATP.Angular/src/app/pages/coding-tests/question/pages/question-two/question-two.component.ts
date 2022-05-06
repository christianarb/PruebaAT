import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../models/employee.model';
import { Project } from '../../models/project.model';
import { ProjectEmployee } from '../../models/project_employee.model';
import { QuestionService } from '../../services/question.service';
import {MessageService} from 'primeng/api';

interface Projects {
  name: string;
  code: string;
}
interface Employees {
  name: string;
  code: string;
}
@Component({
  selector: 'app-question-two',
  templateUrl: './question-two.component.html',
  styleUrls: ['./question-two.component.scss'],
})
export class QuestionTwoComponent implements OnInit {
  projecs: Project[] = [];
  employees: Employee[] = [];
  combo1: Projects[] = [];
  combo2: Employees[] = [];
  formProjectEmployee: FormGroup;

  constructor(
    private _questionService: QuestionService,
    private _formBuilder: FormBuilder,
    private messageService: MessageService
  ) {}
  ngOnInit(): void {
    this.formProjectEmployee = this._formBuilder.group({
      projectId: ['', [Validators.required]],
      employeeId: ['', [Validators.required]],
      role: ['', [Validators.required]],
    });

    this._getEmployees();
    this._getProjects();
  }

  private _getEmployees(): void {
    this._questionService.getEmployees().subscribe((employees) => {
      this.employees = employees;
      let temp;
      this.employees.forEach((element) => {
        temp.push({
          name: element.name,
          code: element.employeeId,
        });
      });
      this.combo1 = temp;
    });
  }

  private _getProjects(): void {
    this._questionService.getProjects().subscribe((projects) => {
      this.projecs = projects;
      let temp = [];
      this.projecs.forEach((element) => {
        temp.push({
          name: element.title,
          code: element.projectId,
        });
      });
      this.combo2 = temp;
    });
  }

  public saveForm(): void {
    if (this.formProjectEmployee.valid) {
      let projectEmployee = new ProjectEmployee();
      projectEmployee.projectId = this.formProjectEmployee.get('projectId').value;
      projectEmployee.employeeId = this.formProjectEmployee.get('employeeId').value;
      projectEmployee.role = this.formProjectEmployee.get('Role').toString();

      this._questionService.saveProjectEmployee(projectEmployee).subscribe( (projectEmployee) => {
          this.messageService.add({severity:'success', summary:'Exito', detail:'Se guardo correctameneata.'});
      }, (error) => {
        this.messageService.add({severity:'error', summary:'Error', detail:'Error al guardar.'});
      });
    } else {
      this.messageService.add({severity:'error', summary:'Error', detail:'Error al guardar.'});
    }
  }

}
