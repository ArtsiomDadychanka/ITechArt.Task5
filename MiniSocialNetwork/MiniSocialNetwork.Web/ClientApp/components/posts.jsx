import React from 'react';
import Post from './post';

const Posts = ({ posts = [] }) => {
  const userPosts = posts.map((post) => {
    return (
      <Post key={post.id} post={post} />
    )
  });

  return (
    <div className="posts">
      {userPosts}
    </div>
  );
}

export default Posts;
