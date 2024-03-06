import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductosModule } from './productos/productos.module';
import { AuthModule } from './auth/auth.module';
import { DirectivasComponent } from './directivas/directivas.component';
import { CiclosComponent } from './ciclos/ciclos.component';
import { FormsComponent } from './forms/forms.component';

@NgModule({
  declarations: [
    AppComponent,
    DirectivasComponent,
    CiclosComponent,
    FormsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ProductosModule,
    AuthModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
