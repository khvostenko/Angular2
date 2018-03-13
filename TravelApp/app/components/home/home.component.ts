import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { RequestService } from '../../shared/request.service';
import { City } from '../city/City';

@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})

export class HomeComponent {
    public cities: City;

    //constructor(requestService: RequestService) {
    //    requestService.get('cities').subscribe((result: any) => {
    //        this.cities = result.json();
    //    });
    //}
}