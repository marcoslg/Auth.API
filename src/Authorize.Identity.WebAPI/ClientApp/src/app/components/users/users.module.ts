import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UsersListComponent } from './users-list/users-list.component';
import { UsersRoutes } from './users.routing';
import { UsersComponent } from './users.component';



@NgModule({
  
  imports: [
    CommonModule,
    RouterModule.forChild(UsersRoutes),
  ],
  declarations: [
    UsersListComponent,
    UsersComponent
  ],
  exports: [    
    RouterModule
  ]
})
export class UsersModule { }
