import { Component } from "@angular/core";
import { FormsModule } from "@angular/forms";

@Component({
  selector: 'app-slider',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './slider.component.html',
  styleUrl: './slider.component.css'
})
export class SliderComponent {
  private imageUrls : string[] = [
    'images/1.png',
    'images/2.png',
    'images/3.png',
    'images/4.png',
    'images/5.png'
  ]

  private intervalId: number | null = null;

  index : number = Math.floor(Math.random() * this.imageUrls.length);

  imageUrl : string = this.imageUrls[this.index];

  stop() {
    if (this.intervalId !== null) {
      clearInterval(this.intervalId);
      this.intervalId = null;
    }
  }

  start() {
    if (this.intervalId === null) {
      this.intervalId = window.setInterval(() => {
        this.index = (this.index + 1) % this.imageUrls.length;
        this.imageUrl = this.imageUrls[this.index];
      }, 2000);
    }
  }

  func(e: Event) {
    this.stop();
    this.index = Number((e.target as HTMLInputElement).value);
    this.imageUrl = this.imageUrls[this.index];
  }
}
