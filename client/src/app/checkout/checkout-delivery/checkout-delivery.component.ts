import { Component, Input, OnInit } from '@angular/core';
import { CheckoutService } from '../checkout.service';
import { FormGroup } from '@angular/forms';
import { IDeliveryMethod } from 'src/app/shared/Model/IDeliveryMethod';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-checkout-delivery',
  templateUrl: './checkout-delivery.component.html',
  styleUrls: ['./checkout-delivery.component.scss'],
})
export class CheckoutDeliveryComponent implements OnInit {
  @Input() checkoutForm: FormGroup;
  deliveryMethods: IDeliveryMethod[];
  constructor(
    private checkoutService: CheckoutService,
    private basketService: BasketService
  ) {}

  ngOnInit(): void {
    this.checkoutService.getDeliveryMethods().subscribe(
      (dm: IDeliveryMethod[]) => {
        this.deliveryMethods = dm;
      },
      (error) => {
        console.log(error);
      }
    );
  }
  setShippingPrice(deliveryMethod: IDeliveryMethod) {
    this.basketService.setShipingPrice(deliveryMethod);
  }
}
