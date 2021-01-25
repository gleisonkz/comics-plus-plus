export type ModelProps<T> = {
  [K in keyof T]: T[K];
};
