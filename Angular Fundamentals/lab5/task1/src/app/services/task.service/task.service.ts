import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { baseUrl } from '../../shared/baseUrl';
import { TaskType } from '../../types/task.type';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  http: HttpClient = inject(HttpClient);

  getTasks() {
    return this.http.get<TaskType[]>(baseUrl + '/tasks');
  }

  getTask(id: string) {
    return this.http.get<TaskType>(baseUrl + '/tasks/' + id);
  }

  addTask(task: TaskType) {
    return this.http.post<TaskType>(baseUrl + '/tasks', task);
  }

  updateTask(task: TaskType) {
    return this.http.put<TaskType>(baseUrl + '/tasks/' + task.id, task);
  }

  deleteTask(task: TaskType) {
    return this.http.delete<TaskType>(baseUrl + '/tasks/' + task.id);
  }
}
