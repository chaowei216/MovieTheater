import { Link, useNavigate } from "react-router-dom";
import { getUser } from "../utils/auth";
import { useState, useEffect } from "react";

// Component con để hiển thị menu người dùng
const UserMenu = ({ user, onLogout, navigate }) => {
  const [open, setOpen] = useState(false);

  const toggleMenu = () => setOpen(prev => !prev);

  return (
    <div className="relative">
      <button
        onClick={toggleMenu}
        className="bg-yellow-500 text-gray-900 font-medium py-2 px-4 rounded-md"
      >
        {user.email}
      </button>
      {open && (
        <div
          className="absolute right-0 bg-white text-black mt-2 py-2 rounded shadow-lg z-10"
          onMouseLeave={() => setOpen(false)}
        >
          <button
            onClick={() => {
              navigate("/profile");
              setOpen(false);
            }}
            className="block px-4 py-2 hover:bg-gray-100 w-full text-left"
          >
            Trang cá nhân
          </button>
          <button
            onClick={() => {
              onLogout();
              setOpen(false);
            }}
            className="block px-4 py-2 hover:bg-gray-100 w-full text-left"
          >
            Đăng xuất
          </button>
        </div>
      )}
    </div>
  );
};
const Header = ({ user, setUser }) => {
  const navigate = useNavigate();
  

  useEffect(() => {
    const updateUser = () => {
      const userData = getUser();
      setUser(userData);
    };

    updateUser(); // Lấy user lần đầu
    window.addEventListener("userChanged", updateUser); // Lắng nghe sự kiện đăng nhập

    return () => {
      window.removeEventListener("userChanged", updateUser);
    };
  }, []);

  const logoutFunction = () => {
    localStorage.removeItem("user");
    setUser(null);
    navigate("/login");
  };

  return (
    <header className="bg-gray-900 text-white sticky top-0 z-50 shadow-md w-full">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 w-full">
        <div className="flex items-center justify-between h-16 w-full">
          <div className="flex items-center flex-1">
            <Link 
              to="/" 
              className="text-2xl font-bold text-yellow-400 hover:text-yellow-300 transition duration-300 whitespace-nowrap"
            >
              Movie Theater
            </Link>
          </div>

          <nav className="flex-1 flex justify-center">
            <div className="flex space-x-4 md:space-x-8">
              <Link 
                to="/now-showing" 
                className="px-3 py-2 rounded-md text-sm font-medium text-white hover:text-yellow-400 hover:bg-gray-800 transition duration-300 whitespace-nowrap"
              >
                Phim đang chiếu
              </Link>
              <Link 
                to="/coming-soon" 
                className="px-3 py-2 rounded-md text-sm font-medium text-white hover:text-yellow-400 hover:bg-gray-800 transition duration-300 whitespace-nowrap"
              >
                Phim sắp chiếu
              </Link>
            </div>
          </nav>

          <div className="flex-1 flex justify-end">
            {user ? (
              <UserMenu user={user} onLogout={logoutFunction} navigate={navigate} />
            ) : (
              <button 
                onClick={() => navigate("/login")}
                className="bg-yellow-500 hover:bg-yellow-600 text-gray-900 font-medium py-2 px-4 rounded-md transition duration-300 transform hover:scale-105 whitespace-nowrap"
              >
                Đăng nhập
              </button>
            )}
          </div>
        </div>
      </div>
    </header>
  );
};

export default Header;
