import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-add-edit-book',
  templateUrl: './add-edit-book.component.html',
  styleUrls: ['./add-edit-book.component.css']
})
export class AddEditBookComponent implements OnInit {

  constructor(private service:SharedService, private toastr:ToastrService) { }

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
    debugger
    this.service.addBook(book).subscribe(b=>{
 
      this.toastr.info(b.toString(), 'Book Created!');
    });
      }

  updateBook(){
var book = {
  Id: this.Id,
  Name: this.Name,
  Text: this.Text,
  PurchasePrice: this.PurchasePrice
}
debugger
this.service.updateBook(book).subscribe(b=>{
 this.toastr.info(b.toString(), 'Book Updated!');
  });
}

}
