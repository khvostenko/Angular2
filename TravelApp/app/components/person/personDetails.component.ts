import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Person } from './Person';
import { ActivatedRoute, Router } from '@angular/router';
import { CityWhichIWantToVisit } from '../cityWhichIWantToVisit/cityWhichIWantToVisit';
import { CityWhichIVisited } from '../cityWhichIVisited/cityWhichIVisited';

@Component({
    moduleId: module.id,
    templateUrl: 'personDetails.component.html'
})
export class PersonDetailsComponent {
    public person: Person;
    private citiesVisited: CityWhichIVisited[];
    private citiesWant: CityWhichIWantToVisit[];
    private id: number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private requestService: RequestService) {
        this.id = activateRoute.snapshot.params['id'];

        this.requestService.get('persons/' + this.id)
            .toPromise()
            .then(response => response.json())
            .then((result: any) => {
                this.person = result;
                this.getCitiesWhichIVisitedtByUser(this.person.Id)
            })
            .then((result: any) => {
                this.getCitiesWhichIWantToVisitByUser(this.person.Id);
            });
    }


    private getCitiesWhichIWantToVisitByUser(userId: number) {
        this.requestService.get('citiesWhichIWantToVisit/' + userId).subscribe((result: any) => {
            this.citiesWant = result.json();
        });
    }

    private getCitiesWhichIVisitedtByUser(userId: number) {
        this.requestService.get('citiesWhichIVisited/' + userId).subscribe((result: any) => {
            this.citiesVisited = result.json();
        });
    }
}