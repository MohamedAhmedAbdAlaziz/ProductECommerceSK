import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IProduct } from '../shared/Model/IProduct';
import { ShopService } from './shop.service';
import { IBrand } from '../shared/Model/IBrand';
import { IType } from '../shared/Model/productType';
import { ShopParams } from '../shared/Model/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss'],
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: false }) Search: ElementRef;
  products: IProduct[];
  brands: IBrand[];
  types: IType[];
  shopPrams = new ShopParams();
  totalCount;

  sortOptions = [
    { name: 'Alphabetcal', value: 'name' },
    { name: 'Price Low to High', value: 'priceAsc' },
    { name: 'Price High to Low', value: 'priceDes' },
  ];

  constructor(private shopService: ShopService) {}
  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopPrams).subscribe(
      (response) => {
        this.products = response.data;
        this.shopPrams.pageNumber = response.pageIndex;
        this.shopPrams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      (error) => {
        console.log(error);
      }
    );
  }

  getBrands() {
    this.shopService.getBrands().subscribe(
      (response) => {
        this.brands = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }
  getTypes() {
    this.shopService.getTypes().subscribe(
      (response) => {
        this.types = [{ id: 0, name: 'All' }, ...response];
      },
      (error) => {
        console.log(error);
      }
    );
  }

  onBrandSelected(brandId: number) {
    this.shopPrams.brandId = brandId;
    this.shopPrams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeID: number) {
    this.shopPrams.typeId = typeID;
    this.shopPrams.pageNumber = 1;

    this.getProducts();
  }
  onSortSelected(sort: string) {
    this.shopPrams.sort = sort;
    this.getProducts();
  }
  onPageChanged(event: any) {
    if (this.shopPrams.pageNumber !== event) {
      this.shopPrams.pageNumber = event;
      this.getProducts();
    }
  }
  onSearch() {
    this.shopPrams.search = this.Search.nativeElement.value;
    console.log(this.Search.nativeElement.value);

    this.getProducts();
  }
  onReset() {
    this.Search.nativeElement.value = '';
    this.shopPrams = new ShopParams();
    this.shopPrams.pageNumber = 1;

    this.getProducts();
  }
}
