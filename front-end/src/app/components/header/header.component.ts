import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Role } from 'src/app/enums/role.enum';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { AuthenticationService } from '../../modules/authentication/services/authentication.service';

@Component({
  selector: 'cms-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Output() openSide = new EventEmitter<boolean>(false);

  get isAdmin() {
    return (
      this.authorizationService.getUserRoles() &&
      this.authorizationService.getUserRoles().includes(Role.Admin)
    );
  }

  get isLoggedIn(): boolean {
    return this.authorizationService.isLoggedIn();
  }

  constructor(
    private authorizationService: AuthorizationService,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit(): void {}

  logout(): void {
    this.authenticationService.logout();
  }
}
