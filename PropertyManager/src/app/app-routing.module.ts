import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../services/auth.guard';
import { FinancialChangeComponent } from './financial-change/financial-change.component';
import { LogoutComponent } from './logout/logout.component';
import { RegisterComponent } from './register/register.component';
const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'logout', component: LogoutComponent, canActivate: [AuthGuard] },
  { path: 'financialchanges', component: FinancialChangeComponent/*, canActivate: [AuthGuard]*/ },
  { path: '**', component: RegisterComponent },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard],
})
export class AppRoutingModule { }

