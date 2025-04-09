export interface Environment {
  production: boolean;

  // Google
  clientId: string;
  redirectUri: string;

  // JWT
  jwtToken: string;
  allowedDomains: string[];

  // API URLs
  authApiUrl: string;
  usersApiUrl: string;
}
