import React, { useState } from 'react';
import { Container, Card, Button } from "react-bootstrap";
import Modal from 'react-bootstrap/Modal';



const SubscriptionsPage = () => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <>
        <div className="d-flex" style={{ backgroundImage: `url('${process.env.PUBLIC_URL}/Photos/allpagesbackground.png')`, height: "100vh" }}>
            <Container>
                <div className="d-flex mt-2" style={{ gap: "10px", flexWrap:"wrap", justifyContent: "space-around" }}>
                    <Card className="shadow" style={{ width: "49%" }}>
                        <Card.Body>
                            <div className="mb-3 mt-md-4">
                                <h2 className="fw-bold mb-2 text-uppercase ">START</h2>
                                <p className=" mb-5"></p>
                                <div className="mb-3">
                                    <Button variant="dark" onClick={ () => handleShow() }>
                                        Užsisakyti
                                    </Button>
                                </div>
                            </div>
                        </Card.Body>
                    </Card>
                    <Card className="shadow" style={{ width: "49%" }}>
                        <Card.Body>
                            <div className="mb-3 mt-md-4">
                                <h2 className="fw-bold mb-2 text-uppercase ">FLEXI</h2>
                                <p className=" mb-5"></p>
                                <div className="mb-3">
                                    <Button
                                        variant="dark"
                                        type="button">
                                        Užsisakyti
                                    </Button>
                                </div>
                            </div>
                        </Card.Body>
                    </Card>
                    <Card className="shadow" style={{ width: "49%" }}>
                        <Card.Body>
                            <div className="mb-3 mt-md-4">
                                <h2 className="fw-bold mb-2 text-uppercase ">FLEXI</h2>
                                <p className=" mb-5"></p>
                                <div className="mb-3">
                                    <Button
                                        variant="dark"
                                        type="button">
                                        Užsisakyti
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
          <Modal.Title>Abonemento užsakymas</Modal.Title>
        </Modal.Header>
        <Modal.Body>Patvirtinkite, jog tikrai norite užsisakyti abonementą</Modal.Body>
        <Modal.Footer>
          <Button variant="dark" onClick={handleClose}>
            Patvirtinti
          </Button>
        </Modal.Footer>
      </Modal>
      </>
    );
};

export { SubscriptionsPage };
