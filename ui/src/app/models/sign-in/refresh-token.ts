export interface RefreshToken {
  userId: string;
  token: string;
  expires: string;
  created: string;
  createdByIp: string;
  revoked: string | null;
  revokedByIp: string | null;
  replacedByToken: string | null;
  reasonRevoked: string | null;
}
