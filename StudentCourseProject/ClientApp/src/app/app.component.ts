import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Student } from './IStudent';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  
  constructor(private dataService:DataService){}

  students: Student[] = [];

newStudent:Student = {
  studentId:0,
  courseId:0,
  grade:"",
  name:""
};

openForm() {
  document.getElementById("myForm").style.display = "block";
  document.getElementById("openform").style.display = "none";
  
}

closeForm() {
  document.getElementById("myForm").style.display = "none";
  document.getElementById("openform").style.display = "block";
}

openDeleteForm() {
  document.getElementById("dForm").style.display = "block"; 
}

closeDeleteForm() {
  document.getElementById("dForm").style.display = "none";
}

openEditForm() {
  document.getElementById("eForm").style.display = "block";
  
}

closeEditForm() {
  document.getElementById("eForm").style.display = "none";
}

deleteStudent(studentId:number){
  
this.dataService.deleteNote(studentId).subscribe(
  res => {

  }
);

}
}
