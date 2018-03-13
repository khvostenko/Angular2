import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { AuthenticationService } from '../../shared/authentication.service';
import { Comment } from './Comment';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'commentByCity.component.html'
})
export class CommentByCityComponent {
    public coments: Comment[];
    private id: number;

    constructor(private router: Router, private rs: RequestService, private authService: AuthenticationService, private activateRoute: ActivatedRoute) {
        this.id = activateRoute.snapshot.params['cityId'];
        this.rs.get('commentsbycity/' + this.id).subscribe(result => {
            this.coments = result.json();
        });
    }
}