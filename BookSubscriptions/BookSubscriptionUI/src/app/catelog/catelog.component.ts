import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'app-catelog',
  templateUrl: './catelog.component.html',
  styleUrls: ['./catelog.component.css']
})
export class CatelogComponent implements OnInit {

  constructor(private service:SharedService) { }

  UserId:number;
  BookId:number;
  IsActive:boolean;
  ResultMessage:string;

BookList:any=[];
  ngOnInit(): void {
    this.refreshBookList(); 
  }

  refreshBookList(){
    this.service.getBooks().subscribe(data=>
      {
        debugger
this.BookList = data;
      });
  }

  subscribeBook(id: any)
    {
      var bookSub = {
        UserId: 7,
        BookId: id,
        IsActive: true
      }

this.service.addUserSubscription(bookSub).subscribe(data=>{
  this.ResultMessage=data.toString();
});
    }

  
}
