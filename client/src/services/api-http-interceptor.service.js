import axios from 'axios';
import { baseUrl, apiSuffix } from '@config';

const instance = axios.create({
  baseURL: `${baseUrl}/${apiSuffix}`,
  headers: {
    Accept: 'application/json',
    'Content-Type': 'application/json'
  }
});

instance.interceptors.request.use(
  config => {
    const token = JSON.parse(localStorage.getItem('token'));
    if (token) {
      config.headers.common.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);

instance.interceptors.response.use(
  response => {
    if (response.status === 200 || response.status === 201) {
      return Promise.resolve(response);
    } else {
      return Promise.reject(response);
    }
  }, error => {
    if (error.response.status) {
      switch (error.response.status) {
        default:
          return Promise.reject(error.response);
      }
    }
  }
);

export default instance;
