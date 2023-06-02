import { Injectable } from '@angular/core';
import { IAuthorRequest } from '../interfaces/Author/IAuthorRequest';
import { IAuthorResponse } from '../interfaces/Author/IAuthorResponse';
import { IServices } from '../interfaces/services/IServices';
import { axiosConfig } from './axios.config';

@Injectable({
  providedIn: 'root',
})
export class AuthorService
  implements IServices<IAuthorResponse, IAuthorRequest>
{
  async getAll(name?: string): Promise<IAuthorResponse[]> {
    const response = await axiosConfig.get('/author', {
      params: {
        name,
      },
    });
    if (response.status === 200) return response.data as IAuthorResponse[];
    return [] as IAuthorResponse[];
  }
  async getById(id: string): Promise<IAuthorResponse> {
    const response = await axiosConfig.get(`/author/${id}`);

    if (response.status === 200) return response.data as IAuthorResponse;

    return {} as IAuthorResponse;
  }
  async add(item: IAuthorRequest): Promise<void> {
    await axiosConfig.post('/author', item);
  }
  async update(id: string, item: IAuthorRequest): Promise<void> {
    await axiosConfig.put(`/author/${id}`, item);
  }
  async delete(id: string): Promise<void> {
    await axiosConfig.delete(`/author/${id}`);
  }
}
