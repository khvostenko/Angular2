import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { AuthenticationService } from '../../shared/authentication.service';
import { CityWhichIWantToVisit } from './cityWhichIWantToVisit';
import { City } from '../city/City';
import { Router } from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'citiesWhichIWant.components.html'
})
export class CityWhichIWantComponents {
    public cities: City[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService, authService: AuthenticationService) {
        this.myRouter = router;
        this.requestService = rs;
        let currentUserId = authService.currentUserId;
        this.requestService.get('citiesWhichIWantToVisit/' + currentUserId).subscribe(result => {
            this.cities = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('cityWhichIWantToVisit/' + id).subscribe((resp: any) => {
            this.cities = this.cities.filter(x => x.Id !== id);
        });
    }
}