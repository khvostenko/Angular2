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
const authentication_service_1 = require("../../shared/authentication.service");
const router_1 = require("@angular/router");
let CommentByCityComponent = class CommentByCityComponent {
    constructor(router, rs, authService, activateRoute) {
        this.router = router;
        this.rs = rs;
        this.authService = authService;
        this.activateRoute = activateRoute;
        this.id = activateRoute.snapshot.params['cityId'];
        this.rs.get('commentsbycity/' + this.id).subscribe(result => {
            this.coments = result.json();
        });
    }
};
CommentByCityComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'commentByCity.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router, request_service_1.RequestService, authentication_service_1.AuthenticationService, router_1.ActivatedRoute])
], CommentByCityComponent);
exports.CommentByCityComponent = CommentByCityComponent;
//# sourceMappingURL=commentByCity.component.js.map