import { Routes } from '@angular/router';
import { Home } from '../features/home/home';
import { SpotList } from '../features/spots/spot-list/spot-list';
import { SpotDetalied } from '../features/spots/spot-detalied/spot-detalied';
import { Lists } from '../features/lists/lists';
import { Messages } from '../features/messages/messages';
import { LogTime } from '../features/tracker/log-time/log-time';
import { authGuard } from '../core/guards/auth-guard';

export const routes: Routes = [
  {path:'', component: Home},
  {path:'log-time', component: LogTime, canActivate: [authGuard]},
  {path:'spots', component: SpotList, canActivate: [authGuard]},
  {path:'spots/:id', component: SpotDetalied, canActivate: [authGuard]},
  {path:'lists', component: Lists, canActivate: [authGuard]},
  {path:'messages', component: Messages, canActivate: [authGuard]},
  {path:'**', component: Home},
];

