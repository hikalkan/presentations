import { Component, OnInit } from '@angular/core';
import { OrderingService } from '../services/ordering.service';

@Component({
  selector: 'lib-ordering',
  template: ` <p>ordering works!</p> `,
  styles: [],
})
export class OrderingComponent implements OnInit {
  constructor(private service: OrderingService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
