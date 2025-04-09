import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { ButtonComponent } from '@farm/ui';

@Component({
  selector: 'lib-home',
  imports: [CommonModule, RouterModule, ButtonComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {}
