import { UserType } from './user-type';

export interface UserDto {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  userName: string;
  registrationNumber: string;
  userType: UserType;
  countryId: string;
  countryDto: string;
}
