import React from "react";
import { Container, Card, Button } from "react-bootstrap";

const SubscriptionsPage = () => {
    return (
        <div>
            <Container>
                <div className="d-flex mt-2" style={{ gap: "10px" }}>
                    <Card className="shadow" style={{ width: "50%" }}>
                        <Card.Body>
                            <div className="mb-3 mt-md-4">
                                <h2 className="fw-bold mb-2 text-uppercase ">START</h2>
                                <p className=" mb-5"></p>
                                <div className="mb-3">
                                    <Button variant="dark" type="submit">
                                        Užsisakyti
                                    </Button>
                                </div>
                            </div>
                        </Card.Body>
                    </Card>
                    <Card className="shadow" style={{ width: "50%" }}>
                        <Card.Body>
                            <div className="mb-3 mt-md-4">
                                <h2 className="fw-bold mb-2 text-uppercase ">FLEXI</h2>
                                <p className=" mb-5"></p>
                                <div className="mb-3">
                                    <Button
                                        variant="dark"
                                        type="button"
                                    >
                                        Užsisakyti
                                    </Button>
                                </div>
                            </div>
                        </Card.Body>
                    </Card>
                </div>
            </Container>
        </div>
    );
};
export { SubscriptionsPage };
