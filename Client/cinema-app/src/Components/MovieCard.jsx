import { Link } from "react-router-dom";

const MovieCard = ({ movie, showOverlay = false }) => {
  return (
    <div className="bg-gray-800 rounded-lg overflow-hidden shadow-lg transition-transform duration-300 hover:scale-105">
      <div className="relative group">
        <img
          src={movie.poster}
          alt={movie.title}
          className="object-cover w-full h-[400px] transition duration-300 group-hover:scale-105 group-hover:brightness-110"
        />

        {showOverlay && (
          <div className="absolute inset-0 bg-gradient-to-t from-black/80 to-transparent opacity-0 group-hover:opacity-100 transition-opacity flex flex-col justify-end p-4 space-y-2">
            <button className="w-full bg-yellow-400 text-black py-2 rounded font-bold hover:bg-yellow-300 transition">
              MUA VÉ
            </button>
            <Link
              to={`/movie/${movie.id}`}
              className="w-full text-center bg-white text-black py-2 rounded font-bold hover:bg-gray-200 transition"
            >
              XEM CHI TIẾT
            </Link>
          </div>
        )}
      </div>

      {!showOverlay && (
        <div className="p-4">
          <h3 className="text-white font-bold text-lg truncate">{movie.title}</h3>
          <p className="text-gray-400 text-sm">{movie.genre}</p>
          <div className="flex justify-between items-center mt-3">
            <span className="text-yellow-400 text-sm">⭐ {movie.rating || "Coming"}</span>
            <Link
              to={`/movie/${movie.id}`}
              className="bg-yellow-500 hover:bg-yellow-600 text-black text-sm px-3 py-1 rounded transition-colors"
            >
              Chi tiết
            </Link>
          </div>
        </div>
      )}
    </div>
  );
};

export default MovieCard;
