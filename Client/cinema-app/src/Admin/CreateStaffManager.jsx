import React, { useState } from "react";
import { useNavigate, Link } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const CreateStaffManager = () => {
  const [userName, setUserName] = useState("");
  const [email, setEmail] = useState("");
  const [phone, setPhone] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const navigate = useNavigate();

  const handleSubmit = async (event) => {
    event.preventDefault();
    setLoading(true);
    setError(null);

    try {
      const tokenString = localStorage.getItem("user");
      const userObject = tokenString ? JSON.parse(tokenString) : null;
      const authToken = userObject?.token;

      if (!authToken) {
        setError("Không tìm thấy token. Vui lòng đăng nhập lại.");
        setLoading(false);
        return;
      }

      const response = await fetch("http://mtt.runasp.net/api/admin/users", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${authToken}`,
          accept: "*/*",
        },
        body: JSON.stringify({ userName, email, phone }),
      });

      if (!response.ok) {
        const errorData = await response.json();
        setError(`Tạo Staff Manager thất bại: ${errorData?.message || response.statusText}`);
        toast.error(`Tạo Staff Manager thất bại: ${errorData?.message || response.statusText}`);
      } else {
        const data = await response.json();
        toast.success("Tạo Staff Manager thành công!");
        navigate("/admin-dashboard/staffmanager"); // Chuyển về trang quản lý
      }
    } catch (err) {
      setError(`Đã có lỗi xảy ra: ${err.message}`);
      toast.error(`Đã có lỗi xảy ra: ${err.message}`);
      console.error("Lỗi tạo Staff Manager:", err);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="p-8">
      <header className="mb-8 flex items-center justify-between">
        <h2 className="text-2xl font-bold text-gray-800">Thêm Staff Manager</h2>
        <Link
          to="/admin-dashboard/staffmanager"
          className="inline-flex items-center px-4 py-2 bg-gray-300 hover:bg-gray-400 text-gray-700 font-bold rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-gray-500 focus:ring-offset-2"
        >
          Hủy
        </Link>
      </header>

      <form onSubmit={handleSubmit} className="bg-white shadow rounded-lg p-6">
        {error && <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative mb-4" role="alert">
          <strong className="font-bold">Lỗi!</strong>
          <span className="block sm:inline">{error}</span>
        </div>}

        <div className="mb-4">
          <label htmlFor="userName" className="block text-gray-700 text-sm font-bold mb-2">
            Username:
          </label>
          <input
            type="text"
            id="userName"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            value={userName}
            onChange={(e) => setUserName(e.target.value)}
            required
          />
        </div>

        <div className="mb-4">
          <label htmlFor="email" className="block text-gray-700 text-sm font-bold mb-2">
            Email:
          </label>
          <input
            type="email"
            id="email"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <div className="mb-6">
          <label htmlFor="phone" className="block text-gray-700 text-sm font-bold mb-2">
            Phone:
          </label>
          <input
            type="text"
            id="phone"
            className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            value={phone}
            onChange={(e) => setPhone(e.target.value)}
          />
        </div>

        <div className="flex items-center justify-between">
          <button
            type="submit"
            className={`bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline ${loading ? 'opacity-50 cursor-not-allowed' : ''}`}
            disabled={loading}
          >
            {loading ? "Đang lưu..." : "Lưu"}
          </button>
        </div>
      </form>
    </div>
  );
};

export default CreateStaffManager;