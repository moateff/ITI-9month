import { Component } from '@angular/core';
import { TaskType } from '../../types/task-type';
import { PriorityEnum } from '../../enums/priority-enum';
import { CategoryEnum } from '../../enums/category-enum';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-form',
  imports: [FormsModule],
  standalone: true,
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent {

  PriorityEnum = PriorityEnum;
  CategoryEnum = CategoryEnum;

  tags: string = '';

  task: TaskType = {
    title: '',
    description: '',
    priority: PriorityEnum.LOW,
    dueDate: new Date(),
    category: CategoryEnum.WORK,
    tags: [],

    clone() { return {...this}; }
  }

  tasks: TaskType[] = [];

  addTask() {
    this.task.tags = this.tags.split(' ');
    this.tasks.push(this.task.clone());
    console.log(this.tasks);
  }
}
