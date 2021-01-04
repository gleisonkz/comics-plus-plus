export interface DecodedToken {
  uniqueName: string;
  userID: string;
  customerID: string;
  role: string;
  nbf: number;
  exp: number;
  iat: number;
}
