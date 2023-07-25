import { Component, Input, OnChanges, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasketTotlals } from '../../basket';

@Component({
  selector: 'app-order-totals',
  templateUrl: './order-totals.component.html',
  styleUrls: ['./order-totals.component.scss'],
})
export class OrderTotalsComponent implements OnInit, OnChanges {
  baskettotals$: Observable<IBasketTotlals>;
  @Input() subtotal;
  @Input() shippingPrice;
  @Input() total;
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
