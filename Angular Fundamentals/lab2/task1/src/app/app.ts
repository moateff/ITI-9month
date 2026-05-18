import { Component, EventEmitter, Input, Output, signal } from '@angular/core';
import { HeaderComponent } from './components/header.component/header.component';
import { SliderComponent } from "./components/slider.component/slider.component";
import { TaskFormComponent } from './components/task-form.component/task-form.component';
import { TasksBoardComponent } from "./components/tasks-board.component/tasks-board.component";
import { TaskType } from './types/task-type';
import { Action } from 'rxjs/internal/scheduler/Action';
import { ActionType } from './types/action-type';
import { StatusEnum } from './enums/status-enum';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, SliderComponent, TaskFormComponent, TasksBoardComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('task1');

  @Output()
  tasks: TaskType[] = [];

  @Output()
  task: TaskType = {
    id: '',
    title: '',
    description: '',
    priority: '',
    startDate: new Date(),
    dueDate: new Date(),
    category: '',
    tags: '',
    status: StatusEnum.IN_PROGRESS
  }

  actionTask(action: ActionType) {
    if (!action.task) {
      return;
    }

    switch (action.type) {
      case 'add':
        console.log('Add task:', action.task?.id);
        this.tasks.unshift(action.task);
        break;
      case 'complete':
        console.log('Complete task:', action.task?.id);
        action.task.status = StatusEnum.COMPLETED;
        break;
      case 'update':
        console.log('Update task:', action.task?.id);
        this.task = {...action.task};
        break;
      case 'delete':
        console.log('Delete task:', action.task?.id);
        this.tasks = this.tasks.filter(t => t.id !== action.task?.id);
        break;
      case 'save':
        console.log('Save task:', action.task?.id);
        this.tasks = this.tasks.map(t => t.id === action.task?.id ? action.task : t);
        break;
    }

    this.tasks = [...this.tasks];
    console.log(this.tasks);
  }
}
