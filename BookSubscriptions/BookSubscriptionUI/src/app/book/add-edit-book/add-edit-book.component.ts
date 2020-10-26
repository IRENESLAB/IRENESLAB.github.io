import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'app-add-edit-book',
  templateUrl: './add-edit-book.component.html',
  styleUrls: ['./add-edit-book.component.css']
})
export class AddEditBookComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() book:any;
Id:number;
Name:string;
Text:string;
PurchasePrice:number;
ResultMessage:string;

  ngOnInit(): void {
this.Id = this.book.Id;
this.Name = this.book.Name;
this.Text = this.book.Text;
this.PurchasePrice = this.book.PurchasePrice;
  }

  addBook(){
    var book = {
      Name: this.Name,
      Text: this.Text,
      PurchasePrice: this.PurchasePrice
    }

    this.service.addBook(book).subscribe(b=>{
 
this.ResultMessage =b.toString();
    });
      }

  updateBook(){
var book = {
  Id: this.Id,
  Name: this.Name,
  Text: this.Text,
  PurchasePrice: this.PurchasePrice
}

this.service.updateBook(book).subscribe(b=>{
  this.ResultMessage =b.toString();
  });
}

}
