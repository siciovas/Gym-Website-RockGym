import React, { useCallback, useEffect, useState } from 'react';
import { Container, Card, Button } from "react-bootstrap";
import Modal from 'react-bootstrap/Modal';
import jwtDecode from "jwt-decode";
import { useToast } from "@chakra-ui/react";
import { Subscriptions } from "./SubscriptionTypes";


const SubscriptionsPage = () => {
    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [allSubscriptions, setAllSubscriptions] = useState<Subscriptions[]>([]);
    const toast = useToast();
    const token = localStorage.getItem("accessToken");
    const userId = token && (jwtDecode(token as string) as any);

    const getSubscriptions = useCallback(async () => {
        const mySubscriptions = await fetch(`https://rockgym20221015172815.azurewebsites.net/api/subscription`,
            {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${token}`,
                },
                method: "GET",
            });
        const allSubscriptions = await mySubscriptions.json();
        setAllSubscriptions(allSubscriptions);
    }, []);

    useEffect(() => {
        getSubscriptions();
    }, [])

    return (
        <>
            <div className="d-flex" style={{ backgroundImage: `url('${process.env.PUBLIC_URL}/Photos/allpagesbackground.png')`, height: "100vh" }}>
                <Container>
                    <div className="d-flex mt-2" style={{ gap: "10px", flexWrap: "wrap", justifyContent: "space-around" }}>
                        {allSubscriptions.map((allSubscriptions, index) => {
                            return (
                                <Card key={index} className="shadow" style={{ width: "49%" }}>
                                    <Card.Body>
                                        <div className="mb-3 mt-md-4">
                                            <h3 className="fw-bold text-uppercase ">{allSubscriptions.name}</h3>
                                            <p className=" mb-5">Kaina: {allSubscriptions.price}</p>

                                            <div className="mb-3">
                                                <Button variant="dark" onClick={() => handleShow()}>
                                                    Užsisakyti
                                                </Button>
                                            </div>
                                        </div>
                                    </Card.Body>
                                </Card>
                            );
                        })}
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
