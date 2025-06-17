import { Component } from '@angular/core';

@Component({
  // eslint-disable-next-line @angular-eslint/component-selector, @angular-eslint/prefer-standalone
  standalone: false,
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `
})
export class AppComponent {}
