import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../shared/request.service';
import { CityWhichIVisited } from './cityWhichIVisited';
import { City } from '../city/City';

@Component({
    moduleId: module.id,
    templateUrl: 'cityWhichIVisitedAdd.component.html'
})
export class CityWhichIVisitedAddComponent {
    public cityVisited: CityWhichIVisited;
    public city: City;
    public temp: City;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.cityVisited = new CityWhichIVisited();
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
        this.cityVisited.CityId = cityId;
        this.rs.post('citiesWhichIVisited', this.cityVisited).subscribe((response: any) => {
            this.router.navigate(['../citiesWhichIVisited'], { relativeTo: this.activateRoute });
        });
    }

}