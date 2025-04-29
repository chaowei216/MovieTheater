import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { nowShowingMovies, comingSoonMovies } from "../data/movieData";

const MovieManagement = () => {
    const navigate = useNavigate();
    const [tab, setTab] = useState("nowShowing");
    const [movies, setMovies] = useState({
        nowShowing: nowShowingMovies,
        comingSoon: comingSoonMovies,
    });
    const [showModal, setShowModal] = useState(false);
    const [currentMovie, setCurrentMovie] = useState(null);
    const [modalType, setModalType] = useState("create"); // 'create' hoặc 'edit'

    const handleDelete = (type, id) => {
        const updated = movies[type].filter(movie => movie.id !== id);
        setMovies(prev => ({ ...prev, [type]: updated }));
    };

    const handleEdit = (type, movie) => {
        setCurrentMovie({ ...movie, type });
        setModalType("edit");
        setShowModal(true);
    };

    const handleCreate = () => {
        setCurrentMovie(null);
        setModalType("create");
        setShowModal(true);
    };

    const handleSave = (movieData) => {
        if (modalType === "create") {
            // Tạo phim mới
            const newMovie = {
                ...movieData,
                id: Date.now(), // Tạo ID tạm thời
            };
            setMovies(prev => ({
                ...prev,
                [movieData.type]: [...prev[movieData.type], newMovie]
            }));
        } else {
            // Cập nhật phim
            setMovies(prev => ({
                ...prev,
                [movieData.type]: prev[movieData.type].map(movie => 
                    movie.id === movieData.id ? movieData : movie
                )
            }));
        }
        setShowModal(false);
    };

    const renderMovies = (type) =>
        movies[type].map(movie => (
            <div key={movie.id} className="bg-white shadow-md rounded-lg overflow-hidden hover:shadow-lg transition-shadow">
                <img src={movie.poster} alt={movie.title} className="w-full h-64 object-cover" />
                <div className="p-4">
                    <h3 className="text-lg font-semibold mb-1">{movie.title}</h3>
                    <p className="text-sm text-gray-600 mb-1">
                        <strong>Thể loại:</strong> {movie.genre}
                    </p>
                    <p className="text-sm text-gray-600 mb-2">
                        <strong>Rating:</strong> {movie.rating || "N/A"}
                    </p>
                    <p className="text-sm text-gray-600 mb-1">
                    <strong>Thời lượng:</strong> {movie.duration || "N/A"}
                </p>
                <p className="text-sm text-gray-600 mb-2">
                    <strong>Khởi chiếu:</strong> {movie.releaseDate || "N/A"}
                </p>
                    <div className="flex justify-between">
                        <button 
                            onClick={() => handleEdit(type, movie)}
                            className="text-blue-600 hover:text-blue-800 text-sm font-medium"
                        >
                            Chỉnh sửa
                        </button>
                        <button 
                            onClick={() => handleDelete(type, movie.id)}
                            className="text-red-600 hover:text-red-800 text-sm font-medium"
                        >
                            Xóa phim
                        </button>
                    </div>
                </div>
            </div>
        ));

    return (
        <div className="p-6">
            {/* Modal */}
            {showModal && (
                <div className="fixed inset-0 bg-black bg-opacity-50 flex items-center justify-center z-50">
                    <div className="bg-white rounded-lg p-6 w-full max-w-md">
                        <h2 className="text-xl font-bold mb-4">
                            {modalType === "create" ? "Tạo phim mới" : "Chỉnh sửa phim"}
                        </h2>
                        
                        <MovieForm 
                            movie={currentMovie} 
                            onSave={handleSave} 
                            onCancel={() => setShowModal(false)}
                            type={modalType === "create" ? tab : currentMovie?.type}
                        />
                    </div>
                </div>
            )}

            <div className="flex justify-between items-center mb-6">
                <button 
                    onClick={() => navigate("/admin-dashboard")}
                    className="flex items-center text-gray-600 hover:text-gray-800"
                >
                    <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 mr-1" viewBox="0 0 20 20" fill="currentColor">
                        <path fillRule="evenodd" d="M9.707 16.707a1 1 0 01-1.414 0l-6-6a1 1 0 010-1.414l6-6a1 1 0 011.414 1.414L5.414 9H17a1 1 0 110 2H5.414l4.293 4.293a1 1 0 010 1.414z" clipRule="evenodd" />
                    </svg>
                    Quay lại
                </button>
                <h1 className="text-2xl font-bold text-center">Quản lý phim</h1>
                <button 
                    onClick={handleCreate}
                    className="bg-green-600 hover:bg-green-700 text-white px-4 py-2 rounded"
                >
                    Tạo phim mới
                </button>
            </div>

            <div className="mb-6 flex gap-4">
                <button 
                    onClick={() => setTab("nowShowing")} 
                    className={`px-4 py-2 rounded ${tab === "nowShowing" ? "bg-blue-600 text-white" : "bg-gray-200"}`}
                >
                    Phim đang chiếu
                </button>
                <button
                    onClick={() => setTab("comingSoon")}
                    className={`px-4 py-2 rounded ${tab === "comingSoon" ? "bg-blue-600 text-white" : "bg-gray-200"}`}
                >
                    Phim sắp chiếu
                </button>
            </div>

            {movies[tab].length === 0 ? (
                <div className="text-center py-8">
                    <p className="text-gray-500">Không có phim nào trong danh sách này.</p>
                    <button 
                        onClick={handleCreate}
                        className="mt-4 bg-green-600 hover:bg-green-700 text-white px-4 py-2 rounded"
                    >
                        Tạo phim mới ngay
                    </button>
                </div>
            ) : (
                <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6">
                    {renderMovies(tab)}
                </div>
            )}
        </div>
    );
};

// Component MovieForm để nhập thông tin phim
const MovieForm = ({ movie, onSave, onCancel, type }) => {
    const [formData, setFormData] = useState({
        title: movie?.title || "",
        genre: movie?.genre || "",
        rating: movie?.rating || "",
        poster: movie?.poster || "",
        duration: movie?.duration || "",
        releaseDate: movie?.releaseDate || "",
        type: type,
        id: movie?.id || null,
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prev => ({ ...prev, [name]: value }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        onSave(formData);
    };

    return (
        <form onSubmit={handleSubmit}>
            <div className="mb-4">
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="title">
                    Tên phim
                </label>
                <input
                    type="text"
                    id="title"
                    name="title"
                    value={formData.title}
                    onChange={handleChange}
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    required
                />
            </div>

            <div className="mb-4">
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="genre">
                    Thể loại
                </label>
                <input
                    type="text"
                    id="genre"
                    name="genre"
                    value={formData.genre}
                    onChange={handleChange}
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    required
                />
            </div>

            <div className="mb-4">
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="rating">
                    Rating
                </label>
                <input
                    type="number"
                    id="rating"
                    name="rating"
                    min="0"
                    max="10"
                    step="0.1"
                    value={formData.rating}
                    onChange={handleChange}
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                />
            </div>

            <div className="mb-4">
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="poster">
                    URL Poster
                </label>
                <input
                    type="url"
                    id="poster"
                    name="poster"
                    value={formData.poster}
                    onChange={handleChange}
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    required
                />
            </div>
            <div className="mb-4">
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="duration">
                    Thời lượng (phút)
                </label>
                <input
                    type="text"
                    id="duration"
                    name="duration"
                    value={formData.duration}
                    onChange={handleChange}
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    required
                />
            </div>

            <div className="mb-4">
                <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="releaseDate">
                    Ngày khởi chiếu
                </label>
                <input
                    type="text"
                    id="releaseDate"
                    name="releaseDate"
                    value={formData.releaseDate}
                    onChange={handleChange}
                    className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                    required
                />
            </div>

            <div className="flex justify-end gap-2 mt-6">
                <button
                    type="button"
                    onClick={onCancel}
                    className="bg-gray-300 hover:bg-gray-400 text-gray-800 font-bold py-2 px-4 rounded"
                >
                    Hủy
                </button>
                <button
                    type="submit"
                    className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
                >
                    Lưu
                </button>
            </div>
        </form>
    );
};

export default MovieManagement;