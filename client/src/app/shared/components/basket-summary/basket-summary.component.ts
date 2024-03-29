import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { IBasket, IBasketItem } from '../../basket';
import { BasketService } from 'src/app/basket/basket.service';
import { IOrder } from '../../Model/Order';

@Component({
  selector: 'app-basket-summary',
  templateUrl: './basket-summary.component.html',
  styleUrls: ['./basket-summary.component.scss'],
})
export class BasketSummaryComponent implements OnInit {
  basket$: Observable<IBasket>;
  @Output() decrement: EventEmitter<IBasketItem> =
    new EventEmitter<IBasketItem>();
  @Output() increment: EventEmitter<IBasketItem> =
    new EventEmitter<IBasketItem>();
  @Output() remove: EventEmitter<IBasketItem> = new EventEmitter<IBasketItem>();
  @Input() isBasket = true;
  @Input() items: IBasketItem[] | IOrder[];
  @Input() isOrder = false;

  constructor(private basketService: BasketService) {}

  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }
  incrementItemQuantity(item: IBasketItem) {
    this.increment.emit(item);
  }
  decrementItemQuantity(item: IBasketItem) {
    this.decrement.emit(item);
  }
  removeBasketItem(item: IBasketItem) {
    this.remove.emit(item);
  }
}
