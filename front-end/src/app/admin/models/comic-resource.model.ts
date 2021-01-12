import { ComicImage } from '@core/models/comic-image.model';
import { Author, Genre } from '.';

export interface ComicResource {
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
  authors: Author[];
  genres: Genre[];
  image: ComicImage;
}
