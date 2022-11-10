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
  createdAt: Date;
  updatedAt: Date;
}
export enum Gender {
  male,
  female,
}
