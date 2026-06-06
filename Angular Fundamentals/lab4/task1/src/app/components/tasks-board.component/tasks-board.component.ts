import { ChangeDetectorRef, Component, EventEmitter, Input, Output, SimpleChange, SimpleChanges } from '@angular/core';
import { TabsComponent } from "../tabs.component/tabs.component";
import { TaskType } from '../../types/task-type';
import { TaskListComponent } from '../task.list.component/task-list.component';
import { MessageType } from '../../types/message-type';
import { StatusEnum } from '../../enums/status-enum';
import { HeaderComponent } from "../header.component/header.component";


@Component({
  selector: 'app-tasks-board',
  standalone: true,
  imports: [TabsComponent, TaskListComponent, HeaderComponent],
  templateUrl: './tasks-board.component.html',
  styleUrl: './tasks-board.component.css'
})
export class TasksBoardComponent {

  constructor(private cdr: ChangeDetectorRef) { }

  currentTab = 'all';

  tasks: TaskType[] = [];

  @Input()
  action: MessageType = {
    task: this.createEmptyTask(),
    type: 'add'
  }

  @Output()
  onAction: EventEmitter<MessageType> = new EventEmitter<MessageType>();

  allTasks : TaskType[] = [];
  completedTasks : TaskType[] = [];
  inProgressTasks : TaskType[] = [];

  changeTab(tab: string) {
    this.currentTab = tab;
    console.log(this.currentTab);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['action'].firstChange) {
      return;
    }

    console.log('from app', this.action);

    this.actionTask(this.action);

    this.filterTasks();
  }

  filterTasks() {
    this.allTasks = this.tasks;
    this.inProgressTasks = this.tasks.filter(t => t.status === StatusEnum.IN_PROGRESS);
    this.completedTasks = this.tasks.filter(t => t.status === StatusEnum.COMPLETED);
  }

  actionTask(action: MessageType) {
    if (!action.task) {
      return;
    }

    switch (action.type) {
      case 'add':
        console.log('Add task:', action.task?.id);
        this.tasks.unshift({ ...action.task });
        this.tasks = [...this.tasks];
        break;
      case 'complete':
        console.log('Complete task:', action.task?.id);
        this.tasks = this.tasks.map(t => t.id === action.task?.id ? { ...action.task, status: StatusEnum.COMPLETED }: t);
        break;
      case 'update':
        console.log('Update task:', action.task?.id);
        this.onAction.emit(action);
        break;
      case 'delete':
        console.log('Delete task:', action.task?.id);
        this.tasks = this.tasks.filter(t => t.id !== action.task?.id);
        break;
      case 'save':
        console.log('Save task:', action.task?.id);
        this.tasks = this.tasks.map(t => t.id === action.task?.id ? { ...action.task }: t);
        break;
    }

    this.filterTasks();

    console.log(this.tasks);
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
