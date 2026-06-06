import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskType } from '../../types/task-type';
import { PriorityEnum } from '../../enums/priority-enum';
import { CategoryEnum } from '../../enums/category-enum';
import { FormsModule } from '@angular/forms';
import { v4 as uuidv4 } from 'uuid';
import { StatusEnum } from '../../enums/status-enum';
import { MessageType } from '../../types/message-type';

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
  action: MessageType = {
    task: this.createEmptyTask(),
    type: 'add'
  };

  @Output()
  onAction = new EventEmitter<MessageType>();

  task: TaskType = this.createEmptyTask();

  ngOnChanges(): void {
    if (this.action.type === 'update') {
      if (!this.action.task) {
        throw new Error('Task is required');
      }

      this.task = { ...this.action.task };
    } else {
      this.resetTask();
    }
  }

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
    this.task = this.createEmptyTask();
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
