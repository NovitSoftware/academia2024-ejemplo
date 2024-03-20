import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductosModule } from './productos/productos.module';
import { AuthModule } from './auth/auth.module';
import { DirectivasComponent } from './directivas/directivas.component';
import { CiclosComponent } from './ciclos/ciclos.component';
import { HttpClientModule } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

@NgModule({
  declarations: [
    AppComponent,
    DirectivasComponent,
    CiclosComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProductosModule,
    HttpClientModule,
    AuthModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
