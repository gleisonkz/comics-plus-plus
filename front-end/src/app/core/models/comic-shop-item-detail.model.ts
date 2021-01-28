export interface ComicShopItemDetail {
  comicID: number;
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
  inventoryQuantity: number;
  imagePreview: string;
  genres: string[];
  authors: string[];
}
