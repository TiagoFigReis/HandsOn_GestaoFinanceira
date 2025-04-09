import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AvatarModule } from 'primeng/avatar';
import { OverlayBadgeModule } from 'primeng/overlaybadge';

@Component({
  selector: 'lib-avatar',
  imports: [CommonModule, AvatarModule, OverlayBadgeModule],
  templateUrl: './avatar.component.html',
  styleUrl: './avatar.component.css',
})
export class AvatarComponent {
  @Input() image = '';
  @Input() label = '';
  @Input() icon = '';
  @Input() size: 'large' | 'xlarge' | 'normal' = 'normal';
  @Input() shape: 'circle' | 'square' = 'circle';
  @Input() badge = false;
  @Input() badgeValue = '';
  @Input() badgeSeverity:
    | 'secondary'
    | 'info'
    | 'success'
    | 'warn'
    | 'danger'
    | 'contrast'
    | null
    | undefined = 'info';
}
