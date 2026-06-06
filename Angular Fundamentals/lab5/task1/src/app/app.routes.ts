import { Routes } from '@angular/router';
import { HomeComponent } from './components/home.component/home.component';
import { NotFoundComponent } from './components/notfound.component/notfound.component';
import { LoginComponent } from './components/login.component/login.component';
import { SignupComponent } from './components/signup.component/signup.component';
import { TasksBoardComponent } from './components/tasks-board.component/tasks-board.component';
import { TaskFormComponent } from './components/task-form.component/task-form.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full'
  },
  {
    path: 'home',
    component: HomeComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'signup',
    component: SignupComponent
  },
  {
    path: 'tasks',
    component: TasksBoardComponent,
    canActivate: [authGuard]
  },
  {
    path: 'add',
    component: TaskFormComponent,
    canActivate: [authGuard]
  },
  {
    path: 'update/:id',
    component: TaskFormComponent,
    canActivate: [authGuard]
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];
