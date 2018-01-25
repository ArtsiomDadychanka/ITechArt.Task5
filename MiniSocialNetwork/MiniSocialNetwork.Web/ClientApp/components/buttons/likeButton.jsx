import React from 'react';

const LikeButton = ({ styles = '' }) => {
  return (
    <a className={`like-button ${styles}`}>
      <i className="material-icons">favorite_border</i>
    </a>
  );
}

export default LikeButton;
