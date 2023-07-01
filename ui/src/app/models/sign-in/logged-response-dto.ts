import { AccessToken } from "./access-token";
import { AuthenticatorType } from "./authenticator-type";
import { LoggedRefreshTokenDto } from "./logged-refresh-token-dto";

export interface LoggedResponseDto {
    accessToken: AccessToken | null;
    refreshToken: LoggedRefreshTokenDto | null;
    requiredAuthenticatorType: AuthenticatorType | null;
}