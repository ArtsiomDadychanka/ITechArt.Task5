import React from 'react';
class LikeButton extends React.Component {
  static get defaultProps() {
    return {
      postId: ''
    }
  }

  constructor(props) {
    super(props);

    this.state = {
      isLiked: false,
    };
  }

  like = () => {
    const { postId } = this.props;
    const { like, unlike } = this.props;

    if (!this.state.isLiked) {
      like(postId);
      this.likeUpdate();
    } else {
      unlike(postId);
      this.likeUpdate();
    }
  }

  likeUpdate = () => {
    this.setState({
      isLiked: !this.state.isLiked
    });
  }


  render() {
    const buttonState = this.state.isLiked ? 'favorite' : 'favorite_border';
    return (
      <a
        onClick={this.like}
        className={`like-button`}
      >
        <i className="material-icons">{buttonState}</i>
      </a>
    );
  }
}

export default LikeButton;
