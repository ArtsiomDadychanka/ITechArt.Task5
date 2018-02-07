import * as types from '../actions/actionTypes';

export default function postReducer(state = {}, action) {
  switch (action.type) {
    case types.GET_USER_POSTS_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
          // posts: []
        }
        return newState;
      }
    case types.GET_USER_POSTS_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          posts: action.data
        }
        return newState;
      }
    case types.GET_USER_POSTS_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
        }
        return newState;
      }
    case types.CREATE_POST_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.CREATE_POST_SUCCESS:
      {
        const newState = {
          ...state,
          isFetching: false,
          posts: [...state.posts, action.data]
        }
        return newState;
      }
    case types.CREATE_POST_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error,
        }
        return newState;
      }
    case types.DELETE_POSTS_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.DELETE_POSTS_SUCCESS:
      {
        const newPosts = state.posts.filter(
          (postWithComments) => {
            const post = postWithComments.post;
            return post.id !== action.data
          }
        );

        const newState = {
          ...state,
          isFetching: false,
          posts: newPosts
        }
        return newState;
      }
    case types.DELETE_POSTS_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error,
        }
        return newState;
      }
    case types.CREATE_COMMENT_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.CREATE_COMMENT_SUCCESS:
      {
        const posts = [...state.posts];
        const createdComment = action.data;
        let changedPost = posts.find((p) => {
          const post = p.post;
          return post.id == createdComment.postId;
        });
        changedPost.comments = [...changedPost.comments, createdComment];

        const newState = {
          ...state,
          isFetching: false,
          posts: posts
        }
        return newState;
      }
    case types.CREATE_COMMENT_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error,
        }
        return newState;
      }
    case types.DELETE_COMMENT_REQUEST:
      {
        const newState = {
          ...state,
          isFetching: true,
        }
        return newState;
      }
    case types.DELETE_COMMENT_SUCCESS:
      {
        const posts = [...state.posts];
        const {
          id,
          postId
        } = action.data;

        let changedPost = posts.find(
          (postWithComments) => {
            const post = postWithComments.post;
            return post.id === postId
          }
        );
        const updatedComments = changedPost.comments.filter((c) => {
          return c.id != id;
        });

        changedPost.comments = updatedComments;

        const newState = {
          ...state,
          isFetching: false,
          posts: posts
        }
        return newState;
      }
    case types.DELETE_COMMENT_REJECT:
      {
        const newState = {
          ...state,
          isFetching: false,
          error: action.error,
        }
        return newState;
      }
    case types.LIKE_POSTS_SUCCESS:
      {
        const posts = JSON.parse(JSON.stringify(state.posts));
        const likedPostId = action.data;

        let likedPost = posts.find((p) => {
          const post = p.post;
          return post.id === likedPostId;
        })
        likedPost.post.likeCounts++;

        const newState = {
          ...state,
          posts,
        }
        return newState;
      }
    case types.UNLIKE_POSTS_SUCCESS:
      {
        const posts = JSON.parse(JSON.stringify(state.posts));
        const unlikedPostId = action.data;

        let likedPost = posts.find((p) => {
          const post = p.post;
          return post.id === unlikedPostId;
        })
        if (likedPost.post.likeCounts > 0) {
          likedPost.post.likeCounts--;
        }

        const newState = {
          ...state,
          posts,
        }

        return newState;
      }
    default:
      return state;
  }
}