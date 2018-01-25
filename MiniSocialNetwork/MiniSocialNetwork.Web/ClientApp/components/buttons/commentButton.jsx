import React from 'react';

const CommentButton = ({ styles = '' }) => {
  return (
    <a className={`comment-button ${styles}`}>
      <i className="small material-icons">message</i>
    </a>
  );
}

export default CommentButton;
