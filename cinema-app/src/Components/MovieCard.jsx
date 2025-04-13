import { Link } from "react-router-dom";

const MovieCard = ({movie}) => {
    return (
        <div className="bg-gray-800 rounded-lg overflow-hidden shadow-lg hover:scale-105 transition-transform">
            <img 
            src={movie.poster}
            alt={movie.title}
            className="w-full h-64 object-cover"
            />
            <div className="p-4">
                <h3 className="text-white font-bold text-lg">{movie.title}</h3>
                <p className="text-gray-400">{movie.genre}</p>
                <div className="flex justify-between items-center mt-2">
                    <span className="text-yellow-400">⭐{movie.rating}</span>
                    <Link to={`/movie/${movie.id}`}>
                        Chi tiết phim
                    </Link>
                </div>
            </div>
        </div>
    )
}
export default MovieCard;