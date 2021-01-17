import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DataService } from './data.service';
import { DialogComponent } from './dialog/dialog.component';
import { Student } from './IStudent';
import { Course } from './ICourse';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{
  
  constructor(private dataService:DataService,
              private dialog:MatDialog){}

  courses: Course[] = [];
  selectedCourse: string;
  students: Student[] = [];
  

openForm() {
  const openedDialog = this.dialog.open(DialogComponent,{
    data: {
      title: "Add",
      name: '',
      grade: '',
      courseId: 0,
      studentId: 0
    }
  });
  openedDialog.afterClosed().subscribe(
    result => {
      if(result)
          this.addStudent(result);
    }
  )
}

openEditForm(student:Student) {
  const openedDialog = this.dialog.open(DialogComponent,{
    data: {
      title:"Edit",
      name:student.name,
      grade:student.grade,
      courseId: student.courseId,
      studentId: student.studentId
    }
    });
  
  openedDialog.afterClosed().subscribe(
    result => {
      if (result)
          this.editStudent(result,student);
    }
  );
}


deleteStudent(student:Student){

  if(confirm("Are you sure to delete this row?"))
  {
this.dataService.deleteStudent(student.studentId).subscribe(
  res => {
    let index:number = this.students.indexOf(student,0);
    this.students.splice(index,1);
  });
  }
}

editStudent(newStudent:Student,prevStudent:Student)
{
  this.dataService.putStudent(newStudent).subscribe(
    res => {
      if (prevStudent.courseId === newStudent.courseId) {
        prevStudent.name = newStudent.name;
        prevStudent.grade = newStudent.grade;
        prevStudent.courseId = newStudent.courseId;
      }
      else {
        let index = this.students.indexOf(prevStudent, 0);
        this.students.splice(index, 1);
      }
    }
  );
}

addStudent(student:Student)
{

  this.dataService.postStudent(student).subscribe({
    next: (res: any) => {
      student.studentId = res;
      let course = this.courses.find(o => {
        return o.courseName === this.selectedCourse;
      });
      console.log(course);
      if (student.courseId === course.courseId)
        this.students.push(student);
    }
  }
  );

}

  changeCourse() {
    this.dataService.getStudents(this.selectedCourse).subscribe(
      {
        next: res => this.students = res
      }
    );
  }


  ngOnInit(): void {
    this.dataService.getAllCourses().subscribe(
      {
        next: res => {
          this.courses = res;
        },
        complete: () => {
          this.selectedCourse = this.courses[0].courseName;
          this.dataService.getStudents(this.selectedCourse).subscribe({
            next: res => this.students = res
          });
        }
      }
    );
}
}
