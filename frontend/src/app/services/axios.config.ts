import { AxiosInstance } from './../../../node_modules/axios/index.d';
import axios from 'axios';

export const axiosConfig: AxiosInstance = axios.create({
  baseURL: 'https://localhost:5001/api/v1',
  headers: { 'X-Custom-Header': 'foobar' },
});
