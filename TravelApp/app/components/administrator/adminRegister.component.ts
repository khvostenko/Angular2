import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service';
import { RequestService } from '../../shared/request.service';
import { AdminRegistration } from './AdminRegistration';

@Component({
    moduleId: module.id,
    templateUrl:'adminRegister.component.html'
})
export class AdminRegisterComponent {
    public model: AdminRegistration = new AdminRegistration();
    loading = false;

    constructor(private router: Router, private activateRoute: ActivatedRoute, private authService: AuthenticationService, private rs: RequestService) {
    }

    Register(model: AdminRegistration) {
        this.loading = true;

        this.authService.register(this.model).subscribe((response: any) => {
            let temp = response;
            this.loading = false;
            this.router.navigate(['../administrators'], { relativeTo: this.activateRoute });

        }, (error: any) => {
            let temp = error;
            console.log(error);
            alert('Registration error!');
        });
    }
}