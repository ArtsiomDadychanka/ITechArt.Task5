import React from 'react';
import NewPost from './newPost';
import Posts from './posts';

const Wall = () => {
  return (
    <div className="wall col s8  grey lighten-4">
      <NewPost />
      <Posts />
    </div>
  );
}

export default Wall;
