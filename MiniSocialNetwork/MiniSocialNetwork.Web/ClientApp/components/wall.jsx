import React from 'react';
import NewPost from './newPost';
import Posts from '../components/posts';

class Wall extends React.Component {
  static get defaultProps() {
    return {
      posts: [],
      currentUserId: '',
    };
  }

  constructor(props) {
    super(props);
  }

  onAddPostBtnClick = (post) => {
    const { postsActions } = this.props;
    const { createPost } = postsActions;

    createPost(post);
  }

  onRemoveBtnClick = (postId) => {
    const { postsActions } = this.props;
    const { removePost } = postsActions;

    removePost(postId);
  }

  render() {
    const { posts } = this.props;
    const { currentUserId } = this.props;

    return (
      <div className="wall col s8  grey lighten-4">
        <NewPost
          currentUserId={currentUserId}
          onAddPostBtnClick={this.onAddPostBtnClick}
        />
        <Posts onRemoveBtnClick={this.onRemoveBtnClick} posts={posts} />
      </div>
    );
  }
}

export default Wall;
