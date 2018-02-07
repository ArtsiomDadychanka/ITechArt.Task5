import React from 'react';
import UserThumbnail from './userThumbnail';
import LikeButton from './buttons/likeButton';
import CommentButton from './buttons/commentButton';
import Comments from '../components/comments';

class Post extends React.Component {
  static get defaultProps() {
    return {
      post: {}
    }
  }

  constructor(props) {
    super(props);
  }

  componentWillReceiveProps(nextProps) {
    console.log('NEXT');
  }

  componentDidMount() {
    $(document).ready(function () {
      $('.collapsible').collapsible();
    });
  }


  render() {

    const { post, onRemoveBtnClick } = this.props;
    const { likePost, unlikePost } = this.props.postsActions;
    const { authorName, text, postedDate, likeCounts, id } = post.post;
    const { comments } = post;
    console.log('INIT');
    likeCounts === 8 && alert("asdad");
    return (
      <div className="post row">
        <div className="row">
          <UserThumbnail col={"s1"} />
          <div className="post__content col s6">
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
          <div className="post__buttons row col s3">
            <div className="post__like">
              <LikeButton postId={id} unlike={unlikePost} like={likePost} />
              <span className="post__counter">
                {likeCounts}
              </span>
            </div>
            <div className="post__comment">
            </div>
          </div>
          <div className="col s1">
            <a className="post__remove-btn" onClick={() => { onRemoveBtnClick(id) }}>
              <i className="material-icons">clear</i>
            </a>
          </div>
        </div>
        <div className="post__comments row">
          <Comments postId={id} comments={comments} />
        </div>
      </div>
    );
  }
}

export default Post;
