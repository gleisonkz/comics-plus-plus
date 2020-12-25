import { ComicImage } from './comic-image.model';

export interface ComicShopItemDetail {
  comicID: number;
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
  inventoryQuantity: number;
  image: ComicImage;
  genres: string[];
  authors: string[];
}
