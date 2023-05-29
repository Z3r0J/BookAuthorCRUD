export interface IBookRequest {
  id: string | undefined;
  title: string;
  sypnosis: string;
  releaseDate: Date;
  publisher: string;
  genreId: string;
  authorsId: string[];
}
