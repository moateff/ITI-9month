import { ChangeDetectorRef, Component, EventEmitter, inject, Input, Output, SimpleChange, SimpleChanges } from '@angular/core';
import { TabsComponent } from "../tabs.component/tabs.component";
import { TaskType } from '../../types/task.type';
import { TaskListComponent } from '../task.list.component/task-list.component';
import { StatusEnum } from '../../enums/status.enum';
import { HeaderComponent } from "../header.component/header.component";
import { TaskService } from '../../services/task.service/task.service';
import { FooterComponent } from "../footer.component/footer.component";


@Component({
  selector: 'app-tasks-board',
  standalone: true,
  imports: [TabsComponent, TaskListComponent, HeaderComponent, FooterComponent],
  templateUrl: './tasks-board.component.html',
  styleUrl: './tasks-board.component.css'
})
export class TasksBoardComponent {

  currentTab = 'all';

  taskService: TaskService = inject(TaskService);

  cdr: ChangeDetectorRef = inject(ChangeDetectorRef);

  getTasks() {
    this.taskService.getTasks().subscribe({
      next: (tasks) => {
        console.log('Tasks loaded successfully');

        this.allTasks = tasks;
        this.filterTasks();

        this.cdr.detectChanges();
      },
      error: (error) => {
        console.error(error);
      }
    })
  }

  allTasks : TaskType[] = [];
  completedTasks : TaskType[] = [];
  inProgressTasks : TaskType[] = [];

  filterTasks() {
    this.inProgressTasks = this.allTasks.filter(t => t.status === StatusEnum.IN_PROGRESS);
    this.completedTasks = this.allTasks.filter(t => t.status === StatusEnum.COMPLETED);
  }

  ngDoCheck() {
    this.getTasks();
  }

  changeTab(tab: string) {
    this.currentTab = tab;
  }
}

