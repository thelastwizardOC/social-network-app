import { JwtHelperService } from '@auth0/angular-jwt';
import { UserService } from 'src/app/services/user.service';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { ISearchUser, IUser } from 'src/app/interface/user';

@Component({
  selector: 'app-user-info-card',
  templateUrl: './user-info-card.component.html',
  styleUrls: ['./user-info-card.component.scss']
})
export class UserInfoCardComponent implements OnInit {
  @Input() user!: ISearchUser;
  @Output() onNavigateMessage = new EventEmitter<IUser>();
  loggedInUserId!: number;
  isLoading: boolean = false;
  constructor(private route: Router, private UserService: UserService, private jwtHelper: JwtHelperService) {}

  ngOnInit(): void {
    this.loggedInUserId = +this.jwtHelper.decodeToken(localStorage.getItem('jwt') as string).sub;
  }

  handleOnButtonPress() {
    if (this.user.relationship === 0) {
      this.route.navigate(['profile/' + this.user.id]);
    }
    if (this.user.relationship === 1) {
      this.onNavigateMessage.emit(this.user as IUser);
    } else {
      this.isLoading = true;
      this.UserService.addFriendRequest(this.loggedInUserId, this.user.id).subscribe({
        next: res => {
          this.user.relationship = 3;
        },
        error: err => {},
        complete: () => {
          this.isLoading = false;
        }
      });
    }
  }
}
