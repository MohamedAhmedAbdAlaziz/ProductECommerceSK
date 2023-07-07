import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPagination } from '../shared/Model/IPagination';
import { IType } from '../shared/Model/productType';
import { IBrand } from '../shared/Model/IBrand';
import { map, delay } from 'rxjs/operators';
import { ShopParams } from '../shared/Model/ShopParams';
import { IProduct } from '../shared/Model/IProduct';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  getProducts(shopPrams: ShopParams) {
    let params = new HttpParams();
    if (shopPrams.brandId != 0) {
      params = params.append('brandId', shopPrams.brandId.toString());
    }
    if (shopPrams.typeId != 0) {
      params = params.append('typeId', shopPrams.typeId.toString());
    }
    if (shopPrams.search) {
      params = params.append('search', shopPrams.search);
    }

    params = params.append('sort', shopPrams.sort);
    params = params.append('pageIndex', shopPrams.pageNumber.toString());
    params = params.append('pageSize', shopPrams.pageSize.toPrecision());

    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        // delay(1000),
        map((response) => {
          return response.body;
        })
      );
    // return this.http.get<IPagination>(this.baseUrl + 'products?pageSize=50');
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }

  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
