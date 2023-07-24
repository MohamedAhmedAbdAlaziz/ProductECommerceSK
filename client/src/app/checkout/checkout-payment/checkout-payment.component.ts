import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { BasketService } from 'src/app/basket/basket.service';
import { CheckoutService } from '../checkout.service';
import { IBasket } from 'src/app/shared/basket';
import { IOrder, IOrderToCreate } from 'src/app/shared/Model/Order';
import { ToastrService } from 'ngx-toastr';
import { NavigationExtras, Router } from '@angular/router';
import { state } from '@angular/animations';

@Component({
  selector: 'app-checkout-payment',
  templateUrl: './checkout-payment.component.html',
  styleUrls: ['./checkout-payment.component.scss'],
})
export class CheckoutPaymentComponent implements OnInit {
  @Input() checkoutForm: FormGroup;
  constructor(
    private basketService: BasketService,
    private checkoutSevice: CheckoutService,
    private toastr: ToastrService,
    private route: Router
  ) {}

  ngOnInit(): void {}

  submit() {
    const basket = this.basketService.getCurrentBasketValue();
    const orderToCreate = this.getOrderToCreate(basket);
    this.checkoutSevice.createOrder(orderToCreate).subscribe(
      (order: IOrder) => {
        this.toastr.success('Order created Succssfully');
        this.basketService.deleteLocalBasket(basket.id);
        const navigationExtras: NavigationExtras = { state: order };
        this.route.navigate(['checkout/success'], navigationExtras);

        console.log(order);
      },
      (error) => {
        this.toastr.error(error.message);
        console.log(error);
      }
    );
  }
  getOrderToCreate(basket: IBasket): IOrderToCreate {
    return {
      basketId: basket.id,
      deliveryMethodId: +this.checkoutForm
        .get('deliveryForm')
        .get('deliveryMethod').value,
      shipToAddress: this.checkoutForm.get('addressForm').value,
    };
  }
}
