import {
  animate,
  query,
  style,
  transition,
  trigger
} from '@angular/animations';

export const fadeAnimation = trigger('fade', [
  transition('* <=> *', [
    query(':enter', [style({ opacity: 0, transform: 'translateY(-15px)' })], {
      optional: true
    }),
    query(':leave', animate('50ms', style({ opacity: 0 })), {
      optional: true
    })
  ])
]);
