import { AxiosInstance } from './../../../node_modules/axios/index.d';
import axios from 'axios';

export const axiosConfig: AxiosInstance = axios.create({
  baseURL: 'http://localhost:5286/api/v1',
  headers: { 'Content-Type': 'application/json' },
});
