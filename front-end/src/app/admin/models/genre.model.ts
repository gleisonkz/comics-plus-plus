interface Genre extends GenreResource {
  genreID: number;
}

interface GenreResource {
  description: string;
}

interface GenreListItem {
  genreID: number;
  description: string;
}

interface GenreFilterProps extends GenreListItem {}

export { Genre, GenreResource, GenreListItem, GenreFilterProps };
