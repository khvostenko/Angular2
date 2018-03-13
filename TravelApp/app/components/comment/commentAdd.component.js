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
const request_service_1 = require("../../shared/request.service");
const authentication_service_1 = require("../../shared/authentication.service");
const Comment_1 = require("./Comment");
let CommentAddComponent = class CommentAddComponent {
    constructor(router, activateRoute, rs, authService) {
        this.router = router;
        this.activateRoute = activateRoute;
        this.rs = rs;
        this.authService = authService;
        this.comment = new Comment_1.Comment();
        this.comment.PersonId = this.authService.currentUserId;
        this.comment.CityId = this.activateRoute.snapshot.params['cityId'];
    }
    Done() {
        this.rs.post('comments', this.comment).subscribe((response) => {
            this.comment = response.json();
            this.router.navigate(['../city-comment'], { relativeTo: this.activateRoute });
        });
    }
};
CommentAddComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'commentAdd.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router, router_1.ActivatedRoute, request_service_1.RequestService, authentication_service_1.AuthenticationService])
], CommentAddComponent);
exports.CommentAddComponent = CommentAddComponent;
//# sourceMappingURL=commentAdd.component.js.map