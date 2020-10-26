import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './login/register/register.component';
import { CatelogComponent } from './catelog/catelog.component';

const routes: Routes = [
  {path:'', redirectTo:'login/register', pathMatch:'full'},
  {path:'home', component:HomeComponent, canActivate:[AuthGuard]},
  {path:'catelog', component:CatelogComponent},
  {path:'login', component:LoginComponent,
children:[
  {path:'register', component:RegisterComponent},
  ]}]


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
