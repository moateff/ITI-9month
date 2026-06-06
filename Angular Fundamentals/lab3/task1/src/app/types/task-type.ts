import { CategoryEnum } from "../enums/category-enum";
import { PriorityEnum } from "../enums/priority-enum";
import { StatusEnum } from "../enums/status-enum";

export type TaskType = {
  id: string;
  title: string;
  description: string;
  priority: PriorityEnum | string;
  startDate: Date;
  dueDate: Date;
  category: CategoryEnum | string;
  tags: string;
  status: StatusEnum | string;
};
