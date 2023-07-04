import { UserType } from "./user-type";

export interface UserInformationDto {
    id: string;
    firstName: string;
    lastName: string;
    userType: UserType;
    countryId: string;
    countryDto: string;
}