import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import Header from "./Components/Headers";
import Footer from "./Components/Footer";
import AdminDashboard from "./Admin/AdminDashboard";
import MovieDetail from "./Pages/MovieDetail";
import './index.css'
import LoginRegister from "./Pages/LoginRegister";
import { getUser } from "./utils/auth";
import { useState, useEffect } from "react";
import MovieManagement from "./Admin/MovieManagement";

function App() {
  const [user, setUser] = useState(null);
  const [isLoading, setIsLoading] = useState(true); // Thêm loading flag

  useEffect(() => {
    const storedUser = getUser();
    setUser(storedUser);
    setIsLoading(false); // Chỉ render sau khi setUser xong
  }, []);

  if (isLoading) {
    return <div>Loading...</div>; // hoặc spinner
  }

  return (
    <Router>
      {!user || user.role === "CUSTOMER" ? <Header /> : null}

      <Routes>
        <Route path="/" element={<Home />} />

        {user?.role === "ADMIN" && (
          <>
            <Route path="/admin-dashboard" element={<AdminDashboard setUser={setUser} />} />
            <Route path="/admin-dashboard/movies" element={<MovieManagement />} />
          </>
        )}

        <Route path="/login" element={<LoginRegister setUser={setUser} />} />
        <Route path="/movie/:id" element={<MovieDetail />} />
      </Routes>

      {(!user || user.role === "CUSTOMER") && <Footer />}
    </Router>
  );
}


export default App;
