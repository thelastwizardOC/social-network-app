import { IUser } from './user';

export interface IPost {
  id: number;
  status: string;
  photo: string;
  numberOfLikes: number;
  numberOfComments: number;
  createdAt: Date;
  updatedAt: Date;
  user: IUser;
}
export interface IPostResponse {
  items: IPost[];
  totalCount: number;
  hasNextPage: boolean;
}
