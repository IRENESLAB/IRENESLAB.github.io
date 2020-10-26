import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.css']
})
export class AddEditUserComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() user:any;
  Id:number;
  FirstName:string;
  LastName:string;
  EmailAddress:number;
  ResultMessage:string;
  
    ngOnInit(): void {
  this.Id = this.user.Id;
  this.FirstName = this.user.FirstName;
  this.LastName = this.user.LastName;
  this.EmailAddress = this.user.EmailAddress;
    }
  
    addUser(){
      var user = {
        FirstName: this.FirstName,
        LastName: this.LastName,
        EmailAddress: this.EmailAddress
      }
  
      this.service.addUser(user).subscribe(u=>{
 
  this.ResultMessage=u.toString();
      });
        }
  
    updateBook(){
  var user = {
    Id: this.Id,
    FirstName: this.FirstName,
    LastName: this.LastName,
    EmailAddress: this.EmailAddress
  }
  
  this.service.updateBook(user).subscribe(u=>{
    this.ResultMessage=u.toString();
    });
  }
}
