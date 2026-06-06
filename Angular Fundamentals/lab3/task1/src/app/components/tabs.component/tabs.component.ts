import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-tabs',
  standalone: true,
  templateUrl: './tabs.component.html',
  styleUrl: './tabs.component.css',
  imports: []
})
export class TabsComponent {
  currentTab = 'all';

  @Output()
  onChange: EventEmitter<string> = new EventEmitter<string>();

  changeTab(tab: string) {
    this.currentTab = tab;
    this.onChange.emit(tab);
  }
}
