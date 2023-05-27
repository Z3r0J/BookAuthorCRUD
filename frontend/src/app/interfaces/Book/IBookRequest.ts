export interface IBookRequest {
  title: string;
  sypnosis: string;
  releaseDate: Date;
  publisher: string;
  genreId: string;
  authorsId: string[];
}
