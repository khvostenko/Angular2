import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { City } from './City';
import { Router } from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'cities.component.html'
})
export class CityComponent {
    public cities: City[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.requestService.get('cities').subscribe(result => {
            this.cities = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('cities/' + id).subscribe((resp: any) => {
            this.cities = this.cities.filter(x => x.Id !== id);
        })
    }


}
