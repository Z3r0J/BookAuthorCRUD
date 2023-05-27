import { Injectable } from '@angular/core';
import { IBookRequest } from '../interfaces/Book/IBookRequest';
import { IBookResponse } from '../interfaces/Book/IBookResponse';
import { IServices } from '../interfaces/services/IServices';
import axios from 'axios';
import { axiosConfig } from './axios.config';

@Injectable({
  providedIn: 'root',
})
export class BookService implements IServices<IBookResponse, IBookRequest> {
  async getAll(): Promise<IBookResponse[]> {
    const response = await axiosConfig.get('/book');
    if (response.status === 200) return response.data as IBookResponse[];
    return [] as IBookResponse[];
  }
  async getById(id: string): Promise<IBookResponse> {
    const response = await axiosConfig.get(`/book/${id}`);

    if (response.status === 200) return response.data as IBookResponse;

    return {} as IBookResponse;
  }
  async add(item: IBookRequest): Promise<void> {
    await axiosConfig.post('/book', item);
  }
  async update(id: string, item: IBookRequest): Promise<void> {
    await axiosConfig.put(`/book/${id}`, item);
  }
  async delete(id: string): Promise<void> {
    await axiosConfig.delete(`/book/${id}`);
  }
}
