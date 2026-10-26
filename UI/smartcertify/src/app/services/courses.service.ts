import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Course } from '../models/course';
@Injectable({
  providedIn: 'root',
})
export class CoursesService {
  //prywatny adres url do backendu, który będzie obsługiwał zapytania dotyczące kursów. W tym przypadku jest to 'http://localhost:5076/api', ale w rzeczywistości powinien być to adres serwera, na którym działa backend.
  private baseUrl = 'http://localhost:5076/api';
  // moja pierwsza refaktoryzacja, która polega na użyciu funkcji inject do wstrzykiwania zależności HttpClient zamiast tradycyjnego konstruktora. Dzięki temu kod jest bardziej zwięzły i czytelny.
  private http = inject(HttpClient);
  // Konstruktor serwisu, który przyjmuje instancję HttpClient. HttpClient jest używany do wykonywania zapytań HTTP do backendu.
  // constructor sluzy do inicjalizacji serwisu i wstrzykiwania zależności, takich jak HttpClient. W tym przypadku, konstruktor jest pusty, co oznacza, że nie wykonuje żadnych dodatkowych operacji podczas tworzenia instancji serwisu. Jednakże, w kodzie znajduje się błąd logiczny - przypisanie wyniku zapytania HTTP do właściwości http2, która nie jest używana w dalszej części kodu. To zapytanie jest wykonywane podczas tworzenia instancji serwisu, co może prowadzić do niepotrzebnych zapytań do backendu. Należy usunąć tę linię, aby uniknąć niepotrzebnych zapytań i poprawić wydajność aplikacji.
  constructor() { 
    // bład logiczny - przypisanie wyniku zapytania HTTP do właściwości http2, która nie jest używana w dalszej części kodu. To zapytanie jest wykonywane podczas tworzenia instancji serwisu, co może prowadzić do niepotrzebnych zapytań do backendu. Należy usunąć tę linię, aby uniknąć niepotrzebnych zapytań i poprawić wydajność aplikacji.
   
  }
  
// Metoda getCourses, która zwraca Observable zawierający tablicę obiektów typu Course. Ta metoda wykonuje zapytanie GET do endpointu '/courses' na backendzie i oczekuje odpowiedzi w formacie JSON, która zostanie zmapowana na tablicę obiektów Course.
  getCourses():Observable<Course[]> {
// Wykonuje zapytanie GET do endpointu '/courses' na backendzie i zwraca Observable zawierający tablicę obiektów Course.
    return this.http.get<Course[]>(this.baseUrl + '/Courses');
  }

  }

