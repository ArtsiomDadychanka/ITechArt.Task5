import React from 'react'
import PrimaryLogo from './primary-logo'

const Header = () => {
  return (
    <header className="primary-header ">
      <nav className="primary-header__inner">
        <div className="nav-wrapper">
          <ul id="nav-mobile" className="right hide-on-med-and-down">
            <li><a href="sass.html">Sass</a></li>
            <li><a href="badges.html">Components</a></li>
            <li><a href="collapsible.html">JavaScript</a></li>
          </ul>
          <PrimaryLogo />
        </div>
      </nav>
    </header>
  )
}

export default Header
