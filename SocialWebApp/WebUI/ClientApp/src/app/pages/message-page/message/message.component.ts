import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { IMessage, MessageType } from 'src/app/interface/message';
import { IUser } from 'src/app/interface/user';

@Component({
  selector: 'app-message',
  templateUrl: './message.component.html',
  styleUrls: ['./message.component.scss']
})
export class MessageComponent implements OnChanges {
  @Input() listMessages: IMessage[] = [];
  @Input() friendsMessages: IMessage[] = [];
  @Input() userId!: number;
  @Input() chosenFriend: IUser | undefined;
  @Input() isLoading!: boolean;
  @Input() searchedFriends: IUser[] = [];
  @Output() onSend = new EventEmitter<string>();
  @Output() onContactClick = new EventEmitter<{ chosenUser: IUser | undefined; messageId: number | undefined }>();
  @Output() onSendPhoto = new EventEmitter<Event>();
  @Output() onSendDocument = new EventEmitter<Event>();
  @Output() onMessageScroll = new EventEmitter();
  @Output() onSearchFriend = new EventEmitter<string>();
  @Output() onClickSearchFriend = new EventEmitter<IUser>();
  @Output() onHideMessage = new EventEmitter<number>();

  keyword: string = '';
  messageType = MessageType;
  constructor() {}
  ngOnChanges(changes: SimpleChanges): void {
    // console.log({ changes });
  }
}
