import { Component, Inject, Injector, OnInit, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { AddressDto, AddressServiceProxy, CityDto, CompanyDto, CompanyServiceProxy, CountryDto, CountyDto, NatureOfPublicPlaceDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
    templateUrl: './edit-company-dialog.component.html',
    styles: [
        `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
    ]
})
export class EditCompanyDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    company: CompanyDto = new CompanyDto();
    address: AddressDto = new AddressDto();

    countries: CountryDto[] = [];
    selectedCountry: CountryDto;
    counties: CountyDto[] = [];
    selectedCounty: CountyDto;
    cities: CityDto[] = [];
    selectedCity: CityDto;
    natureOfPublicPlaces: NatureOfPublicPlaceDto[] = [];
    selectedNatureOfPublicPlace: NatureOfPublicPlaceDto;

    constructor(
        injector: Injector,
        public _companyService: CompanyServiceProxy,
        public _addressService: AddressServiceProxy,
        private _dialogRef: MatDialogRef<EditCompanyDialogComponent>,
        @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
    ) {
        super(injector);
    }

    ngOnInit(): void {
        this._companyService.getCompanyDto(this._id).subscribe(result => {
            this.company = result;
        });

        this._addressService.getCountries().subscribe(result => {
            this.countries = result.items;
            this.selectedCountry = result.items.find(c => c.id == this.company.address.countryId);

            this._addressService.getCounties(this.selectedCountry.countryCode).subscribe(result => {
                this.counties = result.items;
                this.selectedCounty = result.items.find(c => c.id == this.company.address.countyId);

                this._addressService.getCities(this.selectedCounty.countyCode).subscribe(result => {
                    this.cities = result.items;
                    this.selectedCity = result.items.find(c => c.id == this.company.address.cityId);

                    this._addressService.getNatureOfPublicPlaces().subscribe(result => {
                        this.natureOfPublicPlaces = result.items;
                        this.selectedNatureOfPublicPlace = result.items.find(c => c.id == this.company.address.natureOfPublicPlaceId);
                    });
                });
            });
        });
    }

    selectChanged(value) {

        if (value instanceof CountryDto) {

            this.selectedCountry = value;
            this.company.address.countryId = value.id;
            this.company.address.country = value;

        } else if (value instanceof CountyDto) {

            this.selectedCounty = value;
            this.company.address.countyId = value.id;
            this.company.address.county = value;

            this._addressService.getCities(value.countyCode).subscribe(result => {
                this.cities = result.items;
                this.selectedCity = result.items[0];
                this.company.address.city.zipCode = result.items[0].zipCode;
            });

        } else if (value instanceof CityDto) {

            this.company.address.city.zipCode = value.zipCode;
            this.selectedCity = value;
            this.company.address.cityId = value.id;
            this.company.address.city = value;

        } else if (value instanceof NatureOfPublicPlaceDto) {

            this.selectedNatureOfPublicPlace = value;
            this.company.address.natureOfPublicPlaceId = value.id;
            this.company.address.natureOfPublicPlace = value;
        }
    }

    save(): void {
        this.saving = true;

        this._companyService
            .update(this.company)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close(true);
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
