import React from 'react';
import ProfileSidebar from './panels/profileSidebar';
import SubscribersSidebar from './panels/subscribersSidebar';
import Wall from '../containers/wallContainer';
import * as  global from '../constants/global';

class Profile extends React.Component {
  static get defaultProps() {
    return {
      userId: '',
      user: {},
      posts: [],
    };
  }

  constructor(props) {
    super(props);
  }

  componentDidMount() {
    const { loadUserInfo } = this.props.userActions;
    const { getPosts } = this.props.postsActions;

    const { userId } = this.props;
    if (userId) {
      loadUserInfo(userId);
      getPosts(userId);
    } else {
      const currentUserId = sessionStorage.getItem(global.CURRENT_USER_ID);
      loadUserInfo(currentUserId);
      getPosts(currentUserId);
    }
  }

  render() {
    const { user, isFetching } = this.props;
    console.log(isFetching);
    console.log(this.props);
    if (isFetching) {
      return (
        <div>
          Loading ...
        </div>
      )
    }
    const { posts } = this.props;
    console.log('PL');
    console.log(posts.length);
    const { username } = user;

    const { userId } = this.props;
    let isSelf = false;

    if (!userId) {
      isSelf = !isSelf;
    }

    return (
      <div className="profile row">
        <ProfileSidebar userId={userId} isSelf={isSelf} username={username} />
        <Wall posts={posts} />
        <SubscribersSidebar />
      </div>
    );
  }
}

export default Profile;
