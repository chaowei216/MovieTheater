import { useParams } from "react-router-dom";
import { comingSoonMovies, nowShowingMovies } from "../data/movieData";
import { useState } from "react";

const getYouTubeId = (url) => {
  const regExp = /^.*(youtu.be\/|v\/|u\/\w\/|embed\/|watch\?v=|&v=)([^#&?]*).*/;
  const match = url.match(regExp);
  return (match && match[2].length === 11) ? match[2] : null;
};

const MovieDetail = () => {
  const { id } = useParams();
  const [showTrailer, setShowTrailer] = useState(false);

  const movie =
    nowShowingMovies.find((m) => m.id.toString() === id) ||
    comingSoonMovies.find((m) => m.id.toString() === id);

  if (!movie) {
    return (
      <div className="text-white text-center py-12">
        <h2>Không tìm thấy phim</h2>
      </div>
    );
  }

  return (
    <div className="bg-gray-900 text-white min-h-screen py-12">
      <div className="container mx-auto px-4">
        <div className="flex flex-col md:flex-row gap-8">
          <img
            src={movie.poster}
            alt={movie.title}
            className="w-full md:w-1/3 rounded-lg shadow-xl"
          />

          <div className="flex-1">
            <h1 className="text-4xl font-bold mb-3 text-yellow-400">{movie.title}</h1>
            <div className="flex items-center space-x-4 mb-6">
              <span className="text-yellow-400 flex items-center">
                <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 mr-1" viewBox="0 0 20 20" fill="currentColor">
                  <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                </svg>
                {movie.rating}
              </span>
              <span className="bg-gray-700 px-3 py-1 rounded-full text-sm">{movie.genre}</span>
              <span className="text-gray-400">{movie.duration || "Chưa cập nhật"}</span>
            </div>

            {/* Thêm thông tin mới */}
            <div className="grid grid-cols-1 md:grid-cols-2 gap-4 mb-6">
              <div>
                <h3 className="text-lg font-semibold text-yellow-400">Đạo diễn</h3>
                <p>{movie.director || "Đang cập nhật"}</p>
              </div>
              <div>
                <h3 className="text-lg font-semibold text-yellow-400">Diễn viên</h3>
                <p>{movie.cast ? movie.cast.join(", ") : "Đang cập nhật"}</p>
              </div>
              <div>
                <h3 className="text-lg font-semibold text-yellow-400">Ngày khởi chiếu</h3>
                <p>{movie.releaseDate || "Đang cập nhật"}</p>
              </div>
              <div>
                <h3 className="text-lg font-semibold text-yellow-400">Ngôn ngữ</h3>
                <p>{movie.language || "Đang cập nhật"}</p>
              </div>
            </div>

            <p className="text-gray-300 mb-8 leading-relaxed">{movie.description || "Mô tả chưa cập nhật."}</p>

            <div className="flex flex-wrap gap-4">
              {/* Nút Mua vé */}
              <button className="
                bg-yellow-500 hover:bg-yellow-600 
                text-gray-900 font-bold 
                px-8 py-3 rounded-lg
                transition-all duration-300
                transform hover:scale-105
                shadow-lg hover:shadow-yellow-500/30
                flex items-center
              ">
                <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 mr-2" viewBox="0 0 20 20" fill="currentColor">
                  <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm1-11a1 1 0 10-2 0v2H7a1 1 0 100 2h2v2a1 1 0 102 0v-2h2a1 1 0 100-2h-2V7z" clipRule="evenodd" />
                </svg>
                Mua vé
              </button>

              {/* Nút Xem Trailer */}
              {movie.trailer && (
                <button 
                  onClick={() => setShowTrailer(true)}
                  className="
                    bg-red-600 hover:bg-red-700 
                    text-white font-bold 
                    px-8 py-3 rounded-lg
                    transition-all duration-300
                    transform hover:scale-105
                    shadow-lg hover:shadow-red-500/30
                    flex items-center
                  "
                >
                  <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5 mr-2" viewBox="0 0 20 20" fill="currentColor">
                    <path fillRule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM9.555 7.168A1 1 0 008 8v4a1 1 0 001.555.832l3-2a1 1 0 000-1.664l-3-2z" clipRule="evenodd" />
                  </svg>
                  Xem Trailer
                </button>
              )}
            </div>
          </div>
        </div>
      </div>

      {/* Modal Trailer - Hiển thị phủ lên trên */}
      {showTrailer && movie.trailer && (
        <div className="fixed inset-0 bg-black bg-opacity-90 z-50 flex items-center justify-center p-4">
          <div className="w-full max-w-6xl h-[80vh] relative">
            <button 
              onClick={() => setShowTrailer(false)}
              className="absolute -top-12 right-0 text-white text-2xl hover:text-red-500"
            >
              ✕ Đóng
            </button>
            <iframe
              src={`https://www.youtube.com/embed/${getYouTubeId(movie.trailer)}?autoplay=1&mute=1`}
              className="w-full h-full rounded-lg"
              allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
              allowFullScreen
            />
          </div>
        </div>
      )}
    </div>
  );
};

export default MovieDetail;