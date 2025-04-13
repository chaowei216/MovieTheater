import { Link } from "react-router-dom";

const MovieCard = ({ movie }) => {
  return (
    <div className="bg-gray-800 rounded-lg overflow-hidden shadow-lg hover:scale-105 transition-transform duration-300">
      <img 
        src={movie.poster} 
        alt={movie.title} 
        className="w-full h-64 object-cover"
      />
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
    </div>
  );
};

export default MovieCard;