import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { getPropertyById } from '../services/Api';
import '../css/propertydetails.css'; 

function PropertyDetails() {
  const { id } = useParams();
  const [property, setProperty] = useState(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    fetchPropertyDetails();
  }, []);

  const fetchPropertyDetails = () => {
    getPropertyById(id)
      .then((response) => {
        setProperty(response.data);
        setLoading(false);
      })
      .catch((error) => {
        setError('Error occurred while fetching property details');
        setLoading(false);
      });
  };

  if (loading) {
    return <p>Loading...</p>;
  }

  if (error) {
    return <p>{error}</p>;
  }

  if (!property) {
    return null;
  }

  return (
    <div>
      
      <div className="property-details-container">
      <h2>Property Details</h2>
        <div className="property-image">
          <img src={require('../css/img.jpg')} alt="Universal" />
        </div>
        <div className="property-info">
          <h3>{property.title}</h3>
          <p>Price: {property.price}</p>
          <p>Address: {property.address}</p>
          <p>Description: {property.description}</p>
          <p>Bhk: {property.bhk}</p>
        </div>
      </div>
    </div>
  );
}

export default PropertyDetails;
