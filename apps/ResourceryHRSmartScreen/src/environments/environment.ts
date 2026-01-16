import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ResourceryHRSmartScreen',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7600/',
    redirectUri: baseUrl,
    clientId: 'ResourceryHRSmartScreen_Angular',
    responseType: 'code',
    scope: 'ResourceryHRIdentityService ResourceryHRAdministration ResourceryHRSaaS',
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'ResourceryHRSmartScreen',
    },
  },
} as Environment;
