import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

function Home() {
  return <h1 className="text-center">Welcome to the Home Page!</h1>;
}

function About() {
  return <h1 className="text-center">This is the About Page</h1>;
}

function App() {
  return (
    <Router>
      <div className="min-h-screen bg-gray-100 p-8">
        <nav className="mb-6">
          <ul className="flex space-x-4">
            <li><a href="/" className="text-blue-500 hover:underline">Home</a></li>
            <li><a href="/about" className="text-blue-500 hover:underline">About Hello</a></li>
            <li><a href="/about" className="text-blue-500 hover:underline">About Hello</a></li>
          </ul>
        </nav>

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/about" element={<About />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
