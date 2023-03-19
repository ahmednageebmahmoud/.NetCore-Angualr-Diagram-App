import { Injectable } from "@angular/core";
import { CookieService } from 'ngx-cookie-service';
import { default as decode, JwtPayload } from 'jwt-decode';
import { environment } from "src/environments/environment";

@Injectable()

export class StorageService {

  constructor(private cook: CookieService) {}

  /**
   * Get Access Token
   */

  get accessToken(): string {
       return this.cook.get('userAuth');
  }

  /**
   * Save Access Token In Cookie
  */
  set accessToken(accessToken: string | null) {
    if (!accessToken) {
      if (environment.production)
        this.cook.delete('userAuth', '/', environment.accessTokenCookieDomain);
      else
        this.cook.delete('userAuth', '/');
        console.log('deleted');

      return;
    }

    let accesDecoded = decode<JwtPayload>(accessToken);

    // Save Access Token
    if (environment.production)
      this.cook.set('userAuth', accessToken, new Date(Number(accesDecoded.exp) * 1000), '/', environment.accessTokenCookieDomain);
    else
      this.cook.set('userAuth', accessToken, new Date(Number(accesDecoded.exp) * 1000), '/');

  }


}
