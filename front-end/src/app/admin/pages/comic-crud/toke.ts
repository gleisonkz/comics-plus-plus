import { ICustomDataSource } from '@admin/classes/custom-data-source';
import { InjectionToken } from '@angular/core';

export const CUSTOM_DATA_SOURCE = new InjectionToken<ICustomDataSource>(
  'CUSTOM_DATA_SOURCE'
);
