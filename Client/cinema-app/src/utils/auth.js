import { jwtDecode } from "jwt-decode";
export const getUser = () => {
  const token = localStorage.getItem("token");
  if(!token) return null;
  try {
    const decoded = jwtDecode(token);
    return {
      email:decoded.Email  || decoded.email,
      role:decoded.Role || decoded.role,
      userName: decoded.UserName || decoded.userName,
      id: decoded.UserId || decoded.id,
    };
  }catch (error) {
    console.log("Token không hợp lệ", error);
    return null;
  }
}