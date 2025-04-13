import { Link } from "react-router-dom"; 
const Header = () => {
    return (
        <header className="bg-gray-900 text-white p-4 shadow-log">
            <div className="container mx-auto flex justifiy-between items-center">
                <Link to="/" className="text-2xl font-bold">
                    MovieTheater
                </Link>
                <nav className="flex space-x-6">
                    <Link to="/" className="hover:text-yellow-400">Trang chủ</Link>
                    <Link to="/now-showing" className="hover:text-yellow-400">Phim đang chiếu</Link>
                    <Link to="/comming-soon" className="hover:text-yellow-400">Phim sắp chiếu</Link>
                </nav>
                <button className="bg-yellow-500 px-4 py-2 rounded hover:bg-yellow-600">
                    Đăng nhập
                </button>
            </div>
        </header>
    )
}
export default Header;