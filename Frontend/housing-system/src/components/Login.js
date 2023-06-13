import React, { useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';
import { loginUser } from '../services/Api';
import '../css/login.css';

function Login() {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleLogin = (e) => {
    e.preventDefault();

    if (!username || !password) {
      setError('Please fill in all the fields');
      return;
    }

    const loginRequest = {
      username: username,
      password: password,
    };

    loginUser(loginRequest)
      .then((response) => {
        const token = response.data.Token;
        localStorage.setItem('token', token);
        console.log(token);
        if (response.status === 200 || response.status === 204) {
          navigate('/propertylist'); // Navigate to the desired route
        } else {
          setError('Invalid username or password');
        }
      })
      .catch((error) => {
        if (error.response && error.response.data && error.response.data.message) {
          console.log(error.response.error);
          setError(error.response.error);
        } else {
          setError('An error occurred during login. Please try again.');
        }
      });
  };

  return (
    <div className="login-container">
      <h2>Login Here</h2>
      <form className="login-form" onSubmit={handleLogin}>
        <div>
          <label>Username:</label>
          <input
            type="text"
            placeholder="Username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Password:</label>
          <input
            type="password"
            placeholder="Password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <button type="submit">Login</button>
        {error && <p className="error-message">{error}</p>}
        <p id="paragraph">
          Don't have an account? <Link to="/signup">Register Here!</Link>
        </p>
      </form>
    </div>
  );
}

export default Login;
