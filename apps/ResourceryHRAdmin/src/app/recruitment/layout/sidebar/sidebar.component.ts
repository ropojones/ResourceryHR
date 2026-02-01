import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-recruitment-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class RecruitmentSidebarComponent {
  @Input() collapsed = false;
}
