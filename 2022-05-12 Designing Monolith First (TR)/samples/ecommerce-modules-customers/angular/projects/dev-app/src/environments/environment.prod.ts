import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Customers',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44351',
    redirectUri: baseUrl,
    clientId: 'Customers_App',
    responseType: 'code',
    scope: 'offline_access Customers',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44351',
      rootNamespace: 'ECommerce.Customers',
    },
    Customers: {
      url: 'https://localhost:44305',
      rootNamespace: 'ECommerce.Customers',
    },
  },
} as Environment;
