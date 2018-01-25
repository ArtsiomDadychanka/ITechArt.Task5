import React from 'react';
import UserThumbnail from './userThumbnail';
import LikeButton from './buttons/likeButton';
import CommentButton from './buttons/commentButton';

const Post = () => {
  return (
    <div className="post row">
      <UserThumbnail col={"s1"} />
      <div className="post__content col s7">
        <div className="post__author green-text">
          Autor
        </div>
        <span className="post__date gray-text">
          12.05.2017
        </span>
        <article className="post__text">
          Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aliquam, maiores amet doloribus quia, eius numquam ea accusantium deserunt non incidunt accusamus quisquam asperiores quidem, dignissimos nisi repellat dolor. Molestias, totam.
        </article>
      </div>
      <div className="post__buttons row col s4">
        <div className="post__like">
          <LikeButton />
          <span className="post__counter">
            4
          </span>
        </div>
        <div className="post__comment">
          <CommentButton />
          <span className="post__counter">
            12
          </span>
        </div>
      </div>
    </div>
  );
}

export default Post;
