import { Component, Input } from '@angular/core';
import { AuthService } from '@abp/ng.core';


@Component({
  selector: 'app-recruitment-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class RecruitmentSidebarComponent {
  @Input() collapsed = false;
}
