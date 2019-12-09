import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { CompanyDto, CompanyServiceProxy, PagedResultDtoOfCompanyDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';
import { PagedListingComponentBase, PagedRequestDto } from 'shared/paged-listing-component-base';
import { CreateCompanyDialogComponent } from './create-company/create-company-dialog.component';
import { EditCompanyDialogComponent } from './edit-company/edit-company-dialog.component';

class PagedTityoRequestDto extends PagedRequestDto {
    keyword: string;
}

@Component({
    templateUrl: './companies.component.html',
    animations: [appModuleAnimation()],
    styles: [
        `
          mat-form-field {
            padding: 10px;
          }
        `
    ]
})
export class CompaniesComponent extends PagedListingComponentBase<CompanyDto> {
    companies: CompanyDto[] = [];
    keyword = '';

    constructor(
        injector: Injector,
        private _companyService: CompanyServiceProxy,
        private _dialog: MatDialog
    ) {
        super(injector);
    }

    createCompany(): void {
        this.showCreateOrEditCompanyDialog();
    }

    editCompany(company: CompanyDto): void {
        this.showCreateOrEditCompanyDialog(company.id);
    }

    protected list(
        request: PagedTityoRequestDto,
        pageNumber: number,
        finishedCallback: Function
    ): void {

        request.keyword = this.keyword;

        this._companyService
            .getAllWithAddress(request.keyword, request.skipCount, request.maxResultCount)
            .pipe(
                finalize(() => {
                    finishedCallback();
                })
            )
            .subscribe((result: PagedResultDtoOfCompanyDto) => {
                this.companies = result.items;
                this.showPaging(result, pageNumber);
            });
    }

    protected delete(company: CompanyDto): void {
        abp.message.confirm(
            this.l('CompanyDeleteWarningMessage', company.name),
            (result: boolean) => {
                if (result) {
                    this._companyService.delete(company.id).subscribe(() => {
                        abp.notify.success(this.l('SuccessfullyDeleted'));
                        this.refresh();
                    });
                }
            }
        );
    }

    private showCreateOrEditCompanyDialog(id?: number): void {
        let createOrEditCompanyDialog;
        if (id === undefined || id <= 0) {
            createOrEditCompanyDialog = this._dialog.open(CreateCompanyDialogComponent);
        } else {
            createOrEditCompanyDialog = this._dialog.open(EditCompanyDialogComponent, {
                data: id
            });
        }

        createOrEditCompanyDialog.afterClosed().subscribe(result => {
            if (result) {
                this.refresh();
            }
        });
    }
}