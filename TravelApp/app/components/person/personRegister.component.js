"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const router_1 = require("@angular/router");
const authentication_service_1 = require("../../shared/authentication.service");
const request_service_1 = require("../../shared/request.service");
const PersonRegistration_1 = require("./PersonRegistration");
let PersonRegisterComponent = class PersonRegisterComponent {
    constructor(router, authService, activateRoute, rs) {
        this.router = router;
        this.authService = authService;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.model = new PersonRegistration_1.PersonRegistration();
        this.loading = false;
    }
    Register(model) {
        this.loading = true;
        this.authService.register(model).subscribe((response) => {
            let temp = response;
            this.loading = false;
            this.router.navigate(['login'], { relativeTo: this.activateRoute });
        }, (error) => {
            let temp = error;
            alert('Registration errror!');
        });
    }
};
PersonRegisterComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'personRegister.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router, authentication_service_1.AuthenticationService, router_1.ActivatedRoute, request_service_1.RequestService])
], PersonRegisterComponent);
exports.PersonRegisterComponent = PersonRegisterComponent;
//# sourceMappingURL=personRegister.component.js.map