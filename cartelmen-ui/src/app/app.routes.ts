import { Routes } from '@angular/router';
import { Home } from '../features/home/home';
import { SpotList } from '../features/spots/spot-list/spot-list';
import { SpotDetalied } from '../features/spots/spot-detalied/spot-detalied';
import { Lists } from '../features/lists/lists';
import { Messages } from '../features/messages/messages';

export const routes: Routes = [
  {path:'', component: Home},
  {path:'spots', component: SpotList},
  {path:'spots/:id', component: SpotDetalied},
  {path:'lists', component: Lists},
  {path:'messages', component: Messages},
  {path:'**', component: Home},
];

