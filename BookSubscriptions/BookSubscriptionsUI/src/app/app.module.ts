import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './login/register/register.component';
import { CommonModule } from '@angular/common';  
import { RegisterService } from './shared/register.service';
import { SharedService } from './shared/shared.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';
import { HomeComponent } from './home/home.component';
import { CatelogComponent } from './catelog/catelog.component';
import { BookComponent } from './book/book.component';
import { ShowDelBookComponent } from './book/show-del-book/show-del-book.component';
import { AddEditBookComponent } from './book/add-edit-book/add-edit-book.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    CatelogComponent,
    BookComponent,
    ShowDelBookComponent,
    AddEditBookComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
  ],
  providers: [RegisterService,SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
