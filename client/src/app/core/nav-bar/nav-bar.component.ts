import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BasketService } from 'src/app/basket/basket.service';
import { IUser } from 'src/app/shared/Model/user';
import { IBasket } from 'src/app/shared/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent {
  basket$: Observable<IBasket>;
  currentUser$: Observable<IUser>;

  constructor(
    private basketService: BasketService,
    private accountService: AccountService
  ) {}
  ngOnInit(): void {
    console.log('basket');

    this.basket$ = this.basketService.basket$;
    this.currentUser$ = this.accountService.currentUser$;
  }
  logout() {
    this.accountService.logout();
  }
}
