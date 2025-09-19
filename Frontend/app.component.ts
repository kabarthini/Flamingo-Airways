import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,      
  imports: [RouterOutlet], 
  template: `
    <nav style="padding:10px; background:#f5f5f5;">
      <a routerLink="/payment"></a>
    </nav>
    <router-outlet></router-outlet>
  `
})
export class AppComponent { }
