// Pages/AdminDashboard.jsx
import React from "react";
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

const AdminDashboard = ({ setUser }) => {
  const navigate = useNavigate();

  const handleLogout = () => {
    // Xóa thông tin user trong localStorage
    localStorage.removeItem("user");
    setUser(null);
    // Redirect về trang login
    navigate("/");
  };

  return (
    <div className="flex min-h-screen bg-gray-100">
      {/* Sidebar */}
      <aside className="w-64 bg-white shadow-md p-4 flex flex-col justify-between">
        <div>
          <h2 className="text-2xl font-bold mb-6">Admin Panel</h2>
          <nav className="space-y-4">
            <Link to="/admin-dashboard" className="block text-gray-700 hover:text-blue-600">Dashboard</Link>
            <Link to="/admin-dashboard/movies" className="block text-gray-700 hover:text-blue-600">Quản lý phim</Link>
            <Link to="/admin-dashboard/staffmanager" className="block text-gray-700 hover:text-blue-600">Quản lý Staff Manager</Link>
            <Link to="/admin-dashboard/customer" className="block text-gray-700 hover:text-blue-600">Quản lý Customer</Link>
            <Link to="/admin-dashboard/content" className="block text-gray-700 hover:text-blue-600">Quản lý nội dung</Link>
            <Link to="/admin-dashboard/Report" className="block text-gray-700 hover:text-blue-600">Reports</Link>
          </nav>
        </div>

        {/* Nút logout */}
        <button 
          onClick={handleLogout} 
          className="mt-8 bg-red-500 hover:bg-red-600 text-white font-semibold py-2 px-4 rounded"
        >
          Logout
        </button>
      </aside>

      {/* Main content */}
      <main className="flex-1 p-8">
        <header className="mb-8">
          <h1 className="text-3xl font-bold text-gray-800">Welcome, Admin!</h1>
        </header>

        <section className="grid grid-cols-1 md:grid-cols-3 gap-6 mb-8">
          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-xl font-semibold text-gray-800 mb-2">Total Movies</h2>
            <p className="text-3xl font-bold text-blue-600">24</p>
          </div>
          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-xl font-semibold text-gray-800 mb-2">Active Showtimes</h2>
            <p className="text-3xl font-bold text-green-600">12</p>
          </div>
          <div className="bg-white p-6 rounded-lg shadow">
            <h2 className="text-xl font-semibold text-gray-800 mb-2">Users</h2>
            <p className="text-3xl font-bold text-purple-600">132</p>
          </div>
        </section>

        <section className="bg-white p-6 rounded-lg shadow">
          <h2 className="text-xl font-bold text-gray-800 mb-4">Recent Activities</h2>
          <ul className="list-disc list-inside space-y-2 text-gray-700">
            <li>New movie added: *Avengers: Secret Wars*</li>
            <li>5 new users registered today</li>
            <li>Updated showtimes for *Dune: Part II*</li>
          </ul>
        </section>
      </main>
    </div>
  );
};

export default AdminDashboard;
