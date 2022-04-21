import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CustomersComponent } from './components/customers.component';
import { CustomersRoutingModule } from './customers-routing.module';

@NgModule({
  declarations: [CustomersComponent],
  imports: [CoreModule, ThemeSharedModule, CustomersRoutingModule],
  exports: [CustomersComponent],
})
export class CustomersModule {
  static forChild(): ModuleWithProviders<CustomersModule> {
    return {
      ngModule: CustomersModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CustomersModule> {
    return new LazyModuleFactory(CustomersModule.forChild());
  }
}
