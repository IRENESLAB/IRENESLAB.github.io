import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private formBuilder : FormBuilder, private http:HttpClient) { }

  readonly APIURI = 'http://localhost:58292/api';

  formModel = this.formBuilder.group({
    EmailAddress : ['',[Validators.email,Validators.required]],
    FirstName : [''],    
    LastName : [''],
    Passwords : this.formBuilder.group({
      Password : ['',[Validators.required, Validators.minLength(4)]],
      ConfirmPassword : ['',[Validators.required, Validators.minLength(4)]]
    }, {validator : this.comparePasswords}),
    
    
      });

      loginFormModel = this.formBuilder.group({
        UserName : ['',[Validators.email,Validators.required]],
          Password : ['',[Validators.required, Validators.minLength(4)]],
          });
      comparePasswords(formBuilder :FormGroup)
      {
        let confirmPassword = formBuilder.get('ConfirmPassword');
if(formBuilder.get('Password').value != confirmPassword.value)
  confirmPassword.setErrors({passwordMismatch:true});
else
  confirmPassword.setErrors(null);
      }

      getUserProfile()
      {
        var tokenHeader =new HttpHeaders({'Authorization':'Bearer ' + localStorage.getItem('token')});
        return this.http.get(this.APIURI+ '/UserProfile', {headers : tokenHeader});

      }
      register()
      {
        var user = {
UserName : this.formModel.value.EmailAddress,
EmailAddress : this.formModel.value.EmailAddress,
FirstName : this.formModel.value.FirstName,
LastName : this.formModel.value.LastName,
Password : this.formModel.value.Passwords.Password,
        };

       return this.http.post(this.APIURI + '/AppUser/Register' , user);
      }
      login(formData:any)
      {
       return this.http.post(this.APIURI + '/AppUser/Login' , formData);
      }
      login_()
      {
        var user = {
UserName : this.loginFormModel.value.EmailAddress, 
Password : this.loginFormModel.value.Passwords.Password,
        };

       return this.http.post(this.APIURI + '/AppUser/Login' , user);
      }
    }

  