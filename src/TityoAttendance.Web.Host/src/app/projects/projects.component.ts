import { Component, Injector, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PagedResultDtoOfProjectDto, ProjectDto, ProjectServiceProxy, CompanyDto, CompanyServiceProxy } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { CreateProjectDialogComponent } from './create-project/create-project-dialog.component';
import { EditProjectDialogComponent } from './edit-project/edit-project-dialog.component';

class PagedTityoRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './projects.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class ProjectsComponent extends PagedListingComponentBase<ProjectDto> implements OnInit {
    projects: ProjectDto[] = [];
    companies: CompanyDto[] = [];
    selectedCompany: CompanyDto;
    keyword = '';

    constructor(
        injector: Injector,
        private _projectService: ProjectServiceProxy,
        private _companyService: CompanyServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._companyService.getAllByUser().subscribe(result => {
            this.companies = result;
        });
    }

    selectChanged(value) {
        this.selectedCompany = value;
    }


    createProject(): void {
        if (this.selectedCompany !== undefined) {
            this.showCreateOrEditProjectDialog();
        } else {
            abp.message.warn(
                this.l('NoSelectedCompany')
            );
        }
    }

    editProject(project: ProjectDto): void {
        this.showCreateOrEditProjectDialog(project.id);
    }

    protected list(
        request: PagedTityoRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;

        this._projectService
            .getAll(request.keyword, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfProjectDto) => {
                this.projects = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(project: ProjectDto): void {
        abp.message.confirm(
            this.l('ProjectDeleteWarningMessage', project.name),
            (result: boolean) => {
                if (result) {
                    this._projectService.delete(project.id).subscribe(() => {
                        abp.notify.success(this.l('SuccessfullyDeleted'));
                        this.refresh();
                    });
                }
            }
        );
    }

    private showCreateOrEditProjectDialog(id?: number): void {
        let createOrEditProjectDialog;
        if (id === undefined || id <= 0) {
            createOrEditProjectDialog = this._dialog.open(CreateProjectDialogComponent, {
                data: this.selectedCompany.id
            });
        } else {
            createOrEditProjectDialog = this._dialog.open(EditProjectDialogComponent, {
                data: id
            });
        }

        createOrEditProjectDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}