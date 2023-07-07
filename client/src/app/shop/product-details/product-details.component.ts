import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/Model/IProduct';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss'],
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  constructor(
    private shopSevice: ShopService,
    private activateRoute: ActivatedRoute,
    private bcService: BreadcrumbService
  ) {
    this.bcService.set('@productDetails', ' ');
  }
  ngOnInit(): void {
    this.getProduct();
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
