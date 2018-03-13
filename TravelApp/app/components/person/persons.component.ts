import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Person } from './Person';
import { Router } from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'person.component.html'
})
export class PersonsComponent {
    public persons: Person[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.requestService.get('persons').subscribe((result: any) => {
            
            this.persons = result.json();
            console.log(this.persons);
        });
    }

    Delete(id: number) {
        this.requestService.delete('persons/' + id).subscribe((resp: any) => {
            this.persons = this.persons.filter(x => x.Id !== id);
        });
    }
}