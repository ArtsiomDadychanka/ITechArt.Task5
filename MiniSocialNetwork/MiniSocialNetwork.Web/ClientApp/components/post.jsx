import React from 'react';
import UserThumbnail from './userThumbnail';
import LikeButton from './buttons/likeButton';
import CommentButton from './buttons/commentButton';
import Comments from '../components/comments';

class Post extends React.Component {
  componentDidMount() {


    $(document).ready(function () {
      $('.collapsible').collapsible();
    });
  }

  render() {
    const { post } = this.props;
    const { authorName, text, postedDate, likeCounts, id } = post.post;
    const { comments } = post;

    return (
      <div className="post row">
        <div className="row">
          <UserThumbnail col={"s1"} />
          <div className="post__content col s7">
            <div className="post__author green-text">
              {authorName}
            </div>
            <span className="post__date gray-text">
              {postedDate}
            </span>
            <article className="post__text">
              {text}
            </article>
          </div>
          <div className="post__buttons row col s4">
            <div className="post__like">
              <LikeButton />
              <span className="post__counter">
                {likeCounts}
              </span>
            </div>
            <div className="post__comment">
            </div>
          </div>
        </div>
        <div className="post__comments row">
          <Comments comments={comments} />
        </div>
      </div>
    );
  }
}

export default Post;
