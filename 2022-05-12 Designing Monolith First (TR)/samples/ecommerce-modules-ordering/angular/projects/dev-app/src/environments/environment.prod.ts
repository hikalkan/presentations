import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Ordering',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44329',
    redirectUri: baseUrl,
    clientId: 'Ordering_App',
    responseType: 'code',
    scope: 'offline_access Ordering',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44329',
      rootNamespace: 'ECommerce.Ordering',
    },
    Ordering: {
      url: 'https://localhost:44371',
      rootNamespace: 'ECommerce.Ordering',
    },
  },
} as Environment;
