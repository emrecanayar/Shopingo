export interface ContactUsCreateDto {
  fullName: string;
  email: string;
  phoneNumber: string;
  message: string;
  userId?: string;
}
