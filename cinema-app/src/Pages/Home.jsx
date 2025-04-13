import MovieCard from "../Components/MovieCard";
import { Link } from "react-router-dom";

// Dummy data (sẽ thay bằng API sau)
const nowShowingMovies = [
  {
    id: 1,
    title: "Dune: Part Two",
    genre: "Sci-Fi, Adventure",
    rating: 8.9,
    poster: "https://via.placeholder.com/300x450?text=Dune+2",
  },
  // Thêm phim khác...
];
const comingSoonMovies = [
    {
      id: 101,
      title: "Dune: Part Two",
      genre: "Sci-Fi, Adventure",
      rating: 0,
      poster: "https://via.placeholder.com/300x450?text=Dune+2",
    },
    // Thêm phim khác...
  ];
  
const Home = () => {
  return (
    <div className="bg-gray-900 text-white min-h-screen">
      {/* Banner Hero */}
      <div className="h-96 bg-gradient-to-r from-purple-900 to-blue-800 flex items-center justify-center">
        <h1 className="text-4xl md:text-5xl font-bold text-center">
          Trải nghiệm điện ảnh đỉnh cao
        </h1>
      </div>

      {/* Phim đang chiếu */}
      <section className="container mx-auto py-12 px-4">
        <div className="flex justify-between items-center mb-6">
          <h2 className="text-2xl font-bold">PHIM ĐANG CHIẾU</h2>
          <Link 
            to="/now-showing" 
            className="text-yellow-400 hover:underline"
          >
            Xem tất cả →
          </Link>
        </div>
        <div className="grid grid-cols-2 md:grid-cols-4 gap-4">
          {nowShowingMovies.slice(0, 4).map((movie) => (
            <MovieCard key={movie.id} movie={movie} />
          ))}
        </div>
      </section>
      <section className="container mx-auto py-8 px-4">
                <h2 className="text-2xl font-bold mb-6">PHIM SẮP CHIẾU</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 gap-6">
                    {comingSoonMovies.map((movie)=>(
                        <MovieCard key={movie.id} movie={movie}/>
                    ))}
                </div>
            </section>
      {/* Phim sắp chiếu (tương tự) */}
    </div>
  );
};

export default Home;