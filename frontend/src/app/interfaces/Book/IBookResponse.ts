import { IBasicAuthor } from '../Author/IBasicAuthor';

export interface IBookResponse {
  id: string;
  title: string;
  sypnosis: string;
  releaseDate: Date;
  publisher: string;
  genreId: string;
  genreName: string;
  authorList: IBasicAuthor[];
}
