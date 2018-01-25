import React from 'react';
import PrimaryLogo from './primary-logo';

const Header = () => {
  return (
    <header className="primary-header ">
      <nav className="primary-header__inner">
        <div className="nav-wrapper">
          <ul id="nav-mobile" className="right hide-on-med-and-down">
            <li>
              <a className="dropdown-button" data-target="usermenu" href="#">Username</a>
            </li>
          </ul>
          <PrimaryLogo />
        </div>
      </nav>
    </header>
  )
}

export default Header
