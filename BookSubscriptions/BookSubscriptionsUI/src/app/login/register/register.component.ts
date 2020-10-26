import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RegisterService } from 'src/app/shared/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(public service:RegisterService, private toastr: ToastrService, private router:Router) { }
  ngOnInit(): void {
    var token = localStorage.getItem('token');

    if(localStorage.getItem('token') != null)
    {
      this.router.navigate(['/home']);
    }
  }

  onLogin(form:NgForm)
  {
    if(this.service.loginFormModel.valid)
    {
    this.service.login(form.value).subscribe((data:any)=>{ 
      if(data.succeeded)
      {
        localStorage.setItem('token',data.token);
        this.router.navigateByUrl('/home');
        this.toastr.success('You have successfully logged in.','Login successful!')
      }
      else if(data.errors)
      {
        data.errors.forEach((element:any) => {        
            this.toastr.error( element.code,'Login failed!'  )           
        });
      }
      else
      {
        this.toastr.error( data.message,'Login failed!'  )          
      }
    },
    err=>{
console.log(err);
    }
      );
  }
  else{

    this.toastr.warning('Mandatory Fields are marked with *.','Login failed!')
  }
  }

  onRegister()
  {
    if(this.service.formModel.valid)
    {
    
    this.service.register().subscribe((data:any)=>{ 

      if(data.succeeded)
      {
        this.service.formModel.reset();
        this.toastr.success('Congradulations. You have successfully registered.','Registration successful!')
      }
      else
      {
        data.errors.forEach((element:any) => {
          switch(element.code)
          {
          case 'DuplicateUserName':
            this.toastr.error( 'Username alreay exists.','Registration failed!')
            break;
            default:
              break;
          }
        });
      }
    },
    err=>{
      console.log(err);
    }
      );
  }
  else{
    this.toastr.warning('Mandatory Fields are marked with *.','Registration failed!')
  }
  }

  onLogin_()
  {
    if(this.service.loginFormModel.valid)
    {
     
    this.service.login_().subscribe((data:any)=>{ 
      
      if(data.succeeded)
      {
        this.toastr.success('Congradulations. You have successfully logged in.','Login successful!')
      }
      else if(data.errors)
      {
        data.errors.forEach((element:any) => {
        
            this.toastr.error(element.code ,'Login failed!' )
           
        });
      }
      else{
        this.toastr.success(data.succeeded,'Login successful!')
      }
    },
    err=>{
      this.toastr.error(err.error.message,'Login failed!')
    }
      );
  }
  else{

    this.toastr.warning( 'Mandatory Fields are marked with *.','Login failed!')
  }
  }
}
