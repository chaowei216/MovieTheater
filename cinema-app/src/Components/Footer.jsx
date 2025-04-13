const Footer = () => {
    return (
        <footer className="bg-gray-800 text-white py-8">
            <div className="container mx-auto px-4">
                <div className="flex flex-col md:flex-row justify-between">
                    <div className="mb-4">
                        <h3 className="text-xl font-bold mb-2">MOVIETHEATER</h3>
                        <p>Rạp chiếu phim chất lượng cao</p>
                    </div>
                    <h4 className="font-bold mb-2">Liên hệ</h4>
                    <p>Email: contact@movietheater.com</p>
                    <p>Điện thoại: 0123 456 789</p>
                </div>
                <div className="mt-8 text-center text-gray-400">
                    <p>@ 2025 MovieTheater. All right Reserved</p>
                </div>
            </div>
        </footer>
    )
}
export default Footer;