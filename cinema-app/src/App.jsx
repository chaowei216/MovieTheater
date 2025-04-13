import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Home from "./Pages/Home";
import Header from "./Components/Headers";
import Footer from "./Components/Footer";
// import NowShowing from "./Pages/NowShowing";
// import ComingSoon from "./Pages/ComingSoon";
import MovieDetail from "./Pages/MovieDetail";
import './index.css'

function App() {
  return (
    <Router>
      {/* Header hiển thị trên mọi trang */}
      <Header />
      
      <Routes>
        <Route path="/" element={<Home />} />
        {/* <Route path="/now-showing" element={<NowShowing />} />
        <Route path="/coming-soon" element={<ComingSoon />} /> */}
        <Route path="/movie/:id" element={<MovieDetail />} />
      </Routes>

      {/* Footer hiển thị trên mọi trang */}
      <Footer />
    </Router>
  );
}

export default App;