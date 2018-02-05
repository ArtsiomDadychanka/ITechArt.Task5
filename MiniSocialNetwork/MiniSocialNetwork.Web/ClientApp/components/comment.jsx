import React from 'react';

const Comment = ({ comment = {} }) => {
  const { authorName, id, postedDate, text } = comment;

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
