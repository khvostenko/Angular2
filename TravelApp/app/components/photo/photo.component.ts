import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { AuthenticationService } from '../../shared/authentication.service';
import { Photo } from './Photo';
import { Router } from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'photo.component.html'
})
export class PhotoComponent {
    public photos: Photo[];

    constructor(private router: Router, private rs: RequestService, private authService: AuthenticationService) {
        let currentUserId = authService.currentUserId;
        this.rs.get('photos/' + currentUserId).subscribe(result => {
            this.photos = result.json();
        });
    }
}