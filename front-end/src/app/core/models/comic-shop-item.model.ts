import { SafeUrl } from '@angular/platform-browser';

export interface ComicShopItem {
  comicID: number;
  title: string;
  description: string;
  price: number;
  imagePreview: SafeUrl;
  inventoryQuantity: number;
  genres: string[];
  authors: string[];
}
