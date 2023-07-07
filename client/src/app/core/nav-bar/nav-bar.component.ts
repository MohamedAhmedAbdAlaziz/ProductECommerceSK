import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { BasketService } from 'src/app/basket/basket.service';
import { IBasket } from 'src/app/shared/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent {
  basket$: Observable<IBasket>;

  constructor(private basketService: BasketService) {}
  ngOnInit(): void {
    this.basket$ = this.basketService.basket$;
  }
}
