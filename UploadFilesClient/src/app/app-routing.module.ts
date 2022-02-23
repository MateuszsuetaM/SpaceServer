import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterUserComponent } from './authentication/register-user/register-user.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { HomeComponent } from './home/home.component';
import { UploadComponent } from './upload/upload.component';

const routes: Routes = [
  { path: 'upload', component: UploadComponent }
       ,{ path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
       { path: 'home', component: HomeComponent },
       { path: 'upload', component: UploadComponent },
//       { path: 'company', loadChildren: () => import('./company/company.module').then(m => m.CompanyModule) },
//       { path: '404', component : NotFoundComponent},
//       { path: '', redirectTo: '/home', pathMatch: 'full' },
       { path: '**', redirectTo: '/404', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }