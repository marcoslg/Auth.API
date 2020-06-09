import { Routes } from '@angular/router';

import { UsersListComponent } from './users-list/users-list.component';
import { UsersComponent } from './users.component';
//import { IconsComponent } from '../../pages/icons/icons.component';
//import { MapsComponent } from '../../pages/maps/maps.component';
//import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
//import { TablesComponent } from '../../pages/tables/tables.component';

export const UsersRoutes: Routes = [
  {
    path: '', component: UsersComponent,
    children: [
      {
        path: 'list',
        component: UsersListComponent
      },
      {
        path: '**',
        redirectTo : 'list'
      }
    ]
  },
  //{ path: 'user-profile', component: UserProfileComponent },
  //{ path: 'tables', component: TablesComponent },
  //{ path: 'icons', component: IconsComponent },
  //{ path: 'maps', component: MapsComponent }
];
