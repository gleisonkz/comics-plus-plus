import { ComicImage } from './comic-image.model';
export interface ComicList {
  comicID: number;
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
}
