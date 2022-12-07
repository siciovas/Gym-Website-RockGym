import React from "react";
import { Container, Card, Button } from "react-bootstrap";

const GroupTrainingsPage = () => {
    return (
        <div>
            <Container >
                <div className="d-flex mt-2" style={{ gap: '10px' }}>
                        <Card className="shadow" style={{width: '50%'}}>
                            <Card.Body>
                                <div className="mb-3 mt-md-4">
                                    <h2 className="fw-bold mb-2 text-uppercase ">CIRCLE TRAINING</h2>
                                    <p className=" mb-5"></p>
                                    <div className="mb-3">
                                        <Button variant="dark" type="submit">
                                            Atsiliepimai
                                        </Button>
                                    </div>
                                </div>

                            </Card.Body>
                        </Card>
                        <Card className="shadow" style={{width: '50%'}}>
                            <Card.Body>
                                <div className="mb-3 mt-md-4">
                                    <h2 className="fw-bold mb-2 text-uppercase ">CROSS TRAINING</h2>
                                    <p className=" mb-5"></p>
                                    <div className="mb-3">
                                        <Button variant="dark" type="submit">
                                            Atsiliepimai
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
export { GroupTrainingsPage };
