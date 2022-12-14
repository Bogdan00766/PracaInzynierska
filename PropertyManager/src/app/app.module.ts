import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HttpClientModule } from '@angular/common/http';
import { AppConfigService } from './app-config.service';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { LogoutComponent } from './logout/logout.component';
import { FinancialChangeComponent } from './financial-change/financial-change.component';
import { DashboardComponent } from './dashboard/dashboard.component';
//import { MatAutocompleteModule, MatButtonModule, MatCheckboxModule, MatDatepickerModule, MatFormFieldModule, MatInputModule, MatRadioModule, MatSelectModule, MatSliderModule, MatSlideToggleModule } from '@angular/material';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    NavMenuComponent,
    LogoutComponent,
    FinancialChangeComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    //MatAutocompleteModule,
    //MatButtonModule,
    //MatCheckboxModule,
    //MatDatepickerModule,
    //MatFormFieldModule,
    //MatInputModule,
    //MatRadioModule,
    //MatSelectModule,
    //MatSliderModule,
    //MatSlideToggleModule,
    BrowserAnimationsModule,
    NgbModule
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      multi: true,
      deps: [AppConfigService],
      useFactory: (appConfigService: AppConfigService) => () => appConfigService.loadAppConfig()
    }  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
