import {Route, Routes} from "react-router-dom";
import About from "./pages/About.tsx";
import Login from "./pages/Login.tsx";
import Register from "./pages/Register.tsx";
import Home from "./pages/Home.tsx";
import Profile from "./pages/Profile.tsx";
import Dashboard from "./pages/Dashboard.tsx";
import CreateCampaign from "./pages/CreateCampaign.tsx";

function App() {

  return (
      <>
          <div className="ambient-glow glow-1"></div>
          <div className="ambient-glow glow-2"></div>
          <div className="ambient-glow glow-3"></div>
        <Routes>
            {/* public routes */}
            <Route path="/" element={<Home />} />
            <Route path="/about" element={<About />} />
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            {/* private routes */}
            <Route path="/dashboard" element={<Dashboard />} />
            <Route path="/create-campaign" element={<CreateCampaign />} />
            <Route path="/profile" element={<Profile/>} />

        </Routes>
      </>
  )
}

export default App
