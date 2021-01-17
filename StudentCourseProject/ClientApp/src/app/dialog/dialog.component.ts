import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Student } from '../IStudent';

export interface DialogDate{
  title:string,
  name:string,
  grade:string,
  courseId: number,
  studentId: number
}

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent {

  constructor(private dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogDate) { }

    studentName:string = this.data.name;
    studentGrade:string = this.data.grade;
    studentCourseId:number = this.data.courseId;

    closeDialog(){
      this.dialogRef.close();
    }

    editOrAddStudent(){
      if(this.studentName!= null && this.studentGrade != null && this.studentCourseId>0)
      {
        let student:Student = {
          courseId:this.studentCourseId,
          name:this.studentName,
          grade: this.studentGrade,
          studentId: this.data.studentId
        };

        this.dialogRef.close(student);
      }
    }

}
