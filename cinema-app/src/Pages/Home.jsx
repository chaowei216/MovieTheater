import MovieCard from "../Components/MovieCard";
import { Link } from "react-router-dom";
import { nowShowingMovies, comingSoonMovies } from "../data/movieData"
import { Swiper, SwiperSlide } from 'swiper/react';
import { Autoplay, Navigation, EffectCreative } from 'swiper/modules';
import { motion } from 'framer-motion';
import 'swiper/css';
import 'swiper/css/navigation';
import 'swiper/css/effect-creative';


const Home = () => {
  return (
    <div className="bg-gray-900 text-white min-h-screen">

      <div className="h-96 bg-gradient-to-r from-purple-900 to-blue-800 flex items-center justify-center">
        <h1 className="text-4xl md:text-5xl font-bold text-center">
          Trải nghiệm điện ảnh đỉnh cao
        </h1>
      </div>

      {/* Phim đang chiếu */}
      <section className="container mx-auto py-12 px-4 relative">
        <div className="flex justify-between items-center mb-6">
          <motion.h2
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            transition={{ duration: 0.5 }}
            className="text-2xl font-bold text-yellow-400 uppercase"
          >
            Phim đang chiếu
          </motion.h2>
          <Link
            to="/now-showing"
            className="flex items-center text-yellow-400 hover:text-yellow-300 transition-colors"
          >
            <span className="mr-2">Xem tất cả</span>
            <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
              <path fillRule="evenodd" d="M10.293 5.293a1 1 0 011.414 0l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414-1.414L12.586 11H5a1 1 0 110-2h7.586l-2.293-2.293a1 1 0 010-1.414z" clipRule="evenodd" />
            </svg>
          </Link>
        </div>

        <Swiper
          modules={[Autoplay, Navigation, EffectCreative]}
          navigation={{
            nextEl: '.next-now-showing',
            prevEl: '.prev-now-showing',
          }}
          autoplay={{
            delay: 5000,
            disableOnInteraction: false,
            waitForTransition: false,
          }}
          effect="creative"
          creativeEffect={{
            prev: {
              shadow: true,
              translate: ['-120%', 0, -500],
            },
            next: {
              shadow: true,
              translate: ['120%', 0, -500],
            },
          }}
          loop={true}
          slidesPerView={2}           // 👈 Hiển thị 2 phim
          slidesPerGroup={1}          // 👈 Chuyển 1 phim mỗi lần
          spaceBetween={30}
          breakpoints={{
            640: {
              slidesPerView: 2,
              slidesPerGroup: 1,
            },
            768: {
              slidesPerView: 2,
              slidesPerGroup: 1,
            },
            1024: {
              slidesPerView: 2,
              slidesPerGroup: 1,
            },
          }}
          className="relative group"
        >

{nowShowingMovies.map((movie) => (
  <SwiperSlide key={movie.id}>
    <motion.div
      whileHover={{ scale: 1.05 }}
      className="overflow-hidden rounded-lg shadow-lg"
    >
      <MovieCard movie={movie} showOverlay={true} />
    </motion.div>
  </SwiperSlide>
))}
          {/* Custom Navigation Buttons */}
          <button className="prev-now-showing absolute left-0 top-1/2 z-10 -translate-y-1/2 bg-black/50 text-yellow-400 w-10 h-10 rounded-full flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 19l-7-7 7-7" />
            </svg>
          </button>
          <button className="next-now-showing absolute right-0 top-1/2 z-10 -translate-y-1/2 bg-black/50 text-yellow-400 w-10 h-10 rounded-full flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 5l7 7-7 7" />
            </svg>
          </button>
        </Swiper>
      </section>
      <section className="container mx-auto py-8 px-4 relative">
        <div className="flex justify-between items-center mb-6">
          <motion.h2
            initial={{ opacity: 0, x: -20 }}
            animate={{ opacity: 1, x: 0 }}
            transition={{ duration: 0.5 }}
            className="text-2xl font-bold text-yellow-400 uppercase"
          >
            Phim sắp chiếu
          </motion.h2>
          <Link
            to="/coming-soon"
            className="flex items-center text-yellow-400 hover:text-yellow-300 transition-colors"
          >
            <span className="mr-2">Xem tất cả</span>
            <svg className="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
              <path fillRule="evenodd" d="M10.293 5.293a1 1 0 011.414 0l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414-1.414L12.586 11H5a1 1 0 110-2h7.586l-2.293-2.293a1 1 0 010-1.414z" clipRule="evenodd" />
            </svg>
          </Link>
        </div>

        <Swiper
          modules={[Autoplay, Navigation, EffectCreative]}
          navigation={{
            nextEl: '.next-coming-soon',
            prevEl: '.prev-coming-soon',
          }}
          autoplay={{
            delay: 5000,
            disableOnInteraction: false,
          }}
          effect="creative"
          creativeEffect={{
            prev: {
              shadow: true,
              translate: ['-120%', 0, -500],
            },
            next: {
              shadow: true,
              translate: ['120%', 0, -500],
            },
          }}
          loop={true}
          slidesPerView={2} 
          slidesPerGroup={1}  
          spaceBetween={30}
          breakpoints={{
            640: {
              slidesPerView: 2,
              slidesPerGroup: 1,
            },
            768: {
              slidesPerView: 2,
              slidesPerGroup: 1,
            },
            1024: {
              slidesPerView: 2,
              slidesPerGroup: 1,
            },
          }}
          className="relative group"
        >
          {comingSoonMovies.map((movie) => (
            <SwiperSlide key={movie.id}>
              <motion.div
                whileHover={{ scale: 1.05 }}
                className="relative overflow-hidden rounded-lg shadow-lg"
              >
                <MovieCard movie={movie} />
                <div className="absolute inset-0 bg-gradient-to-t from-black/80 to-transparent opacity-0 hover:opacity-100 transition-opacity flex items-end p-4">
                  <button className="w-full bg-yellow-400 text-gray-900 py-2 rounded font-bold hover:bg-yellow-300 transition-colors">
                    XEM CHI TIẾT
                  </button>
                </div>
              </motion.div>
            </SwiperSlide>
          ))}

          {/* Custom Navigation Buttons */}
          <button className="prev-coming-soon absolute left-0 top-1/2 z-10 -translate-y-1/2 bg-black/50 text-yellow-400 w-10 h-10 rounded-full flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M15 19l-7-7 7-7" />
            </svg>
          </button>
          <button className="next-coming-soon absolute right-0 top-1/2 z-10 -translate-y-1/2 bg-black/50 text-yellow-400 w-10 h-10 rounded-full flex items-center justify-center opacity-0 group-hover:opacity-100 transition-opacity">
            <svg className="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M9 5l7 7-7 7" />
            </svg>
          </button>
        </Swiper>
      </section>
      {/* Phim sắp chiếu (tương tự) */}
    </div>
  );
};

export default Home;