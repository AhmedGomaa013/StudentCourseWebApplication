import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from './IStudent';
import { Course } from './ICourse';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  
  private baseUrl = 'api/Students/';
  constructor(private http: HttpClient) { }

  getStudents(courseName:string): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseUrl+courseName);
  }

  postStudent(student: Student) {
    return this.http.post<Student>(this.baseUrl, student);
  }

  putStudent(student:Student) {
    return this.http.put(this.baseUrl + student.studentId.toString(), student);
  }

  deleteStudent(studentId: number) {
    return this.http.delete(this.baseUrl + studentId.toString());
  }

  getAllCourses() {
    return this.http.get<Course[]>('api/Courses/');
  }
}
