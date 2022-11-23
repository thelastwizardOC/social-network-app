export interface IUser {
  id?: number;
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
