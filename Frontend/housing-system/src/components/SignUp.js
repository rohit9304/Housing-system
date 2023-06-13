import React, { useState } from 'react';
import { registerUser } from '../services/Api';
import { useNavigate } from 'react-router-dom';
import '../css/signup.css';

function Signup() {
  const [username, setUsername] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleUsernameChange = (e) => {
    setUsername(e.target.value);
  };

  const handleEmailChange = (e) => {
    setEmail(e.target.value);
  };

  const handlePasswordChange = (e) => {
    setPassword(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!username || !email || !password) {
      setError('Please fill in all the fields');
      return;
    }

    const userDto = {
      username: username,
      email: email,
      password: password,
    };

    registerUser(userDto)
      .then((response) => {
        console.log(response.data);
        setUsername('');
        setEmail('');
        setPassword('');
        setError(null);
        navigate('/'); // Redirect to the login page
      })
      .catch((error) => {
        console.error('Error occurred during signup:', error);
      });
  };

  return (
    <div className='signup-container'>
      <h2>Signup</h2>
      <form className="signup-form" onSubmit={handleSubmit}>
        <label>Username:</label>
        <input type="text" value={username} onChange={handleUsernameChange} required />
        
        <label>Email:</label>
        <input type="email" value={email} onChange={handleEmailChange} required />

        <label>Password:</label>
        <input type="password" value={password} onChange={handlePasswordChange} required />

        <button type="submit">Sign Up</button>
        {error && <p>{error}</p>}
      </form>
    </div>
  );
}

export default Signup;
