import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Person } from './Person';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service'

@Component({
    moduleId: module.id,
    templateUrl: 'personInfo.component.html'
})
export class PersonInfoComponent {
    public person: Person = new Person();

    constructor(private rs: RequestService,
        private authService: AuthenticationService) {

        let currentId = authService.currentUserId;
        this.rs.get('persons/' + currentId).subscribe((result: any) => {
            this.person = result.json();
        });
    }
}