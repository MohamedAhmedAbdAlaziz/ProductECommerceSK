import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import { BasketRoutingModule } from './basket-routing.module';
import { SharedModule } from '../shared/shared.module';
import { OrderSepficComponent } from './order-sepfic/order-sepfic.component';
import { BasketService } from './basket.service';

@NgModule({
  declarations: [BasketComponent, OrderSepficComponent],
  imports: [CommonModule, BasketRoutingModule, SharedModule],
})
export class BasketModule {}
