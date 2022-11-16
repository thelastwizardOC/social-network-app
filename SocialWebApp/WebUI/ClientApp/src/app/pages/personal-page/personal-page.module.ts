import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { TuiButtonModule, TuiLoaderModule, TuiSvgModule } from '@taiga-ui/core';
import { TuiAvatarModule, TuiInputFilesModule, TuiTabsModule } from '@taiga-ui/kit';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { PostModule } from 'src/app/components/post/post.module';
import { GenderPipe } from 'src/app/pipes/gender.pipe';
import { InfoItemComponent } from './components/info-item/info-item.component';
import { PersonalContainerComponent } from './personal-container/personal-container.component';
import { PersonalPageRoute } from './personal-page.route';
import { PersonalComponent } from './personal/personal.component';
import { UploadImageDialogComponent } from './components/upload-image-dialog/upload-image-dialog.component';

@NgModule({
  declarations: [
    PersonalComponent,
    PersonalContainerComponent,
    InfoItemComponent,
    GenderPipe,
    UploadImageDialogComponent,
  ],
  imports: [
    CommonModule,
    PersonalPageRoute,
    TuiTabsModule,
    TuiAvatarModule,
    TuiButtonModule,
    TuiSvgModule,
    InfiniteScrollModule,
    TuiLoaderModule,
    PostModule,
    TuiInputFilesModule,
    ReactiveFormsModule 
  ],
})
export class PersonalPageModule {}
