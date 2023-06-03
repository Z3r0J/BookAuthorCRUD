export interface IAuthorResponse {
  id: string;
  firstName: string;
  lastName: string;
  address: string;
  email: string;
  birthDate: Date;
  books: any[];
  bookCount: number;
}
