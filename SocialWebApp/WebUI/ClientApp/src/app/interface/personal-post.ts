import { IUser } from './user';

export interface IPersonalPost {
  id: number;
  status: string;
  photo: string;
  numberOfLikes: number;
  numberOfComments: number;
  createdAt: Date;
  updatedAt: Date;
  user: IUser;
}
export interface IPersonalPostResponse {
  items: IPersonalPost[];
  totalCount: number;
  hasNextPage: boolean;
}
