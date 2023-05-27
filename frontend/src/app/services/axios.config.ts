import { AxiosInstance } from './../../../node_modules/axios/index.d';
import axios from 'axios';

export const axiosConfig: AxiosInstance = axios.create({
  baseURL: 'http://localhost:3000',
  timeout: 1000,
  headers: { 'X-Custom-Header': 'foobar' },
});
