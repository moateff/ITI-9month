import { Component, EventEmitter, Input, Output, signal } from '@angular/core';
import { HeaderComponent } from './components/header.component/header.component';
import { SliderComponent } from "./components/slider.component/slider.component";
import { TaskFormComponent } from './components/task-form.component/task-form.component';
import { TasksBoardComponent } from "./components/tasks-board.component/tasks-board.component";
import { TaskType } from './types/task-type';
import { MessageType } from './types/message-type';
import { StatusEnum } from './enums/status-enum';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, SliderComponent, TaskFormComponent, TasksBoardComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('task1');

  action: MessageType = {
    task: this.createEmptyTask(),
    type: 'add'
  };

  handleFormAction(action: MessageType): void {
    this.action = action;

    console.log('from form', action);
  }

  handleBoardAction(action: MessageType): void {
    this.action = action;

    console.log('from board', action);
  }

  createEmptyTask(): TaskType {
    return {
      id: '',
      title: '',
      description: '',
      priority: '',
      startDate: new Date(),
      dueDate: new Date(),
      category: '',
      tags: '',
      status: StatusEnum.IN_PROGRESS
    };
  }
}
