import React from 'react';
import Comment from './comment';
import NewComment from './newComment';

class Comments extends React.Component {

  render() {
    const { comments } = this.props;

    const postComments = comments ?
      comments.map((comment) => {
        return (<Comment key={comment.id} comment={comment} />);
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
            <NewComment />
          </div>
        </li>
      </ul>
    );
  }
}

export default Comments;
