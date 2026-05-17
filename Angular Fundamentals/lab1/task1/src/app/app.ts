import { Component, signal } from '@angular/core';
import { HeaderComponent } from './components/header.component/header.component';
import { SliderComponent } from './components/slider.component/slider.component';
import { TaskComponent } from './components/task.component/task.component';

@Component({
  selector: 'app-root',
  imports: [HeaderComponent, SliderComponent, TaskComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('task1');
}
