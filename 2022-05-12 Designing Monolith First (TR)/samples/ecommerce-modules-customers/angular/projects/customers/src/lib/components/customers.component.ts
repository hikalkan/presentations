import { Component, OnInit } from '@angular/core';
import { CustomersService } from '../services/customers.service';

@Component({
  selector: 'lib-customers',
  template: ` <p>customers works!</p> `,
  styles: [],
})
export class CustomersComponent implements OnInit {
  constructor(private service: CustomersService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
