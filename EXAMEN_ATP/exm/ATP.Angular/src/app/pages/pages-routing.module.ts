import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'coding-tests',
    loadChildren: () =>
      import('./coding-tests/coding-tests.module').then(
        (m) => m.CodingTestsModule
      ),
  },
  {
    path: '',
    redirectTo: 'coding-tests',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {}
