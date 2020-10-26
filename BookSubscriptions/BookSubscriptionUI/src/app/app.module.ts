import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { ShowDelUserComponent } from './user/show-del-user/show-del-user.component';
import { AddEditUserComponent } from './user/add-edit-user/add-edit-user.component';
import { BookComponent } from './book/book.component';
import { ShowDelBookComponent } from './book/show-del-book/show-del-book.component';
import { AddEditBookComponent } from './book/add-edit-book/add-edit-book.component';
import { SharedService } from './shared.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { CatelogComponent } from './catelog/catelog.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    ShowDelUserComponent,
    AddEditUserComponent,
    BookComponent,
    ShowDelBookComponent,
    AddEditBookComponent,
    CatelogComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
