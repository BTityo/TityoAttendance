import { ChangeDetectionStrategy, Component, Inject, Injector, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { CreateProjectDto, ProjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { ColorPickerService } from 'ngx-color-picker';
import { finalize } from 'rxjs/operators';

@Component({
    templateUrl: './create-project-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ],
    preserveWhitespaces: false,
    changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateProjectDialogComponent extends AppComponentBase
    implements OnInit {

    saving = false;
    project: CreateProjectDto = new CreateProjectDto();
    //'#e920e9'

    constructor(
        injector: Injector,
        public _projectService: ProjectServiceProxy,
        private _colorPickerService: ColorPickerService,
        private _dialogRef: MatDialogRef<CreateProjectDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _companyId: number
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this.project.companyId = this._companyId;
        this.project.color = '#e920e9';
    }

    save(): void {

        this.saving = true;

        // If color is not exists then we save project, because every project has created with another color
        if (!this.checkColorIsExists()) {
            this._projectService
                .create(this.project)
                .pipe(
                    finalize(() => {
                        this.saving = false;
                    })
                )
                .subscribe((data) => {
                    if (data !== null && data !== undefined) {
                        this.notify.info(this.l('SavedSuccessfully'));
                        this.close(true);
                    }
                });
        } else {
            abp.message.warn(
                this.l('ColorError', this.project.color)
            );
        }
    }

    checkColorIsExists(): boolean {
        let isExistsColor: boolean = false;

        this._projectService
            .checkColorIsExists(this.project.color)
            .subscribe((data) => {
                if (data !== null && data !== undefined) {
                    isExistsColor = data;
                }
            });

        return isExistsColor;
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
