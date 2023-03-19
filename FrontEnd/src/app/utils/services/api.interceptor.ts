import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UtilsService } from './utils.service';

@Injectable()
export class APIInterceptor implements HttpInterceptor {
    constructor(private utilsService:UtilsService){}
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        const apiReq = req.clone({
            url: `${environment.apiBaseUrl}/${req.url}`,
            // body:JSON.stringify(req.body),
            headers: req.headers
              .append('authorization', `bearer ${this.utilsService.storage.accessToken}`)
                .append('content-type', `application/json`)
        });
        return next.handle(apiReq);
    }
}
