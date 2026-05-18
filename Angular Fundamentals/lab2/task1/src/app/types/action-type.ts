import { TaskType } from "./task-type";

export type ActionType = {
  task: TaskType | null;
  type: 'add' | 'complete' | 'update' | 'delete' | 'save';
}
