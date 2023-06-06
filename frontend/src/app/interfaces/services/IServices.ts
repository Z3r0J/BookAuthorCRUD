export interface IServices<Response, Request> {
  getAll(name?: string): Promise<Response[]>;
  getById(id: string): Promise<Response>;
  add(item: Request): Promise<void>;
  update(id: string, item: Request): Promise<void>;
  delete(id: string): Promise<void>;
}
