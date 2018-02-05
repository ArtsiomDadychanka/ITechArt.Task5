import React from 'react';
import NewPost from './newPost';
import Posts from './posts';

const Wall = ({ posts = [] }) => {
  return (
    <div className="wall col s8  grey lighten-4">
      <NewPost />
      <Posts posts={posts} />
    </div>
  );
}

export default Wall;
