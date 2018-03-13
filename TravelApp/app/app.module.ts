import { NgModule, Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule, JsonpModule } from '@angular/http';
import { RouterModule, Routes, Route, Router } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { DropdownModule } from "ngx-dropdown";
import 'rxjs/Rx';
import { AdministratorsComponent } from './components/administrator/admins.component';
import { AdminRegisterComponent } from './components/administrator/adminRegister.component';
import { AdminInfoComponent } from './components/administrator/adminInfo.component';
import { AdminHomeComponent } from './components/administrator/adminHome.component';
import { CityComponent } from './components/city/cities.component';
import { CityDetailsComponent } from './components/city/cityDetails.component';
import { CityWhichIVisitedComponent } from './components/cityWhichIVisited/cityWhichIVisited.component';
import { CityWhichIVisitedAddComponent } from './components/cityWhichIVisited/cityWhichIVisitedAdd.component';
import { CityWhichIVisitedDetailsComponent } from './components/cityWhichIVisited/cityWhichIVisitedDetails.component';
import { CityWhichIWantComponents } from './components/cityWhichIWantToVisit/citiesWhichIWant.component';
import { CityWhichIWantAddComponent } from './components/cityWhichIWantToVisit/cityWhichIWantAdd.component';
import { CityWhichIWantDetailsComponent } from './components/cityWhichIWantToVisit/cityWhichIWantDetails.component';
import { CommentComponent } from './components/comment/comment.component';
import { CommentAddComponent } from './components/comment/commentAdd.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { PersonsComponent } from './components/person/persons.component';
import { PersonDetailsComponent } from './components/person/personDetails.component';
import { PersonHomeComponent } from './components/person/personHome.component';
import { PersonInfoComponent } from './components/person/personInfo.component';
import { PersonRegisterComponent } from './components/person/personRegister.component';
import { PhotoComponent } from './components/photo/photo.component';
import { PhotoAddComponent } from './components/photo/photoAdd.component';
import { RegisterComponent } from './components/register/register.component';
import { LoggedInGuard } from './shared/LoggedInGuard';
import { LoggedInGuardAdmin } from './shared/LoggedInGuardAdmin';
import { LoggedInGuardPerson } from './shared/LoggedInGuardPerson';

@NgModule({
    bootstrap: [AppComponent],
    providers: [LoggedInGuardAdmin, LoggedInGuardPerson, LoggedInGuard],
    declarations: [
        AppComponent,
        HomeComponent,
        AdministratorsComponent, AdminRegisterComponent, AdminInfoComponent, AdminHomeComponent,
        CityComponent, CityDetailsComponent,
        CityWhichIVisitedComponent, CityWhichIVisitedAddComponent, CityWhichIVisitedDetailsComponent,
        CityWhichIWantComponents, CityWhichIWantAddComponent, CityWhichIWantDetailsComponent,
        CommentComponent, CommentAddComponent,
        LoginComponent, RegisterComponent,
        PersonsComponent, PersonHomeComponent, PersonRegisterComponent, PersonInfoComponent, PersonDetailsComponent,
        PhotoComponent, PhotoAddComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        DropdownModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            {
                path: 'admin-home', component: AdminHomeComponent,
                children: [
                    { path: '', redirectTo: 'info', pathMatch: 'full' },
                    { path: 'info', component: AdminInfoComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'administrators', component: AdministratorsComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'addAdmin', component: AdminRegisterComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'persons', component: PersonsComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'person-details/:id', component: PersonDetailsComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'cities', component: CityComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'city-details/:id', component: CityDetailsComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'citieswhichivisited', component: CityWhichIVisitedComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'addcitywhichivisited', component: CityWhichIVisitedAddComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'citieswhichiwant', component: CityWhichIWantComponents, canActivate: [LoggedInGuardAdmin] },
                    { path: 'addcitywhichiwant', component: CityWhichIWantAddComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'photos', component: PhotoComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'addphoto', component: PhotoAddComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'comments', component: CommentComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: 'addcomment', component: CommentAddComponent, canActivate: [LoggedInGuardAdmin] },
                    { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardAdmin] }
                ]
            },
            {
                path: 'person-home', component: PersonHomeComponent,
                children: [
                    { path: '', redirectTo: 'info', pathMatch: 'full' },
                    { path: 'info', component: PersonInfoComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'person-details/:id', component: PersonDetailsComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'cities', component: CityComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'city-details/:id', component: CityDetailsComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'citieswhichivisited', component: CityWhichIVisitedComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'addcitywhichivisited', component: CityWhichIVisitedAddComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'citieswhichiwant', component: CityWhichIWantComponents, canActivate: [LoggedInGuardPerson] },
                    { path: 'addcitywhichiwant', component: CityWhichIWantAddComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'photos', component: PhotoComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'addphoto', component: PhotoAddComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'comments', component: CommentComponent, canActivate: [LoggedInGuardPerson] },
                    { path: 'addcomment', component: CommentAddComponent, canActivate: [LoggedInGuardPerson] },
                    { path: '**', redirectTo: '', pathMatch: 'full', canActivate: [LoggedInGuardPerson] }
                ]
            },
            { path: 'login', component: LoginComponent, canActivate: [LoggedInGuard] },
            { path: 'register', component: RegisterComponent, canActivate:[LoggedInGuard] },
            { path: 'home', component: HomeComponent, canActivate:[LoggedInGuard] }
        ], { useHash: true })]
})
export class AppModule {

}