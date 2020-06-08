import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { environment } from './../environments/environment'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private oauthService: OAuthService) {
    this.configureAuth();
  }
  private configureAuth(): void {
    
    this.oauthService.configure({
      issuer: environment.auth.issuer,
      loginUrl: environment.auth.loginUrl,
    //  logoutUrl: environment.auth.logoutUrl, //not for aad
      redirectUri: window.location.origin + '/index.html',
      clientId: environment.auth.clientId,
      scope: environment.auth.scopes,
      requestAccessToken: false,
      responseType: 'id_token'//for azure ad
    });

    this.oauthService.setStorage(sessionStorage);
    if (environment.production) {
      this.oauthService.tryLogin();
    } else {
      this.oauthService.tryLogin({
        onTokenReceived: context => {
          console.debug("logged in");
          console.info(this.oauthService.getAccessToken());
          console.info(this.oauthService.getIdToken());
          console.info(this.oauthService.getIdentityClaims());
        }
      });      
    }
  }

  
}
