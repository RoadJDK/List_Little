// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  auth: {
    domain: 'maibach-studios.eu.auth0.com',
    audience: 'https://list-little.example.com',
    clientId: 'yYW5lzQhNlEY5iCL7keY63X0HDDuXXqo',
    clientSecret: 'QYEzP51snfVmy9qyU-TNH5dix30Wz7n5B-k42p1c6ACE3S2HzWFAeNn3to2Jkij_',
    redirectUri: 'https://localhost:7075/',
  },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
