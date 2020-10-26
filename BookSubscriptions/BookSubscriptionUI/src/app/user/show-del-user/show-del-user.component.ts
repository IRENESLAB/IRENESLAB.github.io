import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service'

@Component({
  selector: 'app-show-del-user',
  templateUrl: './show-del-user.component.html',
  styleUrls: ['./show-del-user.component.css']
})
export class ShowDelUserComponent implements OnInit {

  constructor(private service:SharedService) { }
  
  UserList:any=[];
  ModalTitle:string;
  ResultMessage:string;
  ActivateAddEditUserComp:boolean=false;
  user:any;

  ngOnInit(): void {
    this.refreshUserList();
      }

      refreshUserList()
  {
    this.service.getUsers().subscribe(data=>{
  this.UserList = data;
    });
  }

  addUser()
  {
    this.user={
Id:0,
FirstName:"",
LastName:"",
EmailAddress:""
  }
this.ModalTitle="Add User";
this.ActivateAddEditUserComp=true;
  }
  editUser(dataItem){
    this.user = dataItem;
    this.ModalTitle="Edit User";
    this.ActivateAddEditUserComp=true;
  }
  deleteUser(dataItem){
    if(confirm('Are you sure??'))
    {
 this.service.deleteUser(dataItem.Id).subscribe(data=>{
  this.ResultMessage=data.toString();
this.refreshUserList();
    });
    }
    
   
  }

  closeUserModal()
  {
this.ActivateAddEditUserComp=false;
this.refreshUserList();
  }







}
