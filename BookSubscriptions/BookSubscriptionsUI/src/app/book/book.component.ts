import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RegisterService } from '../shared/register.service';
import { SharedService } from '../shared/shared.service';

@Component({
  selector: 'app-book',
  templateUrl: './book.component.html',
  styleUrls: ['./book.component.css']
})
export class BookComponent implements OnInit {

  constructor(private registerService:RegisterService, private router:Router) { }
  userDetails;

  ngOnInit(): void {
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

}
