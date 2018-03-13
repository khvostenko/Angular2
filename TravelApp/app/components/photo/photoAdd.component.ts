import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../shared/request.service';
import { Photo } from './Photo';

@Component({
    moduleId: module.id,
    templateUrl: 'photoAdd.component.html'
})
export class PhotoAddComponent {
    public photo: Photo;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService) {
        this.photo = new Photo();
        this.photo.PersonId = this.activateRoute.snapshot.params['personId'];
        this.photo.CityId = this.activateRoute.snapshot.params['cityId'];
    }

    Done(myItem: Comment) {
        this.rs.post('photos', myItem).subscribe((response: any) => {
            this.photo = response.json();
            this.router.navigate(['../city-photo'], { relativeTo: this.activateRoute });
        })
    }
}