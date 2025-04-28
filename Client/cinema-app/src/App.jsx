import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import Header from "./Components/Headers";
import Footer from "./Components/Footer";
// import NowShowing from "./Pages/NowShowing";
// import ComingSoon from "./Pages/ComingSoon";
import MovieDetail from "./Pages/MovieDetail";
import './index.css'
import LoginRegister from "./Pages/LoginRegister";
import { getUser } from "./utils/auth";
function App() {
  const user = getUser();
  return (
    <Router>
      {/* Header hiển thị trên mọi trang */}
      {!user || user.role === "CUSTOMER" ?  <Header /> : null}
     
      
      <Routes>
        <Route path="/" element={<Home />} />
        {/* <Route path="/now-showing" element={<NowShowing />} />
        <Route path="/coming-soon" element={<ComingSoon />} /> */}
        {/* Route dành cho từng role */}
        {/* {user?.role === "ADMIN" && <Route path="/admin-dashboard" element={<AdminDashboard />} />}
        {user?.role === "STAFF" && <Route path="/staff-dashboard" element={<StaffDashboard />} />} */}
        <Route path="/login" element={<LoginRegister/>}/>
        <Route path="/movie/:id" element={<MovieDetail />} />
      </Routes>

      {/* Footer hiển thị trên mọi trang */}
      {(!user || user.role === "CUSTOMER") && <Footer />}
  
    </Router>
  );
}

export default App;