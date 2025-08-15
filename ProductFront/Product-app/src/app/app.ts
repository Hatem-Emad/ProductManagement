import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  template: `
    <div class="app-container">
      <h1>Product Management App</h1>
      <router-outlet />
    </div>
  `,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Product-app');
}
