import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasketTotlals } from 'src/app/shared/basket';
import { BasketService } from '../basket.service';

@Component({
  selector: 'app-order-sepfic',
  templateUrl: './order-sepfic.component.html',
  styleUrls: ['./order-sepfic.component.scss'],
})
export class OrderSepficComponent implements OnInit, OnChanges {
  @Input() baskettotals$: Observable<IBasketTotlals>;
  subtotal;
  shippingPrice;
  total;
  constructor(public basketService: BasketService) {
    this.baskettotals$ = this.basketService.basketTotal$;
  }
  ngOnInit(): void {
    this.baskettotals$ = this.basketService.basketTotal$;
  }

  ngOnChanges() {
    this.baskettotals$ = this.basketService.basketTotal$;
  }
  setValues() {
    this.baskettotals$ = this.basketService.basketTotal$;
    this.baskettotals$.subscribe((red) => {
      this.shippingPrice = red.shipping;
      this.subtotal = red.subtotal;
      this.total = red.total;
    });
  }
}
