import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { ContactUsService } from 'src/app/services/contact-us/contact-us.service';
import { ContactUsCreateDto } from 'src/app/models/contact-us/contact-us-create.dto';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { LoadingComponent } from '../loading/loading.component';
import { CompanyAddressService } from 'src/app/services/company-address/company-address.service';
import { CompanyAddressListModel } from 'src/app/models/company-address/company-address-list-model';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';

@Component({
  selector: 'app-contact-us',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    ToastrModule,
    LoadingComponent,
  ],
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.css'],
})
export class ContactUsComponent implements OnInit {
  contactForm: FormGroup;
  isLoaded = true;
  companyAddresses: CustomResponseDto<CompanyAddressListModel>;

  constructor(
    private formBuilder: FormBuilder,
    private contactUsService: ContactUsService,
    private toastr: ToastrService,
    private companyAddressService: CompanyAddressService
  ) {}

  async ngOnInit() {
    this.initializeForm();
    this.companyAddresses = await this.companyAddressService.getCompanyAddresses();
  }

  private initializeForm(): void {
    this.contactForm = this.formBuilder.group({
      fullName: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      phoneNumber: [null, Validators.required],
      message: [null, Validators.required],
    });
  }

  onSubmit(): void {
    if (!this.contactForm.valid) {
      return;
    }
    this.isLoaded = false;
    const formData: ContactUsCreateDto = this.contactForm.value;

    this.contactUsService
      .create(formData)
      .then((response) => {
        console.log('Form successfully submitted', response);
        this.isLoaded = true;
        this.toastr.success('Form submitted successfully!');
        this.contactForm.reset();
      })
      .catch((error) => {
        console.error('Error submitting form', error);
        this.isLoaded = true;
        this.toastr.error('An error occurred while submitting the form.');
      });
  }
}
