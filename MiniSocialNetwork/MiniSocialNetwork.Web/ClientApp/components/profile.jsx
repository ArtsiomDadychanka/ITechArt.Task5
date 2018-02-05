import React from 'react';
import ProfileSidebar from './panels/profileSidebar';
import SubscribersSidebar from './panels/subscribersSidebar';
import Wall from './wall';
import * as  global from '../constants/global';

class Profile extends React.Component {
  constructor(props) {
    super(props);


  }

  componentDidMount() {
    const { loadUserInfo } = this.props.userActions;
    const { userId } = this.props;
    if (userId) {
      loadUserInfo(userId);
    } else {
      const currentUserId = sessionStorage.getItem(global.CURRENT_USER_ID);
      loadUserInfo(currentUserId);
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
    const { posts } = user;

    return (
      <div className="profile row">
        <ProfileSidebar user={user} />
        <Wall posts={posts} />
        <SubscribersSidebar />
      </div>
    );
  }
}

export default Profile;
