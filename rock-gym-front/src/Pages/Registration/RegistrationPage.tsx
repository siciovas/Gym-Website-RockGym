import React from "react";
import { Col, Button, Row, Container, Card, Form } from "react-bootstrap";

const RegistrationPage = () => {
  return (
    <div style={{ backgroundImage: `url('${process.env.PUBLIC_URL}/Photos/allpagesbackground.png')` }}>
      <Container>
        <Row className="vh-100 d-flex justify-content-center align-items-center">
          <Col md={8} lg={6} xs={12}>
            <div className="border border-3 border-dark"></div>
            <Card className="shadow">
              <Card.Body>
                <div className="mb-3 mt-md-4">
                  <h2 className="fw-bold mb-2 text-uppercase ">Rock Gym</h2>
                  <p className=" mb-5">Tapk mūsų šeimos nariu!</p>
                  <div className="mb-3">
                    <Form>
                      <Form.Group className="mb-3" controlId="formName">
                        <Form.Label className="text-center">Vardas</Form.Label>
                        <Form.Control type="text" placeholder="Jūsų vardas" />
                      </Form.Group>

                      <Form.Group className="mb-3" controlId="formSurname">
                        <Form.Label className="text-center">Pavardė</Form.Label>
                        <Form.Control type="text" placeholder="Jūsų pavardė" />
                      </Form.Group>

                      <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="text-center">
                          El. paštas
                        </Form.Label>
                        <Form.Control
                          type="email"
                          placeholder="Įveskite el. paštą"
                        />
                      </Form.Group>

                      <Form.Group
                        className="mb-3"
                        controlId="formBasicPassword"
                      >
                        <Form.Label>Slaptažodis</Form.Label>
                        <Form.Control
                          type="password"
                          placeholder="Įveskite slaptažodį"
                        />
                      </Form.Group>

                      <Form.Group
                        className="mb-3"
                        controlId="formBasicCheckbox"
                      ></Form.Group>
                      <div className="d-grid">
                        <Button variant="dark" type="submit">
                          Registruotis
                        </Button>
                      </div>
                    </Form>
                  </div>
                </div>
              </Card.Body>
            </Card>
          </Col>
        </Row>
      </Container>
    </div>

  );
};
export { RegistrationPage };
