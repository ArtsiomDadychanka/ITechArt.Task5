import React from 'react';
import NewPost from './newPost';
import Posts from '../components/posts';

class Wall extends React.Component {
  constructor(props) {
    super(props);
  }

  onAddPostBtnClick = (post) => {
    const { postsActions } = this.props;
    const { createPost } = postsActions;

    createPost(post);
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
        <Posts posts={posts} />
      </div>
    );
  }
}

export default Wall;
