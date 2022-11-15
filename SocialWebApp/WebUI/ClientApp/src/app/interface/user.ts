export interface IUser {
  id: number;
  firstName: string;
  lastName: string;
  userName: string;
  dob: string;
  email: string;
  avatar: string;
  cover: string;
  gender: number;
  phoneNo: string;
}
export enum Gender {
  male,
  female,
  other,
}
