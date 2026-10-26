import { Routes } from '@angular/router';
import { About } from './pages/about/about';
import { ContactUs } from './pages/contact-us/contact-us';
import { DataBindings } from './components/data-bindings/data-bindings';
import { Home } from './components/home/home';
import { Courses } from './components/courses/courses';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'home', component: Home },
  { 
    path: 'data-bindings', 
    loadComponent: () => import('./components/data-bindings/data-bindings').then(m => m.DataBindings)
  },
  {
    path: 'about', 
    loadComponent: () => import('./pages/about/about').then(m => m.About) 
  },
  {
  path: 'contact-us',
  loadComponent: () => import('./pages/contact-us/contact-us').then(m => m.ContactUs)

  },
  {
    path: 'courses',
    component: Courses,
  },
  { path: '**', redirectTo: 'home' },
  
];

