import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskType } from '../../types/task-type';
import { CommonModule } from '@angular/common';
import { CategoryEnum } from '../../enums/category-enum';
import { PriorityEnum } from '../../enums/priority-enum';
import { StatusEnum } from '../../enums/status-enum';
import { MessageType } from '../../types/message-type';

@Component({
  selector: 'app-task',
  imports: [CommonModule],
  standalone: true,
  templateUrl: './task.component.html',
  styleUrl: './task.component.css'
})
export class TaskComponent {

  CategoryEnum = CategoryEnum;
  PriorityEnum = PriorityEnum;
  StatusEnum = StatusEnum;

  @Input()
  task: TaskType = this.createEmptyTask();

  @Output()
  onAction: EventEmitter<MessageType> = new EventEmitter<MessageType>();

  completeTask(task: TaskType) {
    this.onAction.emit({ task: { ...task }, type: 'complete' });
  }

  updateTask(task: TaskType) {
    this.onAction.emit({ task: { ...task }, type: 'update' });
  }

  deleteTask(task: TaskType) {
    this.onAction.emit({ task: { ...task }, type: 'delete' });
  }

  createEmptyTask(): TaskType {
    return {
      id: 'NA',
      title: 'Untitled',
      description: 'Has no description',
      priority: '',
      startDate: new Date(),
      dueDate: new Date(),
      category: '',
      tags: '',
      status: ''
    };
  }
}
