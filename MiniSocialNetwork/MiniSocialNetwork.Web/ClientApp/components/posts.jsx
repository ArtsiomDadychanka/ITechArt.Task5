import React from 'react';
import Post from '../containers/postContainer';

class Posts extends React.Component {
  static get defaultProps() {
    return {
      posts: [],
      comments: [],
    }
  }

  constructor(props) {
    super(props);

  }

  componentDidMount() {
    console.log('porps');
    console.log(this.props);
  }

  render() {
    const { posts = [], comments = [], onRemoveBtnClick } = this.props;

    const userPosts = posts.slice().map((postWithComments) => {
      const { post } = postWithComments;
      return (
        <Post onRemoveBtnClick={onRemoveBtnClick} key={post.id} post={postWithComments} />
      )
    });

    return (
      <div className="posts">
        {userPosts}
      </div>
    );
  }
}

export default Posts;
