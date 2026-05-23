import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import { TaskService } from '../../services/task.service';

import { Task } from '../../models/task';

@Component({
  selector: 'app-tasks',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './tasks.component.html',
  styleUrl: './tasks.component.css'
})

export class TasksComponent implements OnInit {

  tasks: Task[] = [];

  task: Task = {
    id: 0,
    title: '',
    description: '',
    status: ''
  };

  editing = false;

  constructor(private service: TaskService) {

  }

  ngOnInit(): void {

    this.loadTasks();
  }

  loadTasks() {
    this.service.list().subscribe({

      next: (data) => {
        this.tasks = data;
      },

      error: (error) => {
        console.log(error);
      }
    });
  }

  save() {
    // EDIT
    if (this.editing) {
      this.service.update(this.task.id, this.task)
        .subscribe({

          next: () => {
            alert('Task updated!');

            this.cancel();

            this.loadTasks();
          },

          error: (error) => {
            console.log(error);
          }
        });
    }

    // ADD
    else {
      this.service.add(this.task)
        .subscribe({

          next: () => {
            alert('Task added!');

            this.task = {
              id: 0,
              title: '',
              description: '',
              status: ''
            };

            this.loadTasks();
          },

          error: (error) => {
            console.log(error);
          }
        });
    }
  }

  edit(task: Task) {
    this.editing = true;

    this.task = { ...task };
  }

  remove(id: number) {
    this.service.remove(id)
      .subscribe({

        next: () => {
          alert('Task removed!');

          this.loadTasks();
        },

        error: (error) => {
          console.log(error);
        }
      });
  }

  cancel() {
    this.editing = false;

    this.task = {
      id: 0,
      title: '',
      description: '',
      status: ''
    };
  }
}
