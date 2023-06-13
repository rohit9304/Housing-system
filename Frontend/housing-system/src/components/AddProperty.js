import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { createProperty } from '../services/Api';
import '../css/addproperty.css';

function AddProperty() {
  const [address, setAddress] = useState('');
  const [price, setPrice] = useState(0);
  const [description, setDescription] = useState('');
  const [bhk, setBhk] = useState(0);
  const [cityId, setCityId] = useState(0);
  const [userId, setUserId] = useState(0);
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = (e) => {
    e.preventDefault();

    const propertyData = {
      address: address,
      price: price,
      description: description,
      bhk: bhk,
      cityId: cityId,
      userId: userId
    };

    createProperty(propertyData)
      .then((response) => {
        console.log('Property added successfully');
        setError(null);
        navigate('/propertylist');
      })
      .catch((error) => {
        console.error('Error occurred while adding property:', error);
        setError('Error occurred while adding property');
      });
  };

  return (
    <div className="add-property-container">
      <h2>Add Property</h2>
      {error && <p>{error}</p>}
      <form onSubmit={handleSubmit}>
        <div>
          <label>Address:</label>
          <input
            type="text"
            value={address}
            onChange={(e) => setAddress(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Price:</label>
          <input
            type="number"
            value={price}
            onChange={(e) => setPrice(e.target.value)}
            required
          />
        </div>
        <div>
          <label>Description:</label>
          <input
            type="text"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
        </div>
        <div>
          <label>BHK:</label>
          <input
            type="number"
            value={bhk}
            onChange={(e) => setBhk(e.target.value)}
            required
          />
        </div>
        <div>
          <label>City ID:</label>
          <input
            type="number"
            value={cityId}
            onChange={(e) => setCityId(e.target.value)}
            required
          />
        </div>
        <div>
          <label>User ID:</label>
          <input
            type="number"
            value={userId}
            onChange={(e) => setUserId(e.target.value)}
            required
          />
        </div>
        <button type="submit">Add Property</button>
      </form>
    </div>
  );
}

export default AddProperty;
