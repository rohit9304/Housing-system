import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import { getAllProperties } from '../services/Api';
import '../css/propertylist.css';

function PropertyList() {
  const [properties, setProperties] = useState([]);
  const [error, setError] = useState('');

  useEffect(() => {
    fetchProperties();
  }, []);

  const fetchProperties = () => {
    getAllProperties()
      .then((response) => {
        setProperties(response.data);
      })
      .catch((error) => {
        setError('Error occurred while fetching properties');
      });
  };

  return (
    <div className="property-list-container">
      <h2>Property List</h2>
      {error && <p>{error}</p>}
      <Link to="/addproperty" className="add-property">Add Property</Link>
      <div className="property-grid">
        {properties.map((property) => (
          <div className="property-item" key={property.id}>
            <img src={require('../css/img.jpg')} alt="Universal" />
            <div className="property-details">
              <h3>{property.title}</h3>
              <p>Price: {property.price}</p>
              <p>Address: {property.address}</p>
              <Link to={`/propertydetails/${property.id}`} className="details-link">View Full Details</Link>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}

export default PropertyList;
