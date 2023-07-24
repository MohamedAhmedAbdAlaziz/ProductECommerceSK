import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/Model/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  quantity = 1;
  constructor(
    private shopSevice: ShopService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService
  ) {
    this.bcService.set('@productDetails', ' ');
  }
  ngOnInit(): void {
    this.getProduct();
  }
  addItemToBasket() {
    this.basketService.addItemTOBasket(this.product, this.quantity);
  }
  IncrementQuantity() {
    this.quantity++;
  }
  DecrementQuantity() {
    if (this.quantity > 1) this.quantity--;
  }
  getProduct() {
    this.shopSevice
      .getProduct(+this.activateRoute.snapshot.paramMap.get('id'))
      .subscribe((response) => {
        this.product = response;
        this.bcService.set('@productDetails', response.name);
      });
  }
}
