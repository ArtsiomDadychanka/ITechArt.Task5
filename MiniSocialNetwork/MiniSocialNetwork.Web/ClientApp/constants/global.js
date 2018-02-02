export const SERVER_ADDRESS = 'http://localhost:62795/';
export const SERVER_API_ADDRESS = 'http://localhost:56889' + '/api';
export const SERVER_TOKEN_ADDRESS = `http://localhost:56889/token`;
export const SERVER_API_URI = {
  SIGNIN: `/account/signin`,
  SIGNUP: `/account/signup`,
  POSTS: `/posts`,
  POSTS_LIKE: `/posts/id/like`,
  POSTS_UNLIKE: `/posts/id/unlike`,
};
export const PAGES_URL = {
  LOGIN: `Login`,
  USER_PROFILE: `Profile`,
  MESSAGES: `Messages`,
  SUBSCRIBERS: `Subscribers`,
  SETTINGS: `Settings`,
  ADMIN: `Admin`,
};
// session storage
export const TOKEN_KEY = 'TOKEN_KEY';
export const CURRENT_USERNAME = "CURRENT_USERNAME";


export const ACCESS_TOKEN_KEY = 'access_token';

export const defaultHeadersToApi = new Headers({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
});

const token = `Bearer ${sessionStorage.getItem(ACCESS_TOKEN_KEY)}`;
export const authorizeHeaders = defaultHeadersToApi.append(
  "Authorization",
  token
);