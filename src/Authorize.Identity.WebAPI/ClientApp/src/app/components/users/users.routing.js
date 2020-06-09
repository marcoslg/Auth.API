"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var users_list_component_1 = require("./users-list/users-list.component");
var users_component_1 = require("./users.component");
//import { IconsComponent } from '../../pages/icons/icons.component';
//import { MapsComponent } from '../../pages/maps/maps.component';
//import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
//import { TablesComponent } from '../../pages/tables/tables.component';
exports.UsersRoutes = [
    {
        path: '', component: users_component_1.UsersComponent,
        children: [
            {
                path: 'list',
                component: users_list_component_1.UsersListComponent
            },
            {
                path: '**',
                redirectTo: 'list'
            }
        ]
    },
];
//# sourceMappingURL=users.routing.js.map