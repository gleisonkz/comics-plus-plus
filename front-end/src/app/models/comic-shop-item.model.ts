import { ComicImage } from './comic-image.model';

export interface ComicShopItem {
  comicID: number;
  title: string;
  description: string;
  price: number;
  image: ComicImage;
  genres: string[];
  authors: string[];
}
