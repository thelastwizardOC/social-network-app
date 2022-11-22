import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MessagePageRoute } from './mesage-page.route';
import { MessageComponent } from './message/message.component';
import { MessageContainerComponent } from './message-container/message-container.component';
import { TuiAvatarModule } from '@taiga-ui/kit';
import { MessageContactComponent } from './components/message-contact/message-contact.component';
import { UserMessageComponent } from './components/user-message/user-message.component';
import { MessageInputComponent } from './components/message-input/message-input.component';
import { TuiSvgModule } from '@taiga-ui/core';

@NgModule({
  declarations: [MessageComponent, MessageContainerComponent, MessageContactComponent, UserMessageComponent, MessageInputComponent],
  imports: [CommonModule, MessagePageRoute, TuiAvatarModule, TuiSvgModule]
})
export class MessagePageModule {}
