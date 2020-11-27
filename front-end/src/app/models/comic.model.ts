import { Author } from './author.model';
import { Genre } from './genre.model';

export interface Comic {
  comicID: number;
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
  author: Author[];
  genre: Genre[];
  imagePath: string;
}
