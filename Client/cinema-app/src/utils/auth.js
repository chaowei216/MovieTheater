import { jwtDecode } from "jwt-decode";
export const getUser = () => {
  const token = localStorage.getItem("token");
  if (!token) return null;

  try {
    const decoded = jwtDecode(token);
    console.log("Decoded Token:", decoded); // Debug
    
    return {
      email: decoded.Email || decoded.email || "",
      role: (decoded.Role || decoded.role || "").toUpperCase(),
      userName: decoded.UserName || decoded.userName || "",
      id: decoded.UserId || decoded.id || decoded.sub || "",
    };
  } catch (error) {
    console.error("Invalid token:", error);
    return null;
  }
};