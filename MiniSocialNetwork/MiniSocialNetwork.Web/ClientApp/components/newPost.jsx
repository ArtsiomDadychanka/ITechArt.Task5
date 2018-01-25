import React from 'react';

const NewPost = () => {
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
            id="textarea1"
            className="materialize-textarea"
            placeholder="Write a new post"
          >
          </textarea>
        </div>
      </div>
      <button className="btn-floating waves-effect waves-light green">
        <i className="material-icons">add</i>
      </button>
    </div>
  );
}

export default NewPost;
