import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from './IStudent';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  
  private baseUrl = 'api/Students/';
  constructor(private http: HttpClient) { }

  getNotes(courseId:number): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseUrl+courseId.toString());
  }

  postNote(student: Student) {
    return this.http.post<Student>(this.baseUrl, student);
  }

  putNote(student:Student) {
    return this.http.put(this.baseUrl + student.studentId.toString(), student);
  }

  deleteNote(studentId: number) {
    return this.http.delete(this.baseUrl + studentId.toString());
  }
}
