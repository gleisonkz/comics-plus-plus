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

export { Genre, GenreResource, GenreListItem };
