export interface IUser {
  id: number;
  firstName: string;
  lastName: string;
  userName: string;
  dob: string;
  email: string;
  avatar?: string;
  cover?: string;
  gender: number;
  phoneNo: string;
  createdAt?: string;
  updatedAt?: string;
  token?: string;
}
export interface IUserHub {
  Avatar: string;
  Cover: string;
  CreatedAt: string;
  Dob: string;
  Email: string;
  FirstName: string;
  Gender: number;
  Id: number;
  LastName: string;
  PhoneNo: string;
  UpdatedAt: string;
  UserName: string;
}

export enum Gender {
  MALE,
  FEMALE,
  OTHER
}

export interface ISearchUser {
  id?: number;
  firstName: string;
  lastName: string;
  userName: string;
  avatar: string;
  relationship: number;
}

export interface ISearchUserResponse {
  users: ISearchUser[];
  totalCount: number;
  hasNextPage: boolean;
}
