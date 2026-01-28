import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { LPUComponent } from './lpu.component';

@NgModule({
  declarations: [
    LPUComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [LPUComponent]
})
export class AppModule { }
