import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskType } from '../../types/task-type';
import { PriorityEnum } from '../../enums/priority-enum';
import { CategoryEnum } from '../../enums/category-enum';
import { FormsModule } from '@angular/forms';
import { v4 as uuidv4 } from 'uuid';
import { StatusEnum } from '../../enums/status-enum';
import { ActionType } from '../../types/action-type';

@Component({
  selector: 'app-task-form',
  imports: [FormsModule],
  standalone: true,
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent {

  StatusEnum = StatusEnum;
  PriorityEnum = PriorityEnum;
  CategoryEnum = CategoryEnum;

  @Input()
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
  };

  @Output()
  onAction: EventEmitter<ActionType> = new EventEmitter<ActionType>();

  addTask() {
    this.generateId();

    const task: TaskType = this.cloneTask();

    this.onAction.emit({ task, type: 'add' });

    this.resetTask();
  }

  saveTask() {
    const task: TaskType = this.cloneTask();

    this.onAction.emit({ task, type: 'save' });

    this.resetTask();
  }

  generateId() {
    this.task.id = uuidv4();
  }

  cloneTask() {
    return { ...this.task };
  }

  resetTask() {
    this.task = {
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
