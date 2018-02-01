import * as types from './actionTypes';
import * as global from '../constants/global';

export function signUp(userCredentials) {
  return (dispath) => {
    dispath({
      type: types.SIGN_UP_REQUEST,
      data: null
    });
    console.log(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.SIGNUP}`);
    fetch(`${global.SERVER_API_ADDRESS}${global.SERVER_API_URI.SIGNUP}`, {
        mode: 'cors',
        method: 'post',
        headers: global.defaultHeadersToApi,
        body: JSON.stringify(userCredentials)
      })
      .then(res => {
        if (res.status !== 200) {
          dispath({
            type: types.SIGN_UP_REJECT,
            data: null,
            error: res.statusText,
          });
        }
        return res.json();
      })
      .then(res => {
        dispath({
          type: types.SIGN_UP_SUCCESS,
          data: userCredentials,
          redirectUrl: `${global.SERVER_ADDRESS}${global.PAGES_URL.USER_PROFILE}`
        });
      })
      .catch(err => console.log(err));
  };
}