import * as types from './actionTypes';
import * as global from '../constants/global';

function toServerFormat(user) {
  const preparedUser = {
    "grant_type": "password",
    "username": user.username,
    "password": user.password,
  };
  const dataAsParams = new URLSearchParams();
  for (const key in preparedUser) {
    dataAsParams.append(key, preparedUser[key]);
  }
  return dataAsParams;
}

export function signIn(userCredentials) {
  return (dispath) => {
    dispath({
      type: types.SIGN_IN_REQUEST,
      data: null
    });

    let headers = new Headers({
      "Accept": "application/json",
      "Content-Type": "application/x-www-form-urlencoded",
    });
    fetch(`${global.SERVER_TOKEN_ADDRESS}`, {
        mode: 'cors',
        method: 'post',
        headers,
        body: toServerFormat(userCredentials),
      })
      .then(res => {
        if (res.status !== 200) {
          dispath({
            type: types.SIGN_IN_REJECT,
            data: null,
            error: res.statusText,
          });
        }
        return res.json();
      })
      .then(json => {
        const token = json[global.ACCESS_TOKEN_KEY];
        sessionStorage.setItem(global.TOKEN_KEY, token);
        dispath({
          type: types.SIGN_IN_SUCCESS,
          data: json, // TODO: must be only username!
          redirectUrl: `${global.SERVER_ADDRESS}${global.PAGES_URL.USER_PROFILE}`
        });
      })
      .catch(err => console.log(err));
  };
}