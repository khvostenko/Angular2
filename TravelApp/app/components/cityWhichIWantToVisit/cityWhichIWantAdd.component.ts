import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../shared/request.service';
import { CityWhichIWantToVisit } from './cityWhichIWantToVisit';
import { City } from '../city/City';

@Component({
    moduleId: module.id,
    templateUrl:'cityWhichIWantAdd.component.html'
})

export class CityWhichIWantAddComponent {
    public cityWant: CityWhichIWantToVisit;
    public city: City;
    public temp: City;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.cityWant = new CityWhichIWantToVisit();
        this.city = new City();
        this.temp = new City();
    }

    DoneCity(myItem: City) {
        this.rs.post('cities', myItem).subscribe((response: any) => {
            this.rs.get('citybycountry/' + document.getElementById('cityName') + '/' + document.getElementById('cityCountry')).subscribe((res: any) => {
                this.temp = res.json();
            });
            this.DoneCityVisited(this.temp.Id);
        });

    }

    DoneCityVisited(cityId: number) {
        this.cityWant.CityId = cityId;
        this.rs.post('citiesWhichIVisited', this.cityWant).subscribe((response: any) => {
            this.router.navigate(['../citiesWhichiwant'], { relativeTo: this.activateRoute });
        });
    }

}