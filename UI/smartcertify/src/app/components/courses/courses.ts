import { Component, OnInit, Input } from '@angular/core';
import { CoursesService } from '../../services/courses.service';
import { Course } from '../../models/course';
import { CommonModule } from '@angular/common';
import { TechFilter } from '../tech-filter/tech-filter';
import { EventEmitter, Output } from '@angular/core';
@Component({
  selector: 'app-courses',
  imports: [CommonModule, TechFilter, EventEmitter],
  templateUrl: './courses.html',
  styleUrl: './courses.css',
})
export class Courses implements OnInit {
  @Input() courses: Course[] = []; // Initialize courses as an empty array 
  @Output() courseSelected: EventEmitter<Courses> = new EventEmitter<Courses>();
constructor(private coursesService: CoursesService) { }

ngOnInit(): void {
  this.loadCourses();
}

loadCourses() {
  this.coursesService.getCourses().subscribe(courses=>{
    this.courses = courses;
  }

  
  );
}
// funkcja do wybierania kurse i emitowania zdarzenia z wybranym kursem
onTechSelected(tech: string) : void {
console.log(`${tech} selected`);
}
}


