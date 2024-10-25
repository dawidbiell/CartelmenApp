import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { BuildingModule } from './building/building.module';
import { WorkerModule } from './worker/worker.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BuildingModule,
    SharedModule,
    WorkerModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
