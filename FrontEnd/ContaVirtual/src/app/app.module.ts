import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ExtratoListagemComponent } from './extrato-listagem/extrato-listagem.component';
import { ExtratoService } from './extrato.service';

@NgModule({
  declarations: [
    AppComponent,
    ExtratoListagemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [HttpClientModule,ExtratoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
