 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44353/',
  redirectUri: baseUrl,
  clientId: 'Citas_App',
  responseType: 'code',
  scope: 'offline_access Citas',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'Citas',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44353',
      rootNamespace: 'Gestor.Citas',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
