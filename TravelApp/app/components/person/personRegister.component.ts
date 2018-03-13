import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service';
import { RequestService } from '../../shared/request.service';
import { PersonRegistration } from './PersonRegistration';


@Component({
    moduleId: module.id,
    templateUrl: 'personRegister.component.html'
})
export class PersonRegisterComponent {
    model: PersonRegistration = new PersonRegistration();
    loading = false;

    constructor(private router: Router, private authService: AuthenticationService, private activateRoute: ActivatedRoute, private rs: RequestService) {

    }

    Register(model: PersonRegistration) {
        this.loading = true;

        this.authService.register(model).subscribe((response: any) => {
            let temp = response;
            this.loading = false;
            this.router.navigate(['login'], { relativeTo: this.activateRoute });
        }, (error: any) => {
            let temp = error;
            alert('Registration errror!');
        }); 
    }
}