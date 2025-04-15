import { Link } from "react-router-dom";

const Header = () => {
  return (
    <header className="bg-gray-900 text-white sticky top-0 z-50 shadow-md w-full">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8 w-full">
        <div className="flex items-center justify-between h-16 w-full">
          {/* Logo - Chiếm 1/3 bên trái */}
          <div className="flex items-center flex-1">
            <Link 
              to="/" 
              className="text-2xl font-bold text-yellow-400 hover:text-yellow-300 transition duration-300 whitespace-nowrap"
            >
              Movie Theater
            </Link>
          </div>
          
          {/* Navigation - Chiếm 1/3 giữa */}
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

          {/* Login Button - Chiếm 1/3 bên phải */}
          <div className="flex-1 flex justify-end">
            <button className="bg-yellow-500 hover:bg-yellow-600 text-gray-900 font-medium py-2 px-4 rounded-md transition duration-300 transform hover:scale-105 whitespace-nowrap">
              Đăng nhập
            </button>
          </div>
        </div>
      </div>
    </header>
  );
};

export default Header;