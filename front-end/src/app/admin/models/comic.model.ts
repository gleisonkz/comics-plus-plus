import { ComicImage } from '@core/models/comic-image.model';
import { Author } from './author.model';
import { Genre } from './genre.model';

export interface Comic {
  comicID: number;
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
  authors: Author[];
  genres: Genre[];
  image: ComicImage;
}

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
