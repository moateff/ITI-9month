import { Component, inject } from '@angular/core';
import { TaskType } from '../../types/task.type';
import { PriorityEnum } from '../../enums/priority.enum';
import { CategoryEnum } from '../../enums/category.enum';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { v4 as uuidv4 } from 'uuid';
import { StatusEnum } from '../../enums/status.enum';
import { HeaderComponent } from "../header.component/header.component";
import { TaskService } from '../../services/task.service/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FooterComponent } from "../footer.component/footer.component";
import { TaskTagsValidator } from '../../validators/taskTags.validator';

@Component({
  selector: 'app-task-form',
  imports: [ReactiveFormsModule, HeaderComponent, FooterComponent],
  standalone: true,
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent {

  isUpdate = false;
  id: string = uuidv4();

  StatusEnum = StatusEnum;
  PriorityEnum = PriorityEnum;
  CategoryEnum = CategoryEnum;

  taskForm = new FormGroup({
    title: new FormControl('', [Validators.required, Validators.minLength(3)]),
    description: new FormControl('', [Validators.required]),
    startDate: new FormControl('', [Validators.required]),
    dueDate: new FormControl('', [Validators.required]),
    priority: new FormControl('', [Validators.required]),
    category: new FormControl('', [Validators.required]),
    tags: new FormControl('', [Validators.required, TaskTagsValidator]),
  });

  taskService: TaskService = inject(TaskService);

  router: Router = inject(Router);

  route: ActivatedRoute = inject(ActivatedRoute);

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params['id']) {

        this.id = params['id'];

        this.isUpdate = true;

        this.taskService.getTask(this.id).subscribe({
          next: (task) => {
            this.taskForm.patchValue(task as any);
          },
          error: (error) => {
            console.error(error);
          }
        });
      }
    });
  }

  addTask() {
    if (this.taskForm.invalid) {
      this.taskForm.markAllAsTouched();
      return;
    }

    const task = this.MapTask(this.taskForm.value);


    this.taskService.addTask(task).subscribe({
      next: () => {
        console.log('Task added successfully');

        this.router.navigate(['/tasks']);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  updateTask() {
    if (this.taskForm.invalid) {
      this.taskForm.markAllAsTouched();
      return;
    }

    const task = this.MapTask(this.taskForm.value);


    this.taskService.updateTask(task).subscribe({
      next: () => {
        console.log('Task updated successfully');

        this.router.navigate(['/tasks']);
      },
      error: (error) => {
        console.error(error);
      }
    });
  }

  MapTask(taskForm: any) : TaskType {
    return {
      id: this.id,
      title: taskForm.title,
      description: taskForm.description,
      priority: taskForm.priority,
      startDate: taskForm.startDate,
      dueDate: taskForm.dueDate,
      category: taskForm.category,
      tags: taskForm.tags,
      status: StatusEnum.IN_PROGRESS
    };
  }
}
