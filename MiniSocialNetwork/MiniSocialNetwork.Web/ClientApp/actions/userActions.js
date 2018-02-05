import * as types from './actionTypes';
import * as global from '../constants/global';

function convertURI(id) {
  const uriPattern = global.SERVER_API_URI.USER_INFO;
  const regexptPattern = global.URI_REGEXP_PATTERN;
  return uriPattern.replace(global.URI_REGEXP_PATTERN, id);
}

export function loadUserInfo(userId) {
  return (dispatch) => {
    dispatch({
      type: types.GET_USER_INFO_REQUEST,
      data: null
    });

    const convertedURI = convertURI(userId);

    fetch(`${global.SERVER_API_ADDRESS}${convertedURI}`, {
        mode: 'cors',
        method: 'get',
        headers: global.authorizeHeaders
      })
      .then(res => {
        if (res.status !== 200) {
          dispatch({
            type: types.GET_USER_INFO_REJECT,
            data: null,
            error: res.statusText,
          });
        }
        return res.json();
      })
      .then(userInfo => {
        dispatch({
          type: types.GET_USER_INFO_SUCCESS,
          data: userInfo
        });
      })
      .catch(err => console.log(err));
  };
}