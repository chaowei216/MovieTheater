import { tr } from "framer-motion/client";

export const nowShowingMovies = [
  {
    id: 1,
    title: "Dune: Part Two",
    genre: "Sci-Fi, Adventure",
    rating: 8.9,
    poster: "https://m.media-amazon.com/images/M/MV5BN2QyZGU4ZDctOWMzMy00NTc5LThlOGQtODhmNDI1NmY5YzAwXkEyXkFqcGdeQXVyMDM2NDM2MQ@@._V1_FMjpg_UX1000_.jpg",
     trailer:"https://www.youtube.com/watch?v=Way9Dexny3w",
     description:"Là một bộ phim điện ảnh Mỹ thuộc thể loại sử thi – khoa học viễn tưởng ra mắt vào năm 2024 do Denis Villeneuve làm đạo diễn, viết kịch bản và đồng sản xuất. Phim là phần hậu truyện của Dune: Hành tinh cát (2021) và là phần thứ hai trong hai phần chuyển thể của bộ tiểu thuyết Dune năm 1965 của tác giả Frank Herbert. Timothée Chalamet, Zendaya, Rebecca Ferguson, Josh Brolin, Stellan Skarsgård, Dave Bautista, Stephen McKinley Henderson, Charlotte Rampling và Javier Bardem đều tiếp tục trở lại với vai diễn của họ trong phần đầu tiên, cùng với dàn diễn viên mới tham gia bao gồm Florence Pugh, Austin Butler, Christopher Walken và Léa Seydoux.",
     cast:["Timothée Chalamet", "Zendaya", "Rebecca Ferguson", "Josh Brolin", "Stellan Skarsgård", "Dave Bautista", "Stephen McKinley Henderson", "Charlotte Rampling", "Javier Bardem"],
     director:"Denis Villeneuve",
  duration:"155 phút",
  releaseDate:"15/11/2024",     
  },
  {
    id: 2,
    title: "The Batman",
    genre: "Action, Crime, Drama",
    rating: 7.9,
    poster: "https://m.media-amazon.com/images/M/MV5BMDdmMTBiNTYtMDIzNi00NGVlLWIzMDYtZTk3MTQ3NGQxZGEwXkEyXkFqcGdeQXVyMzMwOTU5MDk@._V1_.jpg",
    trailer:"https://www.youtube.com/watch?v=mqqft2x_Aa4",
    description:"Là một bộ phim siêu anh hùng của Mỹ năm 2022 dựa trên nhân vật cùng tên của DC Comics. Được sản xuất bởi DC Films, Dylan Clark Productions và Matt Reeves Productions, và được phân phối bởi Warner Bros. Pictures, đây là bộ phim thứ ba về Batman do Matt Reeves đạo diễn và đồng viết kịch bản với Peter Craig.",
    cast:["Robert Pattinson", "Zoë Kravitz", "Paul Dano", "Jeffrey Wright", "John Turturro", "Peter Sarsgaard", "Andy Serkis"],
    director:"Matt Reeves",
    duration:"155 phút",
    releaseDate:"4/3/2022", 
  },
  {
    id: 3,
    title: "Everything Everywhere All at Once",
    genre: "Action, Adventure, Comedy",
    rating: 8.8,
    poster: "https://m.media-amazon.com/images/M/MV5BYTdiOTIyZTQtNmQ1OS00NjZlLWIyMTgtYzk5Y2M3ZDVmMDk1XkEyXkFqcGdeQXVyMTAzMDg4NzU0._V1_.jpg",
    trailer:"https://www.youtube.com/watch?v=wxN1T1uxQ2g",
    description:"Là một bộ phim điện ảnh hài hành động khoa học viễn tưởng của Mỹ năm 2022 do Daniel Kwan và Daniel Scheinert viết kịch bản và đạo diễn. Phim có sự tham gia của Michelle Yeoh, Stephanie Hsu, Jamie Lee Curtis, Ke Huy Quan và James Hong.",
    cast:["Michelle Yeoh", "Stephanie Hsu", "Jamie Lee Curtis", "Ke Huy Quan", "James Hong"],
    director:"Daniel Kwan, Daniel Scheinert",
    duration:"139 phút",
    releaseDate:"11/3/2022",
  },
  {
    id: 4,
    title: "Top Gun: Maverick",
    genre: "Action, Drama",
    rating: 8.3,
    poster: "https://m.media-amazon.com/images/M/MV5BZWYzOGEwNTgtNWU3NS00ZTQ0LWJkODUtMmVhMjIwMjA1ZmQwXkEyXkFqcGdeQXVyMjkwOTAyMDU@._V1_.jpg",
    trailer:"https://www.youtube.com/watch?v=qSqVVswa420",
    description:"Là một bộ phim hành động quân sự của Mỹ năm 2022 do Joseph Kosinski đạo diễn, với kịch bản của Ehren Kruger, Eric Warren Singer và Christopher McQuarrie. Đây là phần tiếp theo của bộ phim Top Gun (1986) và có sự tham gia của Tom Cruise, Miles Teller, Jennifer Connelly, Jon Hamm, Glen Powell, Lewis Pullman và Ed Harris.",
    cast:["Tom Cruise", "Miles Teller", "Jennifer Connelly", "Jon Hamm", "Glen Powell", "Lewis Pullman", "Ed Harris"],
    director:"Joseph Kosinski",
    duration:"131 phút",
    releaseDate:"27/5/2022",

  },
  {
    id: 5,
    title: "Avatar: The Way of Water",
    genre: "Sci-Fi, Adventure",
    rating: 7.6,
    poster: "https://m.media-amazon.com/images/M/MV5BYjhiNjBlODctY2ZiOC00YjVlLWFlNzAtNTVhNzM1YjI1NzMxXkEyXkFqcGdeQXVyMjQxNTE1MDA@._V1_FMjpg_UX1000_.jpg",
    trailer:"https://www.youtube.com/watch?v=d9MyW72ELq0",
    description:"Là một bộ phim khoa học viễn tưởng năm 2022 của Mỹ do James Cameron đạo diễn, viết kịch bản và sản xuất. Đây là phần tiếp theo của Avatar (2009) và là phần thứ hai trong loạt phim Avatar.",
    cast:["Sam Worthington", "Zoe Saldana", "Sigourney Weaver", "Stephen Lang", "Kate Winslet"],
    director:"James Cameron",
    duration:"192 phút",
    releaseDate:"16/12/2022",

  },
  {
    id: 6,
    title: "Black Panther: Wakanda Forever",
    genre: "Action, Adventure, Drama",
    rating: 9.5,
    poster: "https://m.media-amazon.com/images/M/MV5BNTM4NjIxNmEtYWE5NS00NDczLTkyNWQtYThhNmQyZGQzMjM0XkEyXkFqcGdeQXVyODk4OTc3MTY@._V1_FMjpg_UX1000_.jpg",
    trailer:"https://www.youtube.com/watch?v=_Z3QKkl1WyM",
    description:"Là một bộ phim siêu anh hùng của Mỹ năm 2022 dựa trên nhân vật cùng tên của Marvel Comics. Đây là phần tiếp theo của Black Panther (2018) và là bộ phim thứ 30 trong Vũ trụ Điện ảnh Marvel (MCU).",
    cast:["Chadwick Boseman", "Letitia Wright", "Lupita Nyong'o", "Danai Gurira", "Winston Duke"],
    director:"Ryan Coogler",
    duration:"161 phút",
    releaseDate:"11/11/2022",
    
  },
  {
    id: 7,
    title: "John Wick: Chapter 4",
    genre: "Action, Crime, Thriller",
    rating: 8.0,
    poster: "https://m.media-amazon.com/images/M/MV5BMDExZGMyOTMtMDgyYi00NGIwLWJhMTEtOTdkZGFjNmZiMTEwXkEyXkFqcGdeQXVyMjM4NTM5NDY@._V1_FMjpg_UX1000_.jpg",
    trailer:"https://www.youtube.com/watch?v=qEVUtrk8_B4",
    description:"Là một bộ phim hành động của Mỹ năm 2023 do Chad Stahelski đạo diễn và Shay Hatten và Michael Finch viết kịch bản. Đây là phần thứ tư trong loạt phim John Wick, với sự tham gia của Keanu Reeves trong vai chính.",
    cast:["Keanu Reeves", "Donnie Yen", "Bill Skarsgård", "Shamier Anderson", "Lance Reddick"],
    director:"Chad Stahelski",
    duration:"169 phút",
    releaseDate:"24/3/2023",
  },
  {
    id: 8,
    title: "Oppenheimer",
    genre: "Biography, Drama, History",
    rating: 8.6,
    poster: "https://m.media-amazon.com/images/M/MV5BMDBmYTZjNjUtN2M1MS00MTQ2LTk2ODgtNzc2M2QyZGE5NTVjXkEyXkFqcGdeQXVyNzAwMjU2MTY@._V1_FMjpg_UX1000_.jpg",
    trailer:"https://www.youtube.com/watch?v=bK6ldnjE3Y0",
    description:"Là một bộ phim tiểu sử lịch sử của Mỹ năm 2023 do Christopher Nolan viết kịch bản, đạo diễn và sản xuất. Phim dựa trên cuốn sách American Prometheus: The Triumph and Tragedy of J. Robert Oppenheimer của Kai Bird và Martin J. Sherwin.",
    cast:["Cillian Murphy", "Emily Blunt", "Matt Damon", "Robert Downey Jr.", "Florence Pugh"],
    director:"Christopher Nolan",
    duration:"180 phút",
    releaseDate:"21/7/2023",
  },
  {
    id: 9,
    title: "Barbie",
    genre: "Adventure, Comedy, Fantasy",
    rating: 7.3,
    poster: "https://m.media-amazon.com/images/M/MV5BNjU3N2QxNzYtMjk1NC00MTc4LTk1NTQtMmUxNTljM2I0NDA5XkEyXkFqcGdeQXVyODE5NzE3OTE@._V1_FMjpg_UX1000_.jpg",
    trailer:"https://www.youtube.com/watch?v=pBk4NYhWNMM",
    description:"Là một bộ phim hài giả tưởng của Mỹ năm 2023 do Greta Gerwig viết kịch bản và đạo diễn. Phim có sự tham gia của Margot Robbie trong vai Barbie và Ryan Gosling trong vai Ken.",
    cast:["Margot Robbie", "Ryan Gosling", "America Ferrera", "Kate McKinnon", "Issa Rae"],
    director:"Greta Gerwig",
    duration:"114 phút",
    releaseDate:"21/7/2023",
    
  }
];

export const comingSoonMovies = [
  {
    id: 101,
    title: "Deadpool & Wolverine",
    genre: "Action, Adventure, Comedy",
    rating: 0,
    poster: "https://disney.images.edge.bamgrid.com/ripcut-delivery/v1/variant/disney/9f1d072b-1928-4b19-aa67-dc199128e66e?/scale?width=1200&aspectRatio=1.78&format=webp",
    trailer:"https://www.youtube.com/watch?v=Way9Dexny3w",
  },
  {
    id: 102,
    title: "Furiosa: A Mad Max Saga",
    genre: "Action, Adventure, Sci-Fi",
    rating: 0,
    poster: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCLdilVB55Bqzzn1aoYTL3_YDoXjmYSJ5T6g&s",
  },
  {
    id: 103,
    title: "Kingdom of the Planet of the Apes",
    genre: "Action, Adventure, Sci-Fi",
    rating: 0,
    poster: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS2f8URZAfIHpBDYmsPVj_KCv0E2FjPmvg9Bg&s",
  },
  {
    id: 104,
    title: "A Quiet Place: Day One",
    genre: "Drama, Horror, Sci-Fi",
    rating: 0,
    poster: "https://m.media-amazon.com/images/M/MV5BMDdjZTljZWMtMDIwNi00MTA5LTkxZmItNmY0NDA3ZDM0N2M2XkEyXkFqcGc@._V1_.jpg",
  },
  {
    id: 105,
    title: "Inside Out 2",
    genre: "Animation, Adventure, Comedy",
    rating: 0,
    poster: "https://iguov8nhvyobj.vcdn.cloud/media/catalog/product/cache/1/image/c5f0a1eff4c394a251036189ccddaacd/1/0/1080x1350-insideout.jpg",
  },
  {
    id: 106,
    title: "Gladiator 2",
    genre: "Action, Adventure, Drama",
    rating: 0,
    poster: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWyjfXcFq62vcMNOrCwo7qbQNk3hAlJ-2vEQ&s",
  },
  {
    id: 107,
    title: "Joker: Folie à Deux",
    genre: "Crime, Drama, Musical",
    rating: 0,
    poster: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTRekiR1eIuNz3aZoYzWwd7opzRSDA2tOw6Jw&s",
  },
  {
    id: 108,
    title: "Venom 3",
    genre: "Action, Sci-Fi",
    rating: 0,
    poster: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQNq4joQw_a4JQDuT1e-OfskWPl5401OErqgg&s",
  },
  {
    id: 109,
    title: "Kraven the Hunter",
    genre: "Action, Adventure, Thriller",
    rating: 0,
    poster: "https://i.ytimg.com/vi/I8gFw4-2RBM/maxresdefault.jpg",
  }
];