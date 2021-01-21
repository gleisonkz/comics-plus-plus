interface Author extends AuthorResource {
  authorID: number;
}

type AuthorListItem = Omit<AuthorResource, 'nationality'>;

interface AuthorResource {
  name: string;
  birthDate: Date;
  nationality: string;
}

export { Author, AuthorListItem, AuthorResource };
