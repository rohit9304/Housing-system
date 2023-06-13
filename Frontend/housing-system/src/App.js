import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import SignUpPage from './pages/SignUpPage';
import LoginPage from './pages/LoginPage';
import PropertyListPage from './pages/PropertyListPage';
import AddPropertyPage from './pages/AddPropertyPage';
import PropertyDetailsPage from './pages/PropertyDetailsPage';

function App() {
  return (
    <Router>
      <div>       
        <Routes>
          <Route exact path="/" element={<LoginPage />} />
          <Route exact path="/signup" element={<SignUpPage/>} />
          <Route exact path="/addproperty" element={<AddPropertyPage/>} />
          <Route exact path="/propertylist" element={<PropertyListPage/>} />
          <Route path="/propertydetails/:id" element={<PropertyDetailsPage/>} />

          
        </Routes>
      </div>
    </Router>
  );
}

export default App;