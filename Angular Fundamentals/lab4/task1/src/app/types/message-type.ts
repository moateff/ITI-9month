import { TaskType } from "./task-type";

export type MessageType = {
  task: TaskType | null;
  type: 'add' | 'complete' | 'update' | 'delete' | 'save';
}
