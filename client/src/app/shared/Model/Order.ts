import { IAddress } from './ShipToAddress';

export interface IOrderToCreate {
  basketId: string;
  deliveryMethodId: number;
  shipToAddress: IAddress;
}
export interface IOrder {
  id: number;
  buyerEmail: string;
  orderDate: Date;
  shipToAddress: IAddress;
  deliveryMethod: string;
  orderItems: OrderItem[];
  subtotal: number;
  status: number;
  paymentIntentId: string;
}

export interface OrderItem {
  productItemId: number;
  productName: string;
  pictureUrl: string;
  price: number;
  quantity: number;
}
