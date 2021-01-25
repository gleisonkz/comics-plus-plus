import { ComicImage } from '@core/models/comic-image.model';
import { Author } from './author.model';
import { Genre } from './genre.model';

interface Comic extends ComicResource {
  comicID: number;
}

interface ComicResource {
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
  authors: Author[];
  genres: Genre[];
  image: ComicImage;
}

interface ComicListItem {
  comicID: number;
  title: string;
  description: string;
  price: number;
  year: number;
  pages: number;
}

interface ComicFilterProps extends ComicListItem {}

export { Comic, ComicResource, ComicListItem, ComicFilterProps };
