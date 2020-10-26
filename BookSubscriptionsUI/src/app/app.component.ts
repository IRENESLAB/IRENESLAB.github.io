import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'BookSubscriptionsUI';
  ModalTitle:string; 
  ActivateRegisterComp:boolean=false;
  goToLogin(show:boolean)
  {
    this.ActivateRegisterComp=show;
    this.ModalTitle="Login";
  }
}
