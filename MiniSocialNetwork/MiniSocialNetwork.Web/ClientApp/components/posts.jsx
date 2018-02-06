import React from 'react';
import Post from './post';

class Posts extends React.Component {
  constructor(props) {
    super(props);

  }

  componentDidMount() {
    console.log('porps');
    console.log(this.props);
  }

  render() {
    const { posts = [], comments = [], onRemoveBtnClick } = this.props;

    const userPosts = posts.map((post) => {
      return (
        <Post onRemoveBtnClick={onRemoveBtnClick} key={post.post.id} post={post} />
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
