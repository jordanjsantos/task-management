import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from '../models/task';

@Injectable({
  providedIn: 'root'
})

export class TaskService {

  // URL DA API
  private api = 'http://localhost:5249/api/tasks';

  constructor(private http: HttpClient)
  {

  }

  // GET
  list(): Observable<Task[]>
  {
    return this.http.get<Task[]>(this.api);
  }

  // POST
  add(task: Task)
  {
    return this.http.post(this.api, task);
  }

  // PUT
  update(id: number, task: Task)
  {
    return this.http.put(`${this.api}/${id}`, task);
  }

  // DELETE
  remove(id: number)
  {
    return this.http.delete(`${this.api}/${id}`);
  }
}
