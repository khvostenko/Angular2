import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { AuthenticationService } from '../../shared/authentication.service';
import { Comment } from './Comment';
import { Router } from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'comment.component.html'
})
export class CommentComponent {
    public coments: Comment[];

    constructor(private router: Router, private rs: RequestService, private authService: AuthenticationService) {
        let currentUserId = authService.currentUserId;
        this.rs.get('comments/' + currentUserId).subscribe(result => {
            this.coments = result.json();
        });
    }
}