import { useContext, useState } from "react";
import { AuthContext } from "../context/AuthContext";
import api from "../api/axios";
import { useNavigate } from "react-router-dom";
import { Card, Typography, Input, Button, Sheet, Stack } from "@mui/joy";

export default function Register() {
  const { login } = useContext(AuthContext);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();
    try {
      const res = await api.post("/auth/register", { email, password });

      login({
        tokenType: res.data.tokenType,
        accessToken: res.data.accessToken,
        expiresIn: res.data.expiresIn,
        refreshToken: res.data.refreshToken,
      });

      navigate("/profile");
    } catch (err) {
      console.error(err);
      alert("Đăng ký thất bại");
    }
  };

  return (
    <Sheet
      variant="outlined"
      sx={{
        width: 400,
        maxWidth: "100%",
        mx: "auto",
        mt: 8,
        p: 4,
        borderRadius: "sm",
        boxShadow: "md",
        display: "flex",
        flexDirection: "column",
      }}
      component="form"
      onSubmit={handleRegister}
    >
      <Typography
        level="h3"
        textAlign="center"
        mb={4}
      >
        Đăng ký
      </Typography>

      <Stack spacing={3}>
        <div>
          <Typography level="body1" htmlFor="email" mb={1}>
            Email
          </Typography>
          <Input
            id="email"
            type="email"
            placeholder="Nhập email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
            autoComplete="email"
            fullWidth
          />
        </div>

        <div>
          <Typography level="body1" htmlFor="password" mb={1}>
            Mật khẩu
          </Typography>
          <Input
            id="password"
            type="password"
            placeholder="Nhập mật khẩu"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
            fullWidth
          />
        </div>

        <Button type="submit" variant="solid" color="success" fullWidth>
          Đăng ký
        </Button>
      </Stack>
    </Sheet>
  );
}