import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Input } from '@angular/core';
import { EventEmitter, Output } from '@angular/core';
@Component({
  selector: 'app-tech-filter',
  imports: [CommonModule, EventEmitter],
  templateUrl: './tech-filter.html',
  styleUrl: './tech-filter.css',
})
export class TechFilter {
@Input() techList: {name: string; image: string}[] = []; // Initialize techList as an empty array
@Output() filterCourses = new EventEmitter<string>();

selectTechnology(tech: string) {
  this.filterCourses.emit(tech);
}
}
