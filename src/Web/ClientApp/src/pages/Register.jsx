import { useContext, useState } from "react";
import { AuthContext } from "../context/AuthContext";
import api from "../api/axios";
import { useNavigate } from "react-router-dom";
import { Card, Form, Button, Container } from "react-bootstrap";

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
    <Container
      className="d-flex justify-content-center align-items-center"
      style={{ minHeight: "100vh" }}
    >
      <Card style={{ width: "100%", maxWidth: "400px" }} className="shadow">
        <Card.Body>
          <h3 className="text-center mb-4">Đăng ký</h3>
          <Form onSubmit={handleRegister}>
            <Form.Group className="mb-3" controlId="formUsername">
              <Form.Label>Email</Form.Label>
              <Form.Control
                type="text"
                placeholder="Nhập email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
                required
                typeof="email"
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

            <Button variant="success" type="submit" className="w-100">
              Đăng ký
            </Button>
          </Form>
        </Card.Body>
      </Card>
    </Container>
  );
}