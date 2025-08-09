import { useContext, useEffect, useState } from "react";
import api from "../api/axios";
import { AuthContext } from "../context/AuthContext";

export default function Profile() {
  const { auth, logout } = useContext(AuthContext);
  const [user, setUser] = useState(null);

  useEffect(() => {
    api.get("/user")
      .then((r) => setUser(r.data))
      .catch((e) => {
        console.error(e);
      });
  }, []);

  return (
    <div>
      <h2>Profile</h2>
      <div>Logged in as: {auth ? "yes" : "no"}</div>
      <button onClick={logout}>Logout</button>
      <pre>{user ? JSON.stringify(user, null, 2) : "No user data"}</pre>
    </div>
  );
}