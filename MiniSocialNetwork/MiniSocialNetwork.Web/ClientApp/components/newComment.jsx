import React from 'react';

const NewComment = () => {
  return (
    <div className="new-comment">
      <div className="row">
        <div className="input-field col s5">
          <textarea
            className="materialize-textarea"
            placeholder="your comment"
          >
          </textarea>
        </div>
        <div className="col offset-s5 s1">
          <button
            className="btn-floating waves-effect waves-light green">
            <i className="material-icons">add</i>
          </button>
        </div>

      </div>
    </div>
  );
}

export default NewComment;
