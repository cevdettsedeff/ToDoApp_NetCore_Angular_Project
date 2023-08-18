import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { TodoAdd } from 'src/app/models/todo-add';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todo-add',
  templateUrl: './todo-add.component.html',
  styleUrls: ['./todo-add.component.scss']
})
export class TodoAddComponent implements OnInit {

  constructor(private todoService:TodoService, private router:Router){}

  todoForm= new FormGroup({
    content:new FormControl('')
  })
  ngOnInit(): void {
    
  }

  add(){
    this.todoService.add(this.todoForm.value as TodoAdd).subscribe(x=>{
      if(x==true){
        this.router.navigateByUrl('/todos');
      }
      else{
        alert("İçerik eklenemedi!");
      }
    })
  }

}
