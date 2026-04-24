import {Link, NavLink} from "react-router-dom";

const Navbar = () => {
    const isLoggedIn: boolean = true; 
    return (
        <nav>
            <div className="nav-inner">
                <Link to="/" className="logo">
                    TTRPGOrganizer
                    <span>Place to make notes</span>
                </Link>
                <ul className="nav-links">
                    <li><NavLink to="/about">About</NavLink></li>
                    {isLoggedIn ? (
                        <>
                            <li><NavLink to="/dashboard">Campaigns</NavLink></li>
                            <li><NavLink to="/profile">Profile</NavLink></li>
                        </>
                    ): (
                        <li><NavLink to="/login">Login</NavLink></li>
                    )
                    
                    }

                </ul>
                {isLoggedIn ? (
                    <>
                        <button className="nav-cta" onClick={() => alert('Logout')}>LOGOUT</button>
                    </>
                ) : (
                    <Link to="/register" className="nav-cta">JOIN US</Link>
                )}
            </div>
        </nav>
    );
};

export default Navbar;