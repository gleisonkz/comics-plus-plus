import { ModelProps } from './model-props.model';
import { PaginatorProps } from './paginator-props.model';

export type Filter<T> = ModelProps<T> & PaginatorProps;
