import { useParams } from "react-router-dom";

const MovieDetail = () => {
  const { id } = useParams(); // Lấy ID từ URL

  // Mock data (sẽ thay bằng API fetch sau)
  const movie = {
    id: 1,
    title: "Dune: Part Two",
    genre: "Sci-Fi, Adventure",
    rating: 8.9,
    duration: "2h 46m",
    poster: "https://via.placeholder.com/800x500?text=Dune+2+Poster",
    description: "Câu chuyện tiếp theo về cuộc phiêu lưu của Paul Atreides..."
  };

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
              <span>{movie.duration}</span>
            </div>
            <p className="text-gray-300">{movie.description}</p>
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