import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ResourceryHRAdmin',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:7600/',
    redirectUri: baseUrl,
    clientId: 'ResourceryHR_Admin',
    responseType: 'code',
    scope: 'ResourceryHRAuthServer ResourceryHRIdentityService ResourceryHRAdministration ResourceryHRSaaS ResourceryHRRecruitment',
    requireHttps: false,
  },
  apis: {
    default: {
      url: 'https://localhost:7500',
      rootNamespace: 'ResourceryHRAdmin',
    },
  },
   localization: {
    defaultResourceName: "Recruitment",
  },
} as Environment;
