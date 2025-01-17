import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'
import { FormBuilder, Validators } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIURL = 'http://localhost:50714/api';
readonly ImagesURL = 'http://50714:52101/Images';
  constructor(private http:HttpClient, private formBuilder : FormBuilder) {  }

  formModel = this.formBuilder.group({
UserName : ['',Validators.required],
Email : ['',Validators.email],
FullName : [''],
Passwords : [this.formBuilder.group({
  Password : ['',[Validators.required, Validators.minLength(4)]],
  CofirmPassword : ['',[Validators.required, Validators.minLength(4)]]
})],


  });
  getBookImage()
  {
    this.ImagesURL + '/book.png';
  }
getBooks():Observable<any[]>
{
return this.http.get<any>(this.APIURL + '/Book');
}
addBook(val:any)
{
return this.http.post(this.APIURL + '/Book' , val);
}
updateBook(val:any)
{
return this.http.put(this.APIURL + '/Book' , val);
}
deleteBook(val:any)
{
return this.http.delete(this.APIURL + '/Book/'+ val);
}
getUsers():Observable<any[]>
{
return this.http.get<any>(this.APIURL + '/User');
}
addUser(val:any)
{
return this.http.post(this.APIURL + '/User' , val);
}
updateUser(val:any)
{
return this.http.put(this.APIURL + '/User' , val);
}
deleteUser(val:any)
{
return this.http.delete(this.APIURL + '/User/' + val);
}

UploadImage(val:any)
{
  return this.http.post(this.APIURL + '/User/SaveImage' , val);
}
selectBooks():Observable<any[]>
{
return this.http.get<any>(this.APIURL + '/Book/GetAllBooks');
}
selectUsers():Observable<any[]>
{
return this.http.get<any>(this.APIURL + '/User/GetAllUsers');
}
 

}
