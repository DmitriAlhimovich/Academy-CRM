import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent {
  public coursesAll: Course[];
  public courses: Course[];
  public topicId: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Course[]>(baseUrl + 'courses').subscribe(result => {
      this.coursesAll = result;
      this.courses = result;
    }, error => console.error(error));
  }

  public filter(topicId: number) {
    this.topicId = topicId;
    this.courses = topicId ? this.coursesAll.filter(c => c.topicId === topicId) : this.coursesAll;
  }
}

interface Course {
  title: string;
  topicId: number;
  topicName: string;
}
