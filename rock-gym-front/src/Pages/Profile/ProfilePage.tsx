import React, { useCallback, useEffect, useState } from "react";
import { Col, Button, Row, Container, Card, Form } from "react-bootstrap";
import jwtDecode from "jwt-decode";
import { useNavigate } from "react-router-dom";
import { ProfileTypes } from "./ProfileTypes";

const ProfilePage = () => {
  const [patientCard, setPatientCard] = useState<ProfileTypes>();
  const navigate = useNavigate();

  return (
    
    <div style={{ backgroundImage: `url('${process.env.PUBLIC_URL}/Photos/allpagesbackground.png')` }}>
      <Container >
        <Row className="vh-100 d-flex justify-content-center align-items-center">
          <Col md={8} lg={6} xs={12}>
            <div className="border border-3 border-dark"></div>
            <Card className="shadow">
              <Card.Body>
                <div className="mb-3 mt-md-4">
                  <h2 className="fw-bold mb-2 text-uppercase ">Paskyra</h2>
                  <div className="mb-3">
                    <Form>
                    <Form.Group className="mb-3" controlId="formBasicName">
                        <Form.Label className="text-center">
                         Vardas
                        </Form.Label>
                        <Form.Control type="text"/>
                      </Form.Group>
                      <Form.Group className="mb-3" controlId="formBasicSurname">
                        <Form.Label className="text-center">
                         Pavardė
                        </Form.Label>
                        <Form.Control type="text"/>
                      </Form.Group>

                     <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label className="text-center">
                          El. paštas
                        </Form.Label>
                        <Form.Control type="email"/>
                      </Form.Group>

                      <Form.Group className="mb-3" controlId="formBasicAge">
                        <Form.Label className="text-center">
                          Amžius
                        </Form.Label>
                        <Form.Control type="number" min="0" step="1"/>
                      </Form.Group>
                      <Form.Group className="mb-3" controlId="formBasicPersonalNumber">
                        <Form.Label className="text-center">
                          Asmens kodas
                        </Form.Label>
                        <Form.Control type="text"/>
                      </Form.Group>
                      <div className="d-grid">
                        <Button variant="dark" type="submit">
                          Išsaugoti
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
export { ProfilePage };