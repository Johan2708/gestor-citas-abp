import { RoutesService, eLayoutType } from '@abp/ng.core';
import { inject, provideAppInitializer } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  provideAppInitializer(() => {
    configureRoutes();
  }),
];

function configureRoutes() {
  const routes = inject(RoutesService);
  routes.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },
      {
        path: '/books',
        name: '::Menu:Books',
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
        requiredPolicy: 'Citas.Books',
      },
      {
        path: '/clientes',
        name: '::Menu:Clients',
        iconClass: 'fas fa-user',
        layout: eLayoutType.application,
        requiredPolicy: 'Citas.Clientes',
      },
<<<<<<< Updated upstream
      {
        path: '/profesionales',
        name: '::Menu:Professionals',
        iconClass: 'fas fa-user-tie',
        layout: eLayoutType.application
=======
       {
        path: '/citas',
        name: '::Appointments',
        iconClass: 'fas fa-book',
        layout: eLayoutType.application,
>>>>>>> Stashed changes
      },
  ]);
}
