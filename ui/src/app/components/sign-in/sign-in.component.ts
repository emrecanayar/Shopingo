import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignInService } from 'src/app/services/sign-in/sign-in.service';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { LoadingComponent } from '../loading/loading.component';
import { LoginDto } from 'src/app/models/sign-in/login';

@Component({
  selector: 'app-sign-in',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    ToastrModule,
    LoadingComponent,
  ],
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css'],
})
export class SignInComponent implements OnInit {
  signInForm: FormGroup;
  isLoaded = true;

  constructor(
    private formBuilder: FormBuilder,
    private signInService: SignInService,
    private toastr: ToastrService,
    private router: Router
  ) {}

  private initializeForm(): void {
    this.signInForm = this.formBuilder.group({
      userName: [null, [Validators.required, Validators.email]],
      password: [null, Validators.required],
    });
  }

  async ngOnInit() {
    this.initializeForm();
  }

  onSubmit(): void {
    if (!this.signInForm.valid) {
      return;
    }

    this.isLoaded = false;
    const signInFormData: LoginDto = this.signInForm.value;

    this.signInService
      .login(signInFormData)
      .then((response) => {
        this.isLoaded = true;
        this.signInForm.reset();

        localStorage.setItem('accessToken', response.data.accessToken.token);
        this.router.navigate(['/']);
      })
      .catch((error) => {
        this.isLoaded = true;
        this.toastr.error('An error occurred while submitting the form.');
      });
  }
}
