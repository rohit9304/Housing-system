import axios from 'axios';

const baseURL = 'http://localhost:5106'; // Update the base URL with your actual API base URL

const api = axios.create({
  baseURL,
});

api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token');
  if (token) {
    config.headers['Authorization'] = `Bearer ${token}`;
  }
  return config;
});

// User Controller
export const registerUser = (userDto) => api.post('/api/User/register', userDto);
export const loginUser = (userLoginDto) => api.post('/api/user/login', userLoginDto);

// Property Controller
export const getAllProperties = () => api.get('/api/property');
export const getPropertyById = (id) => api.get(`/api/property/${id}`);
export const createProperty = (propertyDto) => api.post('/api/property/add', propertyDto);
export const deleteProperty = (id) => api.delete(`/api/property/${id}`);

export default api;
