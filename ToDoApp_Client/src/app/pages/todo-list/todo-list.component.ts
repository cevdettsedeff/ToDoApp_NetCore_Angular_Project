import { Component, OnInit } from '@angular/core';
import { Todo } from 'src/app/models/todo';
import { TodoService } from 'src/app/services/todo.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.scss']
})
export class TodoListComponent implements OnInit {

  constructor(private todoService:TodoService){}

  todoList:Todo[]=[];

  ngOnInit(): void {
    this.load();
  }

  load(){
    this.todoService.getAll().subscribe(x=>this.todoList=x)
  }

  delete(id:number){
    this.todoService.delete(id).subscribe(x=>{
      if(x==true){
        this.load();
      }
      else{
        alert("To do silinemedi!");
      }
    })

  }

  isCompleted(id:number){
    this.todoService.isCompleted(id).subscribe(x=>{
      if(x==true){
        let index = this.todoList.findIndex(x=>x.id==id);
        this.todoList[index].isCompleted=!this.todoList[index].isCompleted
      }
    })
  }

  

}
