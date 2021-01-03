import {
  animate,
  group,
  query,
  style,
  transition,
  trigger
} from '@angular/animations';

const resetRoute = [
  style({ position: 'relative' }),
  query(
    ':enter, :leave',
    [
      style({
        position: 'fixed', // using absolute makes the scroll get stuck in the previous page's scroll position on the new page
        top: 60, // adjust this if you have a header so it factors in the height and not cause the router outlet to jump as it animates
        left: 0,
        width: '100%',
        opacity: 0
      })
    ],
    { optional: true }
  )
];

// Fade Animation
export const routeFadeAnimation = trigger('routeFadeAnimation', [
  transition('* => *', [
    ...resetRoute,
    query(':enter', [style({ opacity: 0 })], {
      optional: true
    }),
    group([
      query(
        ':leave',
        [style({ opacity: 1 }), animate('0.2s', style({ opacity: 0 }))],
        { optional: true }
      ),
      query(
        ':enter',
        [style({ opacity: 0 }), animate('0.5s', style({ opacity: 1 }))],
        { optional: true }
      )
    ])
  ])
]);
