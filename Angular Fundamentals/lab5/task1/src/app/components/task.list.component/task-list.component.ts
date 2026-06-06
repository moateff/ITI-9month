import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskType } from '../../types/task.type';
import { TaskComponent } from '../task.component/task.component';


@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [TaskComponent],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent {

  @Input()
  tasks: TaskType[] = [];
}
