import { Component, DebugElement, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr'; 
import { RegisterService } from '../shared/register.service';
import { SharedService } from '../shared/shared.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private router:Router, private registerService:RegisterService, private bookService:SharedService, private toastr:ToastrService ) { }
userDetails;

  ngOnInit() { 
    this.registerService.getUserProfile().subscribe(
      data=>{
this.userDetails = data;
    },
    err =>{ 
      localStorage.removeItem('token');
      this.router.navigate(['/login/register']);
 console.log(err);
    }
      )
  }

  logout()
  {
    localStorage.removeItem('token');
    this.router.navigate(['/login/register']);
  }

  

}
