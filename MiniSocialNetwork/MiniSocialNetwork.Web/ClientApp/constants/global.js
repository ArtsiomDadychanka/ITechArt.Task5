export const SERVER_ADDRESS = 'http://localhost/';
export const SERVER_API_ADDRESS = 'http://localhost/services' + '/api';
export const SERVER_TOKEN_ADDRESS = `http://localhost/services/token`;
export const SERVER_API_URI = {
  SIGNIN: `/account/signin`,
  SIGNUP: `/account/signup`,
  POSTS: `/posts`,
  POSTS_LIKE: `/posts/{id}/like`,
  POSTS_UNLIKE: `/posts/{id}/unlike`,
  USER_INFO: `/users/{id}`,
  COMMENTS: `/comments`,
  MESSAGES: `/messages`,
};
export const URI_REGEXP_PATTERN = /{.*}/gi;

export const PAGES_URL = {
  LOGIN: `Login`,
  USER_PROFILE: `Profile/Index`,
  MESSAGES: `Messages/Index`,
  SUBSCRIBERS: `Subscribers`,
  SETTINGS: `Settings`,
  ADMIN: `Admin`,
};
// session storage
export const TOKEN_KEY = 'TOKEN_KEY';
export const CURRENT_USER_ID = "CURRENT_USER_ID";

export const ACCESS_TOKEN_KEY = 'access_token';

export const defaultHeadersToApi = new Headers({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
});

const token = `Bearer ${sessionStorage.getItem(ACCESS_TOKEN_KEY)}`;
export const authorizeHeaders = new Headers({
  'Accept': 'application/json',
  'Content-Type': 'application/json',
  'Authorization': token
});

// hub
export const HUB_NAME = 'chatHub';