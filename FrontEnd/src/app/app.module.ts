import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CookieService } from 'ngx-cookie-service';
import { AppRoutingModule } from './app.-routing.module';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { APIInterceptor } from './utils/services/api.interceptor';
import { UtilsModule } from './utils/utils.module';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    UtilsModule,
  ],

    providers: [{
      provide: HTTP_INTERCEPTORS,
      useClass: APIInterceptor,
      multi: true,
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }
