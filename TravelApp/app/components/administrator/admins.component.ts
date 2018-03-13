import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Administrator } from './Administrator';

@Component({
    moduleId: module.id,
    selector: 'administrators-details',
    templateUrl: 'admins.component.html'
})

export class AdministratorsComponent {
    public administrators: Administrator[];

    constructor(private rs: RequestService) {
        rs.get('administrators').subscribe((result: any) => {
            this.administrators = result.json();
            console.log(this.administrators);
        });
    }

    Delete(id: number) {
        this.rs.delete('administrators/' + id).subscribe((resp: any) => {
            this.administrators = this.administrators.filter(x => x.Id !== id);
        });
    }
}
