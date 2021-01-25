interface Author extends AuthorResource {
  authorID: number;
}

type AuthorListItem = Omit<AuthorResource, 'nationality'>;

interface AuthorResource {
  name: string;
  birthDate: Date;
  nationality: string;
}

interface AuthorFilterProps {
  authorID: number;
  name: string;
  birthDate: Date;
}

export { Author, AuthorListItem, AuthorResource, AuthorFilterProps };
