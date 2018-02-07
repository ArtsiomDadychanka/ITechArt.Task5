import React from 'react';
import NewComment from '../containers/newCommentContainer';
import Comment from '../containers/commentContainer';

class Comments extends React.Component {

  render() {
    const { comments, postId } = this.props;

    const postComments = comments ?
      comments.map((comment) => {
        return (
          <Comment
            postId={postId}
            key={comment.id}
            comment={comment}
          />);
      }) :
      [];

    return (
      <ul className="collapsible comments">
        <li>
          <div className="collapsible-header">
            <i className="material-icons">
              message
                </i>
            Show comments
              </div>
          <div className="collapsible-body">
            {postComments}
            <NewComment postId={postId} />
          </div>
        </li>
      </ul>
    );
  }
}

export default Comments;
