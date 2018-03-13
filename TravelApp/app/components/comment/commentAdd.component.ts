import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RequestService } from '../../shared/request.service';
import { AuthenticationService } from '../../shared/authentication.service';
import { Comment } from './Comment';

@Component({
    moduleId: module.id,
    templateUrl: 'commentAdd.component.html'
})
export class CommentAddComponent {
    public comment: Comment;


    constructor(private router: Router, private activateRoute: ActivatedRoute, private rs: RequestService, private authService: AuthenticationService) {
        this.comment = new Comment();
        this.comment.PersonId = this.authService.currentUserId;
        this.comment.CityId = this.activateRoute.snapshot.params['cityId'];
    }

    Done() {
        this.rs.post('comments', this.comment).subscribe((response: any) => {
            this.comment = response.json();
            this.router.navigate(['../city-comment'], { relativeTo: this.activateRoute });
        })
    }
}