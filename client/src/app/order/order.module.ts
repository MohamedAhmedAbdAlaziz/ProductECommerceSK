import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderComponent } from './order.component';
import { OrderDetailedComponent } from './order-detailed/order-detailed.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [OrderComponent, OrderDetailedComponent],
  imports: [CommonModule, RouterModule, SharedModule],
  exports: [RouterModule],
})
export class OrderModule {}
