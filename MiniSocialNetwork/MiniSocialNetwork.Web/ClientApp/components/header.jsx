import React from 'react';
import PrimaryLogo from './primary-logo';

const Header = ({ onLogoffClick }) => {
  return (
    <header className="primary-header ">
      <nav className="primary-header__inner">
        <div className="nav-wrapper">
          <ul id="nav-mobile" className="right hide-on-med-and-down">
            <li>
              <a
                onClick={onLogoffClick}
                className="dropdown-button"
                data-target="usermenu"
                href='#'
              >
                Log off
              </a>
            </li>
          </ul>
          <PrimaryLogo />
        </div>
      </nav>
    </header>
  )
}

export default Header
