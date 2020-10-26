import { Component, OnInit } from '@angular/core';
import { RegisterService } from '../shared/register.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private service:RegisterService, private toastr:ToastrService) { }
  register:any;
  ModalTitle="Login";
  ActivateRegisterComp:boolean=true;
  ngOnInit(): void {
  }

  closeLoginModal()
  {
    this.ActivateRegisterComp=false;
  }
  
}
