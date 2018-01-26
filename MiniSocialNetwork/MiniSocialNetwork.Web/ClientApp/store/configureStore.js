import {
  createStore,
  applyMiddleware,
} from 'redux';
import {
  createLogger
} from 'redux-logger';
import thunk from 'redux-thunk';
import rootReducer from '../reducers/rootReducer';

export default function configureStore(initState) {
  const logger = createLogger();
  const store = createStore(
    rootReducer,
    initState,
    applyMiddleware(logger, thunk));
  return store;
}