import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { UserService } from 'src/app/services/user/user.service';
import { CustomResponseDto } from 'src/app/models/base/custom-response.dto';
import { UserInformationDto } from 'src/app/models/user/user-information.dto';

@Component({
  selector: 'app-account-dashboard',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './account-dashboard.component.html',
  styleUrls: ['./account-dashboard.component.css'],
})
export class AccountDashboardComponent implements OnInit {
  userInformation: CustomResponseDto<UserInformationDto>;

  constructor(private userService: UserService) {}

  async ngOnInit() {
    await this.getUserInformation();
  }

  async getUserInformation() {
    this.userInformation = await this.userService.getUserInformation();
  }

  logOut() {
    this.userService.logOut();
  }
}
