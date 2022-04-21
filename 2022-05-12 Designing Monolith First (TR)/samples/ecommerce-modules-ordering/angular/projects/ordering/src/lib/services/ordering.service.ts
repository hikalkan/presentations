import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class OrderingService {
  apiName = 'Ordering';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/Ordering/sample' },
      { apiName: this.apiName }
    );
  }
}
