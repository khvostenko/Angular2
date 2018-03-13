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
const request_service_1 = require("../../shared/request.service");
const Person_1 = require("./Person");
const authentication_service_1 = require("../../shared/authentication.service");
let PersonInfoComponent = class PersonInfoComponent {
    constructor(rs, authService) {
        this.rs = rs;
        this.authService = authService;
        this.person = new Person_1.Person();
        let currentId = authService.currentUserId;
        this.rs.get('persons/' + currentId).subscribe((result) => {
            this.person = result.json();
        });
    }
};
PersonInfoComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'personInfo.component.html'
    }),
    __metadata("design:paramtypes", [request_service_1.RequestService,
        authentication_service_1.AuthenticationService])
], PersonInfoComponent);
exports.PersonInfoComponent = PersonInfoComponent;
//# sourceMappingURL=personInfo.component.js.map