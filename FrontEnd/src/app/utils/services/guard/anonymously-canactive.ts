import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { UtilsService } from '../utils.service';

@Injectable({
    providedIn: 'root'
})
export class AnonymouslyCanActive implements CanActivate {
    constructor(private utilsService:UtilsService,private  router:Router){}
    canActivate() {
        if(this.utilsService.loggedUser.isLoggedIn)
        {
            this.router.navigate(['/']);
        return false;
        }
        return true ;
    }
}
