import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Login } from './login/login';
import { Panel } from './panel/panel';

const routes: Routes = [
  { path: 'panel', component: Panel },
  { path: 'login', component: Login },
  { path: '', redirectTo: 'panel', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
