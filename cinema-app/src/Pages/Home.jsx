import Header from "../Components/Headers";
import Footer from "../Components/Footer";
import MovieCard from "../Components/MovieCard";
const nowShowingMovies = [
    {
        id:1,
        title:"Dune: Part Two",
        genre:"Sci-fi, Adventure",
        rating:8.9,
        poster:"https://example.com/dune.jpg",

    },
]
const comingSoonMovies = [
    {
        id: 101,
        title: "Avenger: Secret Wars",
        genre:"Action, Superhero",
        rating:0,
        poster:"https://example.com/avenger.jpg",
    }
]
const Home = () => {
    return (
        <div className="min-h-screen bg-gray-900 text-white">
            <Header/>
            {/*Banner Slide*/}
            <div className="h-96 bg-gradient-to-r from-purple-900 to-blue-800 flex items-center justify-center">
                <h1 className="text-4xl font-bold">CHÀO MỪNG ĐẾN VỚI MOVIETHEATER</h1>
            </div>
            <section className="container mx-auto py-8 px-4">
                <h2 className="text-2xl font-bold mb-6">PHIM ĐANG CHIẾU</h2>
                <div className="grid grid-cols-1 md:grid-cols-3 lg:grid-cols-4 gap-6">
                    {nowShowingMovies.map((movie)=> (
                        <MovieCard key={movie.id} movie={movie}/>
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
            <Footer/>
        </div>
    )
}