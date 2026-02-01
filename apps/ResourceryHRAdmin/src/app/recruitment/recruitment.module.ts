import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RecruitmentRoutingModule } from './recruitment-routing.module';
import { RecruitmentComponent } from './recruitment.component';
import { RecruitmentSidebarComponent } from './layout/sidebar/sidebar.component';
import { RecruitmentPageComponent } from './layout/page/page.component';
import { RecruitmentDashboardComponent } from './dashboard/dashboard.component';
import { RecruitmentCandidatesComponent } from './candidates/candidates.component';
import { RecruitmentInterviewsComponent } from './interviews/interviews.component';
import { RecruitmentReportsComponent } from './reports/reports.component';
import { RecruitmentExercisesComponent } from './exercises/exercises.component';
import { RecruitmentJobsComponent } from './jobs/jobs.component';
import { RecruitmentOrganizationsComponent } from './organizations/organizations.component';
import { RecruitmentApplicationsComponent } from './applications/applications.component';
import { RecruitmentShortlistingComponent } from './shortlisting/shortlisting.component';
import { RecruitmentScreeningComponent } from './screening/screening.component';


@NgModule({
  declarations: [
    RecruitmentComponent,
    RecruitmentSidebarComponent,
    RecruitmentPageComponent,
    RecruitmentDashboardComponent,
    RecruitmentCandidatesComponent,
    RecruitmentInterviewsComponent,
    RecruitmentReportsComponent,
    RecruitmentExercisesComponent,
    RecruitmentJobsComponent,
    RecruitmentOrganizationsComponent,
    RecruitmentApplicationsComponent,
    RecruitmentShortlistingComponent,
    RecruitmentScreeningComponent
  ],
  imports: [
    CommonModule,
    RecruitmentRoutingModule
  ]
})
export class RecruitmentModule { }
