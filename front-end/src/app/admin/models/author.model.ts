interface Author extends AuthorResource {
  authorID: number;
}

interface AuthorListItem {
  authorID: number;
  name: string;
  birthDate: Date;
}

interface AuthorResource {
  name: string;
  birthDate: Date;
  nationality: string;
}

export { Author, AuthorListItem, AuthorResource };
