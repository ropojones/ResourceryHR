import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecruitmentComponent } from './recruitment.component';
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

const routes: Routes = [
  {
    path: '',
    component: RecruitmentComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: RecruitmentDashboardComponent, data: { title: 'Dashboard' } },
      { path: 'jobs', component: RecruitmentJobsComponent, data: { title: 'Jobs' } },
      { path: 'candidates', component: RecruitmentCandidatesComponent, data: { title: 'Candidates' } },
      { path: 'interviews', component: RecruitmentInterviewsComponent, data: { title: 'Interviews' } },
      { path: 'reports', component: RecruitmentReportsComponent, data: { title: 'Reports' } },
      { path: 'exercises', component: RecruitmentExercisesComponent, data: { title: 'Exercises' } },
      { path: 'organizations', component: RecruitmentOrganizationsComponent, data: { title: 'Organizations' } },
      { path: 'applications', component: RecruitmentApplicationsComponent, data: { title: 'Applications' } },
      { path: 'shortlisting', component: RecruitmentShortlistingComponent, data: { title: 'Shortlisting' } },
      { path: 'screening', component: RecruitmentScreeningComponent, data: { title: 'Screening' } }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecruitmentRoutingModule { }
