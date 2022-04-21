import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { OrderingComponent } from './components/ordering.component';
import { OrderingRoutingModule } from './ordering-routing.module';

@NgModule({
  declarations: [OrderingComponent],
  imports: [CoreModule, ThemeSharedModule, OrderingRoutingModule],
  exports: [OrderingComponent],
})
export class OrderingModule {
  static forChild(): ModuleWithProviders<OrderingModule> {
    return {
      ngModule: OrderingModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<OrderingModule> {
    return new LazyModuleFactory(OrderingModule.forChild());
  }
}
