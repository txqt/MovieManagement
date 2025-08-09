import { useContext, useState } from "react";
import { AuthContext } from "../context/AuthContext";
import api from "../api/axios";
import { useNavigate } from "react-router-dom";

export default function Register() {
  const { login } = useContext(AuthContext);
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      const res = await api.post("/auth/register", { username, password });
      login(res.data.token);
      navigate("/profile");
    } catch (err) {
      alert("Register failed");
    }
  };

  return (
    <form onSubmit={handleRegister}>
      <h2>Register</h2>
      <input value={username} onChange={(e) => setUsername(e.target.value)} placeholder="Username" />
      <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" placeholder="Password" />
      <button type="submit">Register</button>
    </form>
  );
}