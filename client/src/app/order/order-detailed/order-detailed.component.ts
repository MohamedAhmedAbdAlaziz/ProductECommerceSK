import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrderService } from '../order.service';
import { IOrder } from 'src/app/shared/Model/Order';

@Component({
  selector: 'app-order-detailed',
  templateUrl: './order-detailed.component.html',
  styleUrls: ['./order-detailed.component.scss'],
})
export class OrderDetailedComponent implements OnInit {
  order: IOrder;
  constructor(
    private route: ActivatedRoute,
    private breadcrmbService: BreadcrumbService,
    private orderService: OrderService
  ) {
    this.breadcrmbService.set('@OrderDetailed', '');
  }

  ngOnInit(): void {
    this.orderService
      .getOrderDetailed(+this.route.snapshot.paramMap.get('id'))
      .subscribe(
        (order: IOrder) => {
          this.order = order;
          this.breadcrmbService.set(
            '@OrderDetailed',
            `Order# ${order.id} - ${order.status}`
          );
        },
        (error) => {
          console.log(error);
        }
      );
  }
}
