import { AbpModule } from '@abp/abp.module';
import { CommonModule } from '@angular/common';
import { HttpClientJsonpModule, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AboutComponent } from '@app/about/about.component';
import { HomeComponent } from '@app/home/home.component';
import { RightSideBarComponent } from '@app/layout/right-sidebar.component';
import { SideBarFooterComponent } from '@app/layout/sidebar-footer.component';
import { SideBarNavComponent } from '@app/layout/sidebar-nav.component';
import { SideBarUserAreaComponent } from '@app/layout/sidebar-user-area.component';
import { TopBarLanguageSwitchComponent } from '@app/layout/topbar-languageswitch.component';
import { TopBarComponent } from '@app/layout/topbar.component';
// roles
import { RolesComponent } from '@app/roles/roles.component';
// tenants
import { TenantsComponent } from '@app/tenants/tenants.component';
import { CreateUserDialogComponent } from '@app/users/create-user/create-user-dialog.component';
import { EditUserDialogComponent } from '@app/users/edit-user/edit-user-dialog.component';
// users
import { UsersComponent } from '@app/users/users.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { ModalModule } from 'ngx-bootstrap';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CreateRoleDialogComponent } from './roles/create-role/create-role-dialog.component';
import { EditRoleDialogComponent } from './roles/edit-role/edit-role-dialog.component';
import { CreateTenantDialogComponent } from './tenants/create-tenant/create-tenant-dialog.component';
import { EditTenantDialogComponent } from './tenants/edit-tenant/edit-tenant-dialog.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { ResetPasswordDialogComponent } from './users/reset-password/reset-password.component';
// companies
import { CompaniesComponent } from './companies/companies.component';
import { CreateCompanyDialogComponent } from './companies/create-company/create-company-dialog.component';
import { EditCompanyDialogComponent } from './companies/edit-company/edit-company-dialog.component';
// projects
import { ProjectsComponent } from './projects/projects.component';
import { CreateProjectDialogComponent } from './projects/create-project/create-project-dialog.component';
import { EditProjectDialogComponent } from './projects/edit-project/edit-project-dialog.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        AboutComponent,
        TopBarComponent,
        TopBarLanguageSwitchComponent,
        SideBarUserAreaComponent,
        SideBarNavComponent,
        SideBarFooterComponent,
        RightSideBarComponent,
        // tenants
        TenantsComponent,
        CreateTenantDialogComponent,
        EditTenantDialogComponent,
        // roles
        RolesComponent,
        CreateRoleDialogComponent,
        EditRoleDialogComponent,
        // users
        UsersComponent,
        CreateUserDialogComponent,
        EditUserDialogComponent,
        ChangePasswordComponent,
        ResetPasswordDialogComponent,
        // companies
        CompaniesComponent,
        CreateCompanyDialogComponent,
        EditCompanyDialogComponent,
        // projects
        ProjectsComponent,
        CreateProjectDialogComponent,
        EditProjectDialogComponent,
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        ModalModule.forRoot(),
        AbpModule,
        AppRoutingModule,
        ServiceProxyModule,
        SharedModule,
        NgxPaginationModule
    ],
    providers: [],
    entryComponents: [
        // tenants
        CreateTenantDialogComponent,
        EditTenantDialogComponent,
        // roles
        CreateRoleDialogComponent,
        EditRoleDialogComponent,
        // users
        CreateUserDialogComponent,
        EditUserDialogComponent,
        ResetPasswordDialogComponent,
        // companies
        CreateCompanyDialogComponent,
        EditCompanyDialogComponent,
        // projects
        CreateProjectDialogComponent,
        EditProjectDialogComponent
    ]
})
export class AppModule { }
