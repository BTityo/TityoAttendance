import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { AppComponentBase } from '@shared/app-component-base';
import { AddressServiceProxy, CityDto, CompanyServiceProxy, CountryDto, CountyDto, CreateAddressDto, CreateCompanyDto, NatureOfPublicPlaceDto } from '@shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
    templateUrl: './create-company-dialog.component.html',
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
export class CreateCompanyDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    company: CreateCompanyDto = new CreateCompanyDto();
    address: CreateAddressDto = new CreateAddressDto();

    countries: CountryDto[] = [];
    counties: CountyDto[] = [];
    cities: CityDto[] = [];
    natureOfPublicPlaces: NatureOfPublicPlaceDto[] = [];

    selectedCountry: CountryDto;
    selectedCounty: CountyDto;
    selectedNatureOfPublicPlace: NatureOfPublicPlaceDto;
    selectedCity: CityDto;
    zipCode: number;

    constructor(
        injector: Injector,
        public _addressService: AddressServiceProxy,
        public _companyService: CompanyServiceProxy,
        private _dialogRef: MatDialogRef<CreateCompanyDialogComponent>
    ) {
        super(injector);
    }

    ngOnInit(): void {


        this._addressService.getCountries().subscribe(result => {
            this.countries = result.items;
            this.address.countryId = result.items[0].id;

            this._addressService.getCounties(this.countries[0].countryCode).subscribe(result => {
                this.counties = result.items;
                this.address.countyId = result.items[0].id;

                this._addressService.getCities(this.counties[0].countyCode).subscribe(result => {
                    this.cities = result.items;
                    this.address.cityId = result.items[0].id;
                });
            });
        });

        this._addressService.getNatureOfPublicPlaces().subscribe(result => {
            this.natureOfPublicPlaces = result.items;
            this.address.natureOfPublicPlaceId = result.items[0].id;
        });
    }

    selectChanged(value) {

        if (value instanceof CountryDto) {

            this.selectedCountry = value;
            this.address.countryId = value.id;

        } else if (value instanceof CountyDto) {

            this.selectedCounty = value;
            this.address.countyId = value.id;

            this._addressService.getCities(value.countyCode).subscribe(result => {
                this.cities = result.items;
            });

        } else if (value instanceof CityDto) {

            this.zipCode = value.zipCode;
            this.selectedCity = value;
            this.address.cityId = value.id;

        } else if (value instanceof NatureOfPublicPlaceDto) {

            this.selectedNatureOfPublicPlace = value;
            this.address.natureOfPublicPlaceId = value.id;
        }
    }

    save(): void {
        this.saving = true;

        this._addressService
            .create(this.address)
            .pipe(
                finalize(() => {
                    this.saving = false;
                })
            )
            .subscribe((data) => {
                if (data !== null && data !== undefined) {
                    this.company.addressId = data.id;
                    this._companyService
                        .create(this.company)
                        .pipe(
                            finalize(() => {
                                this.saving = false;
                            })
                        )
                        .subscribe((data) => {
                            this.notify.info(this.l('SavedSuccessfully'));
                            this.close(true);
                        });
                }
            });
    }

    close(result: any): void {
        this._dialogRef.close(result);
    }
}
