// This file can be replaced during build by using the `fileReplacements` array.
// `ng build ---prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  auth: {
    //issuer: "https://login.microsoftonline.com/' + TENANT_GUID + '/v2.0",
    issuer: "https://login.microsoftonline.com/29894e3d-5902-4ac8-938a-11fe5b3778fa/v2.0",
    //loginUrl: "https://login.microsoftonline.com/' + TENANT_GUID + '/oauth2/v2.0/authorize",
    loginUrl: "https://login.microsoftonline.com/29894e3d-5902-4ac8-938a-11fe5b3778fa/oauth2/v2.0/authorize",
    logoutUrl: "",
    clientId: "9ef2e516-abb0-4422-8b0c-c8345b0e0208",   
    scopes: "openid email profile",


  }
};

/*
 * In development mode, to ignore zone related error stack frames such as
 * `zone.run`, `zoneDelegate.invokeTask` for easier debugging, you can
 * import the following file, but please comment it out in production mode
 * because it will have performance impact when throw error
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
