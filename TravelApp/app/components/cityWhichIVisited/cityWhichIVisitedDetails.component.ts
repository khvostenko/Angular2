import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CityWhichIVisited } from './cityWhichIVisited';

@Component({
    moduleId: module.id,
    templateUrl: 'cityWhichIVisitedDetails.component.html'
})
export class CityWhichIVisitedDetailsComponent {
    public city: CityWhichIVisited;

}