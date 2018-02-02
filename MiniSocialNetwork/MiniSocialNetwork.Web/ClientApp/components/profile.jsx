import React from 'react';
import ProfileSidebar from './panels/profileSidebar';
import SubscribersSidebar from './panels/subscribersSidebar';
import Wall from './wall';

class Profile extends React.Component {
  constructor(props) {
    super(props);


  }

  componentDidMount() {

  }

  render() {
    return (
      <div className="profile row">
        <ProfileSidebar />
        <Wall />
        <SubscribersSidebar />
      </div>
    );
  }
}

export default Profile;
