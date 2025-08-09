import { useContext, useState } from "react";
import { AuthContext } from "../context/AuthContext";
import api from "../api/axios";
import { useNavigate } from "react-router-dom";
import { Card, Form, Button, Container } from "react-bootstrap";

export default function Login() {
  const { login } = useContext(AuthContext);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const res = await api.post("/users/login", { email, password });
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
    <Container
      className="d-flex justify-content-center align-items-center"
      style={{ minHeight: "100vh" }}
    >
      <Card style={{ width: "100%", maxWidth: "400px" }} className="shadow">
        <Card.Body>
          <h3 className="text-center mb-4">Đăng nhập</h3>
          <Form onSubmit={handleLogin}>
            <Form.Group className="mb-3" controlId="formEmail">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="email"
                placeholder="Nhập email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
                autoComplete="true"
              />
            </Form.Group>

            <Form.Group className="mb-3" controlId="formPassword">
              <Form.Label>Mật khẩu</Form.Label>
              <Form.Control
                type="password"
                placeholder="Nhập mật khẩu"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </Form.Group>

            <Button variant="primary" type="submit" className="w-100">
              Đăng nhập
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </Container>
  );
}