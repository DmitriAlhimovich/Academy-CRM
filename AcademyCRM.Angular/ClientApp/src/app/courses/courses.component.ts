import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'courses',
  templateUrl: './courses.component.html'
})
export class CoursesComponent implements OnInit {
  topicId: number;
  public courses: Course[];


  constructor(private http: HttpClient, private activateRoute: ActivatedRoute, @Inject('BASE_URL') private baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.topicId = Number.parseInt(this.activateRoute.snapshot.params['topicId']);
    this.http.get<Course[]>(this.baseUrl + 'courses').subscribe(result => {
      this.courses = this.topicId ? result.filter(c => c.topicId === this.topicId) : result;
    }, error => console.error(error));
  }
}

interface Course {
  title: string;
  topicId: number;
  topicName: string;
}
