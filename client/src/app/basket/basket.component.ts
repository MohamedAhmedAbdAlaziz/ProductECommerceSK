import { Component } from '@angular/core';
import { BasketService } from './basket.service';
import { IBasket, IBasketItem } from '../shared/basket';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.scss'],
})
export class BasketComponent {
  basket$: Observable<IBasket>;

  constructor(private basketService: BasketService) {}
  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }
  removeBasketItem(item: IBasketItem) {}
  incrementItemQuantity(item: IBasketItem) {}
  decrementItemQuantity(item: IBasketItem) {}
}
