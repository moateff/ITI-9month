import { ChangeDetectorRef, Component } from "@angular/core";
import { FormsModule } from "@angular/forms";

@Component({
  selector: 'app-slider',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './slider.component.html',
  styleUrl: './slider.component.css'
})
export class SliderComponent {

  constructor(private cdr: ChangeDetectorRef) { }

  imageUrls : string[] = [
    'images/1.png',
    'images/2.png',
    'images/3.png'
  ]

  currentIndex = 0;
  currentImage = this.imageUrls[this.currentIndex];

  changeImage() {
    this.currentIndex = (this.currentIndex + 1) % this.imageUrls.length;
    this.currentImage = this.imageUrls[this.currentIndex];
  }

  intervalId: number | null = null;

  startSlideshow() {
    if (this.intervalId) return;

    this.intervalId = setInterval(() => {
      this.changeImage();
      this.cdr.detectChanges();
    }, 3000);
  }

  endSlideshow() {
    if (this.intervalId) {
      clearInterval(this.intervalId);
      this.intervalId = null;
    }
  }

  ngOnInit() {
    this.startSlideshow();
  }

  ngOnDestroy() {
    this.endSlideshow();
  }
}
