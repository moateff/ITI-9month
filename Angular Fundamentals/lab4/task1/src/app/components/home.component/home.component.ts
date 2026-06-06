import { Component } from "@angular/core";
import { HeaderComponent } from "../header.component/header.component";
import { SliderComponent } from "../slider.component/slider.component";
import { FooterComponent } from "../footer.component/footer.component";
import { MainComponent } from "../main.component/main.component";

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
  imports: [HeaderComponent, SliderComponent, MainComponent, FooterComponent]
})
export class HomeComponent {}
