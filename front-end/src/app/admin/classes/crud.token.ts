import { InjectionToken } from '@angular/core';
import { BaseCrud } from './crud.interface';

export const CRUD = new InjectionToken<BaseCrud>('BaseCrud');
