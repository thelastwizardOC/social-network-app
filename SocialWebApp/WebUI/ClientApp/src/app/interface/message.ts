import { IUser } from './user';

export interface IMessage {
  id: number;
  message: string;
  photo?: string;
  createdAt: Date;
  isRead: boolean;
  sender: IUser;
  receiver: IUser;
}
export enum MessageType {
  send,
  receive
}
