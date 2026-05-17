import { Component } from '@angular/core';
import { TaskFormComponent } from '../task-form.component/task-form.component';
import { TaskListComponent } from '../task-list.component/task-list.component';

@Component({
  selector: 'app-task',
  imports: [TaskFormComponent, TaskListComponent],
  standalone: true,
  templateUrl: './task.component.html',
  styleUrl: './task.component.css'
})
export class TaskComponent {}
