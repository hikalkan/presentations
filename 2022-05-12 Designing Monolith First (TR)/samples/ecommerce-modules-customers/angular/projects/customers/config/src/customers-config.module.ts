import { ModuleWithProviders, NgModule } from '@angular/core';
import { CUSTOMERS_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CustomersConfigModule {
  static forRoot(): ModuleWithProviders<CustomersConfigModule> {
    return {
      ngModule: CustomersConfigModule,
      providers: [CUSTOMERS_ROUTE_PROVIDERS],
    };
  }
}
