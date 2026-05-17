import { CategoryEnum } from "../enums/category-enum";
import { PriorityEnum } from "../enums/priority-enum";

export type TaskType = {
  title: string;
  description: string;
  priority: PriorityEnum;
  dueDate: Date;
  category: CategoryEnum;
  tags: string[];

  clone: () => TaskType;
};
