import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import Header from "./Components/Headers";
import Footer from "./Components/Footer";
// import NowShowing from "./Pages/NowShowing";
// import ComingSoon from "./Pages/ComingSoon";
import AdminDashboard from "./Admin/AdminDashboard";
import MovieDetail from "./Pages/MovieDetail";
import './index.css'
import LoginRegister from "./Pages/LoginRegister";
import { getUser } from "./utils/auth";
import { useState, useEffect} from "react";
function App() {
  const [user,setUser] = useState(null);
  useEffect(() => {
    const storedUser = getUser();
    setUser(storedUser)
  },[])
  return (
    <Router>
      {/* Header hiển thị trên mọi trang */}
      {!user || user.role === "CUSTOMER" ?  <Header /> : null}
     
      
      <Routes>
        <Route path="/" element={<Home />} />
        {/* <Route path="/now-showing" element={<NowShowing />} />
        <Route path="/coming-soon" element={<ComingSoon />} /> */}
        {/* Route dành cho từng role */}
         {user?.role === "ADMIN" && <Route path="/admin-dashboard" element={<AdminDashboard setUser={setUser}/>}/>}
        {/* {user?.role === "STAFF" && <Route path="/staff-dashboard" element={<StaffDashboard />} />}  */}
        <Route path="/login" element={<LoginRegister setUser={setUser}/>}/>
        <Route path="/movie/:id" element={<MovieDetail />} />
      </Routes>

      {/* Footer hiển thị trên mọi trang */}
      {(!user || user.role === "CUSTOMER") && <Footer />}
  
    </Router>
  );
}

export default App;