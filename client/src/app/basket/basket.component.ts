import { Component } from '@angular/core';
import { BasketService } from './basket.service';
import { IBasket, IBasketItem, IBasketTotlals } from '../shared/basket';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss'],
})
export class BasketComponent {
  basket$: Observable<IBasket>;
  basketTotals$: Observable<IBasketTotlals>;

  constructor(private basketService: BasketService) {}
  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
    this.basketTotals$ = this.basketService.basketTotal$;
  }
  removeBasketItem(item: IBasketItem) {
    this.basketService.removeItemFormBasket(item);
  }
  incrementItemQuantity(item: IBasketItem) {
    this.basketService.incrementItemQuantity(item);
  }
  decrementItemQuantity(item: IBasketItem) {
    this.basketService.decrementItemQuantity(item);
  }
}
