import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ProductManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44340/',
    redirectUri: baseUrl,
    clientId: 'ProductManagement_App',
    responseType: 'code',
    scope: 'offline_access ProductManagement',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44340',
      rootNamespace: 'ProductManagement',
    },
  },
} as Environment;
