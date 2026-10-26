import { Component, NgZone, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Header } from './pages/header/header';
import { Footer } from './pages/footer/footer'; 
import { Home } from './components/home/home';
import { ɵNoopNgZone } from '@angular/core';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Header, Footer ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('smartcertify');
  
  }

