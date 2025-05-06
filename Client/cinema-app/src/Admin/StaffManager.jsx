import React, { useState, useEffect } from "react";
import { Link } from "react-router-dom";
import { toast } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

const StaffManagerList = () => {
  const [staffManagers, setStaffManagers] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const userString = localStorage.getItem("user");
        let authToken = null;

        if (userString) {
          const userObject = JSON.parse(userString);
          authToken = userObject.token;
        }

        console.log("Token được lấy từ localStorage:", authToken);

        const response = await fetch("http://mtt.runasp.net/api/admin/users", {
          headers: {
            Authorization: `Bearer ${authToken}`,
            accept: "*/*",
          },
        });

        if (!response.ok) {
          const message = `An error occurred: ${response.status}`;
          throw new Error(message);
        }

        const data = await response.json();

        // Lọc users có userName chứa "staffmanager" (giải pháp tạm thời)
        const filteredStaff = data.filter(user =>
          user.userName.toLowerCase().includes("staffmanager")
        );

        setStaffManagers(filteredStaff);
        setIsLoading(false);
      } catch (err) {
        setError("Failed to load staff managers");
        setIsLoading(false);
        toast.error("Failed to fetch users");
        console.error("Error fetching users:", err);
      }
    };

    fetchUsers();
  }, []);

  if (isLoading) {
    return (
      <div className="flex justify-center items-center h-64">
        <div className="animate-spin rounded-full h-12 w-12 border-t-2 border-b-2 border-blue-500"></div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="bg-red-100 border border-red-400 text-red-700 px-4 py-3 rounded relative" role="alert">
        <strong className="font-bold">Error!</strong>
        <span className="block sm:inline"> {error}</span>
      </div>
    );
  }

  return (
    <div className="p-8">
      <header className="mb-8 flex items-center justify-between">
        <h2 className="text-2xl font-bold text-gray-800">Danh sách Staff Manager</h2>
        <Link
          to="/admin-dashboard"
          className="inline-flex items-center px-4 py-2 bg-gray-300 hover:bg-gray-400 text-gray-700 font-bold rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-gray-500 focus:ring-offset-2"
        >
          Quay lại
        </Link>
      </header>
      <div className="bg-white shadow rounded-lg overflow-hidden">
        <table className="min-w-full divide-y divide-gray-200">
          <thead className="bg-gray-50">
            <tr>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Username</th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Email</th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Phone</th>
              <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Status</th>
            </tr>
          </thead>
          <tbody className="bg-white divide-y divide-gray-200">
            {staffManagers.length > 0 ? (
              staffManagers.map(staff => (
                <tr key={staff.id} className="hover:bg-gray-50">
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-900">{staff.userName}</td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{staff.email}</td>
                  <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">{staff.phone || "N/A"}</td>
                  <td className="px-6 py-4 whitespace-nowrap">
                    <span className={`px-2 inline-flex text-xs leading-5 font-semibold rounded-full ${
                      staff.isBlocked ? "bg-red-100 text-red-800" : "bg-green-100 text-green-800"
                    }`}>
                      {staff.isBlocked ? "Blocked" : "Active"}
                    </span>
                  </td>
                </tr>
              ))
            ) : (
              <tr>
                <td className="px-6 py-4 whitespace-nowrap text-center text-sm text-gray-500" colSpan="4">
                  Không có Staff Manager nào.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      <div className="mt-4">
        <Link
          to="/admin-dashboard/staffmanager/add"
          className="inline-flex items-center px-4 py-2 bg-blue-500 hover:bg-blue-700 text-white font-bold rounded-md shadow-sm focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
        >
          Thêm Staff Manager
        </Link>
      </div>
    </div>
  );
};

export default StaffManagerList;