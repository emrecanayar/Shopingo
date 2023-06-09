import { AccessToken } from './access-token';
import { RefreshToken } from './refresh-token';

export interface LoggedDto {
  accessToken: AccessToken;
  refreshToken: RefreshToken;
}
