import {CommonModule} from '@angular/common';
import {Component} from '@angular/core';
import {FormsModule} from '@angular/forms';
import { DataBindingsLatest } from '../data-bindings-latest/data-bindings-latest';
@Component({
  selector: 'app-data-bindings',
  imports: [CommonModule, FormsModule, DataBindingsLatest],
  templateUrl: './data-bindings.html',
  styleUrl: './data-bindings.css'
})
export class DataBindings {
// Interpolation and Property Binding
  appName: string = 'SmartCertify';
  logoUrl = 'images/nauka1.jpg';
  appDescription: string = 'An amazing platform for certifying skills and knowledge in the digital age.';

  //Two-way Data Binding
  username = '';

  // *ngIf *ngElse
  isWelcomeVisible = true;
  
  toggleWelome() {
    this.isWelcomeVisible = !this.isWelcomeVisible;
  }
  // *ngFor
  technologies = ['Angular', 'TypeScript', '.NET Core', 'C#', 'Azure', 'React', 'Node.js', 'Docker'];
  //Event Binding
  clickCounter = 0;
  incrementCounter() {
    this.clickCounter++;
  }
  //Attribute Directives: ngClass and ngStyle
  isHighLighted = false;
  getClass() 
  {
    return this.isHighLighted ? 'test-primary' : 'text-secondary';
  }

  getStyle() {
    return this.isHighLighted ? {'font-weight': 'bold', 'fontSize': '24px'} 
    : {'font-weight': 'normal', 'fontSize': '20px'};
  }
  toggleHighlight() {
    this.isHighLighted = !this.isHighLighted;
  }
}
