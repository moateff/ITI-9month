import { ChangeDetectorRef, Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { TaskType } from '../../types/task.type';
import { CommonModule } from '@angular/common';
import { CategoryEnum } from '../../enums/category.enum';
import { PriorityEnum } from '../../enums/priority.enum';
import { StatusEnum } from '../../enums/status.enum';
import { TaskService } from '../../services/task.service/task.service';
import { Router } from '@angular/router';

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
  task: TaskType = null!;

  taskService: TaskService = inject(TaskService);

  cdr: ChangeDetectorRef = inject(ChangeDetectorRef);

  router: Router = inject(Router);

  completeTask(task: TaskType) {
    task.status = StatusEnum.COMPLETED;
    this.taskService.updateTask(task).subscribe({
      next: () => {
        console.log('Task completed successfully');

        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  updateTask(task: TaskType) {
    this.router.navigate(['/update', task.id]);
  }

  deleteTask(task: TaskType) {
    this.taskService.deleteTask(task).subscribe({
      next: () => {
        console.log('Task deleted successfully');

        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

}
