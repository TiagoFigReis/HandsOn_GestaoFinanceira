import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { AuthFacade } from '@farm/core';

@Component({
  selector: 'lib-sign-in',
  imports: [CommonModule, RouterModule],
  templateUrl: './sign-in.component.html',
  styleUrl: './sign-in.component.css',
})
export class SignInComponent implements OnInit {
  constructor(private authFacade: AuthFacade, private router: Router) {}

  ngOnInit(): void {
    if (this.authFacade.isAuthenticated) this.router.navigate(['/app']);
  }
}
