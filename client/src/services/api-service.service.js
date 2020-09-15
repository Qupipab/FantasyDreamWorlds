import instance from './api-http-interceptor.service';

const api = {
  get (path, params) {
    return instance({
      url: path,
      method: 'GET',
      params
    });
  },
  post (path, data) {
    return instance({
      url: path,
      method: 'POST',
      data: data
    });
  },
  put (path, data) {
    return instance({
      url: path,
      method: 'PUT',
      data: data
    });
  },
  delete (path, data) {
    return instance({
      url: path,
      method: 'DELETE',
      data: data
    });
  },
  postFile (path, formData) {
    return instance({
      url: path,
      method: 'POST',
      data: formData,
      headers: {
        headers: {
          'Content-Type': 'multipart/form-data'
        }
      }
    });
  }
};

export default api;
