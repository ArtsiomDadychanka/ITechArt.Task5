import React from 'react';

const Comment = ({ comment = {}, commentsActions, postId }) => {
  const { authorName, id, postedDate, text } = comment;
  const { removeComment } = commentsActions;

  return (
    <div className="comment">
      <div className="row">
        <div className="comment__author col s2">
          <a className="green-text">
            {authorName}
          </a>
        </div>
        <div className="comment__posted-time col s4">
          {postedDate}
        </div>
        <div className="col offset-s5 s1">
          <a
            className="post__remove-btn"
            onClick={() => { removeComment({ id, postId }); }}
          >
            <i className="material-icons">clear</i>
          </a>
        </div>
      </div>
      <div className="row">
        <div className="comment__text col s12">
          {text}
        </div>
      </div>
    </div>
  );
}

export default Comment;
