import { Component } from '@angular/core';

import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';

@Component({
  selector: 'app-root',
  template: `
    <abp-loader-bar></abp-loader-bar>
    <abp-dynamic-layout></abp-dynamic-layout>
  `,
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppComponent {}
