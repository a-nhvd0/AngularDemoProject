import { HttpClientModule } from '@angular/common/http';
import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Login } from './login/login';
import { Panel } from './panel/panel';

import { providePrimeNG } from 'primeng/config';
import { ButtonModule } from 'primeng/button';
import Aura from '@primeuix/themes/aura';

@NgModule({
  declarations: [App, Login, Panel],
  imports: [BrowserModule, HttpClientModule, AppRoutingModule, ButtonModule, FormsModule],
  providers: [
    provideBrowserGlobalErrorListeners(),
    providePrimeNG({
      theme: {
        preset: Aura,
      },
    }),

  ],
  bootstrap: [App],
})
export class AppModule {}
