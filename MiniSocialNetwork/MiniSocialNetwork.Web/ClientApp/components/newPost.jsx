import React from 'react';

class NewPost extends React.Component {
  static get defaultProps() {
    return {
      currentUserId: ''
    }
  }

  constructor(props) {
    super(props);

    this.state = {
      postText: ''
    };
  }

  sendNewPost = () => {
    const { onAddPostBtnClick } = this.props;
    const { currentUserId } = this.props;
    let newPost = {
      AuthorId: currentUserId,
      Text: this.state.postText,
    };

    onAddPostBtnClick(newPost);
  }

  onPostTextChange = (e) => {
    if (e.target.value.trim().length > 0) {
      this.setState({
        postText: e.target.value,
      });
    }
  }

  render() {
    return (
      <div className="new-post">
        <div className="new-post__title row">
          <div className="col s12">
            <h5 className="new-post__title-text">Write a new post for your subscribers</h5>
          </div>
        </div>
        <div className="new-post__text row">
          <div className="input-field col s12">
            <textarea
              onChange={this.onPostTextChange}
              id="textarea1"
              className="materialize-textarea"
              placeholder="Write a new post"
            >
            </textarea>
          </div>
        </div>
        <button
          onClick={this.sendNewPost}
          className="btn-floating waves-effect waves-light green">
          <i className="material-icons">add</i>
        </button>
      </div>
    );
  }
}

export default NewPost;
