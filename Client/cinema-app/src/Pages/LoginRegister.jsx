import { useState } from "react"
import {districtsByArea, favoriteCinemas} from "../data/area" 
import { fakeAccounts } from "../data/accountdata";
import { useNavigate } from "react-router-dom";

const LoginRegister = () => {
    const [activeTab, setActiveTab] = useState("login");

    return (
        <div className="flex items-center justify-center min-h-screen bg-gray-900 p-4">
            <div className="bg-gray-900 rounded-lg w-full max-w-md overflow-hidden shadow-lg relative">
                <div className="flex border-b">
                    <button
                        className={`flex-1 py-4 font-medium ${activeTab === "login" ? 'text-yellow-500 border-b-2 border-yellow-500' :'text-gray-500'}`}
                        onClick={() => setActiveTab("login")}
                    >
                        Đăng nhập
                    </button>
                    <button
                        className={`flex-1 py-4 font-medium ${activeTab === "register" ? 'text-yellow-500 border-b-2 border-yellow-500' :'text-gray-500'}`}
                        onClick={() => setActiveTab("register")}
                    >
                        Đăng ký
                    </button>
                </div>

                <div className="p-6">
                    {activeTab === "login" ? (
                        <LoginForm />
                    ) : (
                        <RegisterForm />
                    )}
                </div>
            </div>
        </div>
    );
};

const LoginForm = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
    
    const handleSubmit = (e) => {
        e.preventDefault();
        const foundUser = fakeAccounts.find((user) => user.email === email && user.password === password);
        if (!foundUser) {
            alert("Tài khoản hoặc mật khẩu không đúng!");
            return;
        }
        localStorage.setItem('user', JSON.stringify(foundUser));
        if (foundUser.role === "ADMIN") {
            navigate("/admin-dashboard");
        } else if (foundUser.role === "STAFF") {
            navigate("/staff-dashboard");
        } else if (foundUser.role === "CUSTOMER") {
            navigate("/");
        }else {
            alert("Tài khoản không hợp lệ!");
            return;
        }
        console.log(email, password);
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2 className="text-2xl font-bold mb-6 text-yellow-500">Đăng nhập</h2>
            <div className="mb-4">
                <input
                    type="email"
                    placeholder="Email"
                    className="w-full px-4 py-2 border rounded-md"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    required
                />
            </div>
            <div className="mb-6">
                <input
                    type="password"
                    placeholder="Mật khẩu"
                    className="w-full px-4 py-2 border rounded-md"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    required
                />
            </div>
            <button type="submit" className="w-full bg-yellow-500 text-gray-900 py-2 rounded-md font-medium hover:bg-yellow-600 transition">
                Đăng nhập
            </button>
        </form>
    );
};

const RegisterForm = () => {
    const [name, setName] = useState("");
    const [phone,setPhone] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [birthDate,setBirthDate] = useState("");
    const [gender, setGender] = useState("");
    const [area, setArea] = useState("");
    const [district, setDistrict] = useState("");
    const [cinema, setCinema] = useState("");


    const handleSubmit = (e) => {
        e.preventDefault();
        console.log(name,phone, email, password, birthDate, gender, area, district, cinema);
    };
    const districtsOptions = area ? districtsByArea[area] || [] : [];
    const cinemasOptions = area && district ? favoriteCinemas[area][district] || [] : [];

    return (
        <form onSubmit={handleSubmit}>
            <h2 className="text-2xl font-bold mb-6 text-yellow-500">Đăng ký</h2>
            <div className="mb-4">
                <input type="text" placeholder="Họ tên" className="w-full px-4 py-2 border rounded-md"
                    value={name} onChange={(e) => setName(e.target.value)} required />
            </div>
            <div className="mb-4">
                <input type="tel" placeholder="Số điện thoại" className="w-full px-4 py-2 border rounded-md"
                    value={phone} onChange={(e) => setPhone(e.target.value)} required />
            </div>
            <div className="mb-4">
                <input type="email" placeholder="Email" className="w-full px-4 py-2 border rounded-md"
                    value={email} onChange={(e) => setEmail(e.target.value)} required />
            </div>
            <div className="mb-4">
                <input type="password" placeholder="Mật khẩu" className="w-full px-4 py-2 border rounded-md"
                    value={password} onChange={(e) => setPassword(e.target.value)} required />
            </div>
            <div className="mb-4">
                <label className="block mb-1 text-sm text-yellow-500">Ngày sinh</label>
                <input type="date" className="w-full px-4 py-2 border rounded-md"
                    value={birthDate} onChange={(e) => setBirthDate(e.target.value)} required />
            </div>
            
            <div className="mb-4">
                <label className="block mb-1 text-sm text-yellow-500">Giới tính</label>
                <div className="flex gap-4 text-yellow-500">
                    <label className="flex items-center">
                        <input type="radio" name="gender" value="Nam" checked={gender === "Nam"} onChange={() => setGender("Nam")} />
                        <span className="ml-2">Nam</span>
                    </label>
                    <label className="flex items-center">
                        <input type="radio" name="gender" value="Nữ" checked={gender === "Nữ"} onChange={() => setGender("Nữ")} />
                        <span className="ml-2">Nữ</span>
                    </label>
                </div>
            </div>
            <div className="mb-4">
                <label className="block mb-1 text-sm text-yellow-500">Khu vực</label>
                <select className="w-full px-4 py-2 border rounded-md"
                    value={area} onChange={(e) => {
                        setArea(e.target.value);
                        setDistrict("");
                        setCinema("");
                    }} required>
                    <option value="">-- Chọn khu vực --</option>
                    {Object.keys(districtsByArea).map((a) => (
                        <option key={a} value={a}>{a}</option>
                    ))}
                </select>
            </div>

            {districtsOptions.length > 0 && (
                <div className="mb-4">
                    <label className="block mb-1 text-sm text-yellow-500">Quận</label>
                    <select className="w-full px-4 py-2 border rounded-md"
                        value={district} onChange={(e) => {
                            setDistrict(e.target.value);
                            setCinema("");
                        }} required>
                        <option value="">-- Chọn quận --</option>
                        {districtsOptions.map((d) => (
                            <option key={d} value={d}>{d}</option>
                        ))}
                    </select>
                </div>
            )}

            {cinemasOptions.length > 0 && (
                <div className="mb-6">
                    <label className="block mb-1 text-sm text-yellow-500">Rạp yêu thích</label>
                    <select className="w-full px-4 py-2 border rounded-md"
                        value={cinema} onChange={(e) => setCinema(e.target.value)} required>
                        <option value="">-- Chọn rạp --</option>
                        {cinemasOptions.map((c) => (
                            <option key={c} value={c}>{c}</option>
                        ))}
                    </select>
                </div>
            )}
            <button type="submit" className="w-full bg-yellow-500 text-gray-900 py-2 rounded-md font-medium hover:bg-yellow-600 transition">
                Đăng ký
            </button>
        </form>
    );
};

export default LoginRegister;
