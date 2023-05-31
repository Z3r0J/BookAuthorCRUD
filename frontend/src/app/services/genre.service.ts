import { Injectable } from '@angular/core';
import { IGenreRequest } from '../interfaces/Genre/IGenreRequest';
import { IGenreResponse } from '../interfaces/Genre/IGenreResponse';
import { IServices } from '../interfaces/services/IServices';
import { axiosConfig } from './axios.config';

@Injectable({
  providedIn: 'root',
})
export class GenreService implements IServices<IGenreResponse, IGenreRequest> {
  async getAll(): Promise<IGenreResponse[]> {
    const response = await axiosConfig.get('/genre');

    return response.data as IGenreResponse[];
  }
  async getById(id: string): Promise<IGenreResponse> {
    const response = await axiosConfig.get(`/genre/${id}`);
    if (response.status === 200) return response.data as IGenreResponse;
    return {} as IGenreResponse;
  }
  async add(item: IGenreRequest): Promise<void> {
    await axiosConfig.post('/genre', item);
  }
  async update(id: string, item: IGenreRequest): Promise<void> {
    await axiosConfig.put(`/genre/${id}`, item);
  }
  async delete(id: string): Promise<void> {
    await axiosConfig.delete(`/genre/${id}`);
  }
}
