import { Component, OnInit } from '@angular/core'; 
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { stringify } from 'querystring';
import { RegisterService } from '../shared/register.service';
import { SharedService } from '../shared/shared.service';

@Component({
  selector: 'app-catelog',
  templateUrl: './catelog.component.html',
  styleUrls: ['./catelog.component.css']
})
export class CatelogComponent implements OnInit {

  constructor(private registerService:RegisterService, private catelogService:SharedService, private toastr:ToastrService, private router:Router) { }

  UserId:number;
  BookId:number;
  IsActive:boolean;
  userDetails;

BookList:any=[];
userBook;
  
  ngOnInit() { 
   
    this.registerService.getUserProfile().subscribe(
      data=>{
this.userDetails = data; 
this.refreshBookList(); 
    },
    err =>{ 
      localStorage.removeItem('token');
      this.router.navigate(['/login/register']);
 console.log(err);
    }
      )
  }

  refreshBookList(){
    var userBook={UserId : this.userDetails!=null ? this.userDetails.id : ""}
    this.catelogService.getUserBooks(this.userDetails.id).subscribe(data=>
      {
  debugger      
this.BookList = data;

      },
      err =>{
        console.log(err);
      }
      );
  }

  subscribeBook(dataItem,isActive:boolean)
  {
    var userBook={UserId : this.userDetails!=null ? this.userDetails.id : "", BookId : dataItem.bookId, Id: dataItem.id, IsActive: isActive}
debugger
    if(dataItem.id==0)
    {
       this.catelogService.addUserSubscription(userBook).subscribe(data=>
      {
        debugger
        this.userBook = data;
        this.toastr.info(dataItem.name ? 'Book unsubscribed!' : 'Book unsubscribed!')
        this.refreshBookList();
      }); 
     
    }
    else{
      if(dataItem.isActive)
      this.updateBookSubscription(dataItem, false);
      else
      this.updateBookSubscription(dataItem, true);
    }



  }
  private updateBookSubscription(dataItem, isActive)
  {
    var userBook={UserId : this.userDetails!=null ? this.userDetails.id : "", BookId : dataItem.bookId, Id: dataItem.id, IsActive: isActive}
    this.catelogService.updateUserSubscription(userBook).subscribe(data=>
      {
        debugger
        this.userBook = data;
this.toastr.info(dataItem.name, isActive ? 'Book unsubscribed!' : 'Book unsubscribed!')
this.refreshBookList();
      });

      
  }
  
}
