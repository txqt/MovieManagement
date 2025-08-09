import { useContext, useState } from "react";
import { AuthContext } from "../context/AuthContext";
import api from "../api/axios";
import { useNavigate } from "react-router-dom";

export default function Login() {
  const { login } = useContext(AuthContext);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const res = await api.post("/users/login", { email, password });
      console.log(res)
      login({
        tokenType: res.data.tokenType,
        accessToken: res.data.accessToken,
        expiresIn: res.data.expiresIn,
        refreshToken: res.data.refreshToken,
      });
      navigate("/profile");
    } catch (err) {
      console.error(err);
      alert("Login failed");
    }
  };

  return (
    <form onSubmit={handleLogin}>
      <h2>Login</h2>
      <input value={email} onChange={(e) => setEmail(e.target.value)} placeholder="email" />
      <input value={password} onChange={(e) => setPassword(e.target.value)} type="password" placeholder="Password" />
      <button type="submit">Login</button>
    </form>
  );
}