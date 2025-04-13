import { useParams } from "react-router-dom";
import { comingSoonMovies, nowShowingMovies } from "../data/movieData";

const MovieDetail = () => {
  const { id } = useParams(); // Lấy ID từ URL

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
            className="w-full md:w-1/3 rounded-lg"
          />
          <div>
            <h1 className="text-3xl font-bold mb-2">{movie.title}</h1>
            <div className="flex items-center space-x-4 mb-4">
              <span className="text-yellow-400">⭐ {movie.rating}</span>
              <span>{movie.genre}</span>
              <span>{movie.duration || "120 phút"}</span>
            </div>
            <p className="text-gray-300">{movie.description || "Mô tả chưa cập nhật."}</p>
            <button className="mt-6 bg-yellow-500 hover:bg-yellow-600 text-black px-6 py-2 rounded-lg">
              Mua vé
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default MovieDetail;
