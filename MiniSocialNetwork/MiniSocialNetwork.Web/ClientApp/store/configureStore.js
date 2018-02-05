import {
  createStore,
  applyMiddleware,
  compose
} from 'redux';
import {
  createLogger
} from 'redux-logger';
import {
  composeWithDevTools
} from 'redux-devtools-extension';
import thunk from 'redux-thunk';
import rootReducer from '../reducers/rootReducer';

export default function configureStore(initState) {
  const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;
  const logger = createLogger();

  const store = createStore(
    rootReducer,
    initState,
    composeWithDevTools(
      applyMiddleware(logger, thunk)
    ));
  return store;
}