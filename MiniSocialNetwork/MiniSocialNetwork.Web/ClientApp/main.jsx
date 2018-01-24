import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import {
    BrowserRouter,
} from 'react-router-dom';
import { AppContainer } from 'react-hot-loader';
import configureStore from './store/configureStore';
import App from './app';

const store = configureStore();

const render = (Component) => {
    ReactDOM.render(
        <AppContainer>
            <Provider store={store}>
                <BrowserRouter>
                    <Component />
                </BrowserRouter>
            </Provider>
        </AppContainer>,
        document.getElementById('app'),
    );
};

render(App);

// if (module.hot) {
//     module.hot.accept('./app', () => {
//         // eslint-disable-next-line
//         const nextApp = require('./app').default;
//         render(nextApp);
//     });
// }

  // module.hot.accept('./reducers', () => {
  //   // eslint-disable-next-line
  //   const nextRootReducer = require('./reducers/index');
  //   store.replaceReducer(nextRootReducer);
  // });