"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
const core_1 = require("@angular/core");
const platform_browser_1 = require("@angular/platform-browser");
const forms_1 = require("@angular/forms");
const app_component_1 = require("./app.component");
const http_1 = require("@angular/http");
const router_1 = require("@angular/router");
const ngx_dropdown_1 = require("ngx-dropdown");
require("rxjs/Rx");
const admins_component_1 = require("./components/administrator/admins.component");
const adminRegister_component_1 = require("./components/administrator/adminRegister.component");
const adminInfo_component_1 = require("./components/administrator/adminInfo.component");
const adminHome_component_1 = require("./components/administrator/adminHome.component");
const cities_component_1 = require("./components/city/cities.component");
const cityDetails_component_1 = require("./components/city/cityDetails.component");
const cityWhichIVisited_component_1 = require("./components/cityWhichIVisited/cityWhichIVisited.component");
const cityWhichIVisitedAdd_component_1 = require("./components/cityWhichIVisited/cityWhichIVisitedAdd.component");
const cityWhichIVisitedDetails_component_1 = require("./components/cityWhichIVisited/cityWhichIVisitedDetails.component");
const citiesWhichIWant_component_1 = require("./components/cityWhichIWantToVisit/citiesWhichIWant.component");
const cityWhichIWantAdd_component_1 = require("./components/cityWhichIWantToVisit/cityWhichIWantAdd.component");
const cityWhichIWantDetails_component_1 = require("./components/cityWhichIWantToVisit/cityWhichIWantDetails.component");
const comment_component_1 = require("./components/comment/comment.component");
const commentAdd_component_1 = require("./components/comment/commentAdd.component");
const home_component_1 = require("./components/home/home.component");
const login_component_1 = require("./components/login/login.component");
const persons_component_1 = require("./components/person/persons.component");
const personDetails_component_1 = require("./components/person/personDetails.component");
const personHome_component_1 = require("./components/person/personHome.component");
const personInfo_component_1 = require("./components/person/personInfo.component");
const personRegister_component_1 = require("./components/person/personRegister.component");
const photo_component_1 = require("./components/photo/photo.component");
const photoAdd_component_1 = require("./components/photo/photoAdd.component");
const register_component_1 = require("./components/register/register.component");
const LoggedInGuard_1 = require("./shared/LoggedInGuard");
const LoggedInGuardAdmin_1 = require("./shared/LoggedInGuardAdmin");
const LoggedInGuardPerson_1 = require("./shared/LoggedInGuardPerson");
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        bootstrap: [app_component_1.AppComponent],
        providers: [LoggedInGuardAdmin_1.LoggedInGuardAdmin, LoggedInGuardPerson_1.LoggedInGuardPerson, LoggedInGuard_1.LoggedInGuard],
        declarations: [
            app_component_1.AppComponent,
            home_component_1.HomeComponent,
            admins_component_1.AdministratorsComponent, adminRegister_component_1.AdminRegisterComponent, adminInfo_component_1.AdminInfoComponent, adminHome_component_1.AdminHomeComponent,
            cities_component_1.CityComponent, cityDetails_component_1.CityDetailsComponent,
            cityWhichIVisited_component_1.CityWhichIVisitedComponent, cityWhichIVisitedAdd_component_1.CityWhichIVisitedAddComponent, cityWhichIVisitedDetails_component_1.CityWhichIVisitedDetailsComponent,
            citiesWhichIWant_component_1.CityWhichIWantComponents, cityWhichIWantAdd_component_1.CityWhichIWantAddComponent, cityWhichIWantDetails_component_1.CityWhichIWantDetailsComponent,
            comment_component_1.CommentComponent, commentAdd_component_1.CommentAddComponent,
            login_component_1.LoginComponent, register_component_1.RegisterComponent,
            persons_component_1.PersonsComponent, personHome_component_1.PersonHomeComponent, personRegister_component_1.PersonRegisterComponent, personInfo_component_1.PersonInfoComponent, personDetails_component_1.PersonDetailsComponent,
            photo_component_1.PhotoComponent, photoAdd_component_1.PhotoAddComponent
        ],
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            http_1.JsonpModule,
            ngx_dropdown_1.DropdownModule,
            router_1.RouterModule.forRoot([
                { path: '', redirectTo: 'home', pathMatch: 'full' },
                { path: 'home', component: home_component_1.HomeComponent },
                {
                    path: 'admin-home', component: adminHome_component_1.AdminHomeComponent,
                    children: [
                        { path: '', redirectTo: 'info', pathMatch: 'full' },
                        { path: 'info', component: adminInfo_component_1.AdminInfoComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'administrators', component: admins_component_1.AdministratorsComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'addAdmin', component: adminRegister_component_1.AdminRegisterComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'persons', component: persons_component_1.PersonsComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'person-details/:id', component: personDetails_component_1.PersonDetailsComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'cities', component: cities_component_1.CityComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'city-details/:id', component: cityDetails_component_1.CityDetailsComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'citieswhichivisited', component: cityWhichIVisited_component_1.CityWhichIVisitedComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'addcitywhichivisited', component: cityWhichIVisitedAdd_component_1.CityWhichIVisitedAddComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'citieswhichiwant', component: citiesWhichIWant_component_1.CityWhichIWantComponents, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'addcitywhichiwant', component: cityWhichIWantAdd_component_1.CityWhichIWantAddComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'photos', component: photo_component_1.PhotoComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'addphoto', component: photoAdd_component_1.PhotoAddComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'comments', component: comment_component_1.CommentComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: 'addcomment', component: commentAdd_component_1.CommentAddComponent, canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] },
                        { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardAdmin_1.LoggedInGuardAdmin] }
                    ]
                },
                {
                    path: 'person-home', component: personHome_component_1.PersonHomeComponent,
                    children: [
                        { path: '', redirectTo: 'info', pathMatch: 'full' },
                        { path: 'info', component: personInfo_component_1.PersonInfoComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'person-details/:id', component: personDetails_component_1.PersonDetailsComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'cities', component: cities_component_1.CityComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'city-details/:id', component: cityDetails_component_1.CityDetailsComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'citieswhichivisited', component: cityWhichIVisited_component_1.CityWhichIVisitedComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'addcitywhichivisited', component: cityWhichIVisitedAdd_component_1.CityWhichIVisitedAddComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'citieswhichiwant', component: citiesWhichIWant_component_1.CityWhichIWantComponents, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'addcitywhichiwant', component: cityWhichIWantAdd_component_1.CityWhichIWantAddComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'photos', component: photo_component_1.PhotoComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'addphoto', component: photoAdd_component_1.PhotoAddComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'comments', component: comment_component_1.CommentComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: 'addcomment', component: commentAdd_component_1.CommentAddComponent, canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] },
                        { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardPerson_1.LoggedInGuardPerson] }
                    ]
                },
                { path: 'login', component: login_component_1.LoginComponent, canActivate: [LoggedInGuard_1.LoggedInGuard] },
                { path: 'register', component: register_component_1.RegisterComponent, canActivate: [LoggedInGuard_1.LoggedInGuard] },
                { path: 'home', component: home_component_1.HomeComponent, canActivate: [LoggedInGuard_1.LoggedInGuard] }
            ], { useHash: true })
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map