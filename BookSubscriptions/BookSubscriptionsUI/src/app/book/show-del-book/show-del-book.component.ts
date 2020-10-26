import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-show-del-book',
  templateUrl: './show-del-book.component.html',
  styleUrls: ['./show-del-book.component.css']
})
export class ShowDelBookComponent implements OnInit {

  constructor(private service:SharedService) { }

  BookList:any=[];
  ModalTitle:string;
  ResultMessage:string;
  ActivateAddEditBookComp:boolean=false;
  book:any;

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

  addBook()
  {
    this.book={
Id:0,
Name:"",
Text:"",
PurchasePrice:0
  }

  debugger
this.ModalTitle="Add Book";
this.ActivateAddEditBookComp=true;
  }
  editBook(dataItem){
    debugger
    this.book = dataItem;
    this.ModalTitle="Edit Book";
    this.ActivateAddEditBookComp=true;
  }
  deleteBook(dataItem){
    debugger
    if(confirm('Are you sure??'))
    {
 this.service.deleteBook(dataItem.Id).subscribe(data=>{
  this.ResultMessage =data.toString();
this.refreshBookList();
    });
    }
    
   
  }

  closeBookModal()
  {
this.ActivateAddEditBookComp=false;
this.refreshBookList();
  }


}
