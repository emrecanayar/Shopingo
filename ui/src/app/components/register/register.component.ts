import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { RegisterService } from 'src/app/services/register/register.service';
import { Router, RouterModule } from '@angular/router';
import { LoadingComponent } from '../loading/loading.component';
import { UserForRegisterDto } from 'src/app/models/register/user-for-register-dto';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { CountryListModel } from 'src/app/models/country/country-list-model';
import { CountryService } from 'src/app/services/country/country.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    ToastrModule,
    LoadingComponent,
    FormsModule,
  ],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  isLoaded = true;
  countries: CustomResponseDto<CountryListModel>;
  selectedCountry: 'Türkiye';

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private registerService: RegisterService,
    private contryService: CountryService,
    private router: Router
  ) {}

  private initializeForm(): void {
    this.registerForm = this.formBuilder.group({
      firstName: [null, Validators.required],
      lastName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
      countryId: [null, Validators.required],
    });
  }

  async ngOnInit() {
    this.initializeForm();
  }

  async loadCountries() {
    try {
      this.isLoaded = false;
      this.countries = await this.contryService.getList(0, 1000);
      this.isLoaded = true;
    } catch (error) {}
  }

  onSubmit(): void {
    if (!this.registerForm.valid) {
      return;
    }

    this.isLoaded = false;
    const registerFormData: UserForRegisterDto = this.registerForm.value;
    registerFormData.userName = `${registerFormData.firstName.toLocaleLowerCase()} ${registerFormData.lastName.toLocaleLowerCase()}`;

    this.registerService
      .register(registerFormData)
      .then((response) => {
        this.isLoaded = true;
        this.registerForm.reset();
        this.toastr.success('Your membership has been successfully created.');
        this.router.navigate(['sign-in']);
      })
      .catch((error) => {
        this.isLoaded = true;
        this.toastr.error(error.error.detail);
      });
  }
}
