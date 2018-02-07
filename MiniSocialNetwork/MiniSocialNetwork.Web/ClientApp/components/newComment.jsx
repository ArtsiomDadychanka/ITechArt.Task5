import React from 'react';

class NewComment extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      text: ''
    };
  }

  sendNewComment = () => {
    const { createComment } = this.props.commentsActions;
    const { currentUserId, postId } = this.props;
    let newComment = {
      AuthorId: currentUserId,
      Text: this.state.text,
      PostId: postId
    };

    createComment(newComment);
  }

  onCommentTextChange = (e) => {
    if (e.target.value.trim().length > 0) {
      this.setState({
        text: e.target.value,
      });
    }
  }


  render() {
    // const comment = this.state.commentText;

    return (
      <div className="new-comment">
        <div className="row">
          <div className="input-field col s5">
            <textarea
              onChange={this.onCommentTextChange}
              className="materialize-textarea"
              placeholder="your comment"
            >
            </textarea>
          </div>
          <div className="col offset-s5 s1">
            <button
              onClick={this.sendNewComment}
              className="btn-floating waves-effect waves-light green">
              <i className="material-icons">add</i>
            </button>
          </div>

        </div>
      </div>
    );
  }
}

export default NewComment;
