import React, { useState } from 'react';
import { Container, Card, Button, Form } from "react-bootstrap";
import Modal from 'react-bootstrap/Modal';
import { useNavigate } from 'react-router-dom';


const GroupTrainingsPage = () => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    const navigate = useNavigate();
    const NavigateToAllFeedbacks = () => {
        navigate('/gtfeedback')
    };
    return (
        <>
            <div className="d-flex" style={{ backgroundImage: `url('${process.env.PUBLIC_URL}/Photos/allpagesbackground.png')`, height: "100vh" }}>
                <Container >
                <div className="d-flex mt-2" style={{ gap: "10px", flexWrap:"wrap", justifyContent: "space-around" }}>
                    <Card className="shadow" style={{ width: "49%" }}>
                            <Card.Body>
                                <div className="mb-3 mt-md-4">
                                    <h2 className="fw-bold mb-2 text-uppercase ">CIRCLE TRAINING</h2>
                                    <p className=" mb-5"></p>
                                    <div className="mb-3">
                                        <Button variant="dark" type="submit">
                                            Atsiliepimas
                                        </Button>
                                    </div>
                                </div>

                            </Card.Body>
                        </Card>
                        <Card className="shadow" style={{ width: '49%' }}>
                            <Card.Body>
                                <div className="mb-3 mt-md-4">
                                    <h2 className="fw-bold mb-2 text-uppercase ">CROSS TRAINING</h2>
                                    <p className=" mb-5"></p>
                                    <div className="mb-3">
                                        <Button variant="dark" type="submit" onClick={() => handleShow()}>
                                            Atsiliepimas
                                        </Button>
                                    </div>
                                </div>
                            </Card.Body>
                        </Card>
                    </div>
                </Container>
            </div>

            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Atsiliepimas</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form>
                        <Form.Group
                            className="mb-3"
                            controlId="exampleForm.ControlTextarea1"
                        >
                            <Form.Label>Parašykite atsiliepimą</Form.Label>
                            <Form.Control as="textarea" rows={3} />
                        </Form.Group>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="dark">
                        Patvirtinti
                    </Button>
                    <Button variant="dark" onClick={NavigateToAllFeedbacks}>
                        Peržiūrėti atsiliepimus
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};
export { GroupTrainingsPage };
