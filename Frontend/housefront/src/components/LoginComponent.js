import React, { useState } from 'react';

const LoginComponent = () => {
  const [loginData, setLoginData] = useState({ username: '', password: '' });
  const [registerData, setRegisterData] = useState({ username: '', password: '', email: '' });
  const [showLogin, setShowLogin] = useState(true);

  const handleLoginChange = (e) => {
    setLoginData({ ...loginData, [e.target.name]: e.target.value });
  };

  const handleRegisterChange = (e) => {
    setRegisterData({ ...registerData, [e.target.name]: e.target.value });
  };

  const handleLoginSubmit = (e) => {
    e.preventDefault();
    // Handle login form submission here
    console.log('Login data:', loginData);
  };

  const handleRegisterSubmit = (e) => {
    e.preventDefault();
    // Handle register form submission here
    console.log('Register data:', registerData);
  };

  const toggleForm = () => {
    setShowLogin(!showLogin);
  };

  return (
    <div className="container">
      <h1>Welcome to Online Housing System</h1><br></br>
      <div className="row">
        <div className="col-md-6">
          {showLogin ? (
            <div>
              <h2>Login</h2>
              <form onSubmit={handleLoginSubmit}>
                <div className="form-group">
                  <label htmlFor="login-username">Username</label>
                  <input
                    type="text"
                    className="form-control"
                    id="login-username"
                    name="username"
                    value={loginData.username}
                    onChange={handleLoginChange}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="login-password">Password</label>
                  <input
                    type="password"
                    className="form-control"
                    id="login-password"
                    name="password"
                    value={loginData.password}
                    onChange={handleLoginChange}
                  />
                </div>
                <button type="submit" className="btn btn-primary">Login</button>
              </form>
              <p>
                Don't have an account?{' '}
                <button className="btn btn-link" onClick={toggleForm}>
                  Register here
                </button>
              </p>
            </div>
          ) : (
            <div>
              <h2>Register</h2>
              <form onSubmit={handleRegisterSubmit}>
                <div className="form-group">
                  <label htmlFor="register-username">Username</label>
                  <input
                    type="text"
                    className="form-control"
                    id="register-username"
                    name="username"
                    value={registerData.username}
                    onChange={handleRegisterChange}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="register-password">Password</label>
                  <input
                    type="password"
                    className="form-control"
                    id="register-password"
                    name="password"
                    value={registerData.password}
                    onChange={handleRegisterChange}
                  />
                </div>
                <div className="form-group">
                  <label htmlFor="register-email">Email</label>
                  <input
                    type="email"
                    className="form-control"
                    id="register-email"
                    name="email"
                    value={registerData.email}
                    onChange={handleRegisterChange}
                  />
                </div>
                <button type="submit" className="btn btn-primary">Register</button>
              </form>
              <p>
                Already have an account?{' '}
                <button className="btn btn-link" onClick={toggleForm}>
                  Login here
                </button>
              </p>
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default LoginComponent;
