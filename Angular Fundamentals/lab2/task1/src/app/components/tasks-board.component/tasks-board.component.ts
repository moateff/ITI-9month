import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TabsComponent } from "../tabs.component/tabs.component";
import { TaskType } from '../../types/task-type';
import { TaskListComponent } from '../task.list.component/task-list.component';
import { ActionType } from '../../types/action-type';
import { StatusEnum } from '../../enums/status-enum';


@Component({
  selector: 'app-tasks-board',
  standalone: true,
  imports: [TabsComponent, TaskListComponent],
  templateUrl: './tasks-board.component.html',
  styleUrl: './tasks-board.component.css'
})
export class TasksBoardComponent {
  currentTab = 'all';

  allTasks : TaskType[] = [];
  completedTasks : TaskType[] = [];
  inProgressTasks : TaskType[] = [];

  @Input()
  set tasks(tasks: TaskType[]) {
    this.allTasks = tasks;
    this.completedTasks = tasks.filter(t => t.status === StatusEnum.COMPLETED);
    this.inProgressTasks = tasks.filter(t => t.status === StatusEnum.IN_PROGRESS);
  }

  changeTab(tab: string) {
    this.currentTab = tab;
    console.log(this.currentTab);
  }

  @Output()
  onAction: EventEmitter<ActionType> = new EventEmitter<ActionType>();

  actionTask(action: ActionType) {
    this.onAction.emit(action);
  }
}
