import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizationService } from 'src/app/services/authorization.service';
import { AuthenticationService } from '../../modules/authentication/services/authentication.service';

@Component({
  selector: 'cms-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  @Output() openSide = new EventEmitter<boolean>(false);
  @Output() openAdminSide = new EventEmitter<boolean>(false);

  get isAdmin() {
    return this.authorizationService.isAdmin;
  }

  get isLoggedIn(): boolean {
    return this.authorizationService.isLoggedIn();
  }

  constructor(
    private authorizationService: AuthorizationService,
    private authenticationService: AuthenticationService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  logout(): void {
    this.authenticationService.logout();
  }

  isAdminPage() {
    const isAdminPage = this.router.url.includes('/admin');
    return isAdminPage;
  }
}
