import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RequestService } from '../../shared/request.service';
import { AuthenticationService } from '../../shared/authentication.service';
import { CityWhichIVisited } from '../cityWhichIVisited/cityWhichIVisited';
import { City } from '../city/City';

@Component({
    moduleId: module.id,
    templateUrl: 'cityWhichIVisitedcomponent.html'
})
export class CityWhichIVisitedComponent {
    public cities: CityWhichIVisited[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService, private authService: AuthenticationService) {
        this.myRouter = router;
        this.requestService = rs;
        let currentUserId = authService.currentUserId;
        this.requestService.get('citiesWhichIVisited/' + currentUserId).subscribe(result => {
            this.cities = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('citiesWhichIVisited/' + id).subscribe((resp: any) => {
            this.cities = this.cities.filter(x => x.Id !== id);
        });
    }
}