import React, { useCallback, useEffect, useState } from 'react';
import { Container, Card, Button } from "react-bootstrap";
import Modal from 'react-bootstrap/Modal';
import { useToast } from "@chakra-ui/react";
import { Subscriptions } from "./SubscriptionTypes";


const SubscriptionsPage = () => {
    const [show, setShow] = useState(false);
    const [subIndex, setSubIndex] = useState<number>();
    const handleClose = () => setShow(false);
    const handleShow = (index: number):void => {
        setSubIndex(index);
        setShow(true);
    }

    const [allSubscriptions, setAllSubscriptions] = useState<Subscriptions[]>([]);
    const toast = useToast();
    const token = localStorage.getItem("accessToken");

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

    const boughtSubscription = async (e: React.MouseEvent<HTMLButtonElement, MouseEvent>): Promise<void> => {
        e.preventDefault();
        const data = await fetch("https://rockgym20221015172815.azurewebsites.net/api/boughtsubscription", {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          method: "POST",
          body: JSON.stringify({
            name: allSubscriptions[subIndex as number].name,
            price: allSubscriptions[subIndex as number].price,
            subscriptionStarts: allSubscriptions[subIndex as number].SubscriptionStarts,
            subscriptionEnds: allSubscriptions[subIndex as number].SubscriptionEnds,
            subscriptionId: allSubscriptions[subIndex as number].id,
          }),
        });
        if (data.status === 201) {
            toast({
              title: "Pirkimas sėkmingas",
              status: "success",
              duration: 5000,
              position:"top-right",
              isClosable: true,
            })
            var json = await data.json();
            localStorage.setItem("subscriptionIdOrder", json.subscriptionId);
          } else {
            toast({
              title: "Klaida",
              status: "error",
              duration: 5000,
              position:"top-right",
              isClosable: true,
            })
        }
    };

    return (
        <>
            <div className="d-flex" style={{ backgroundImage: `url('${process.env.PUBLIC_URL}/Photos/allpagesbackground.png')`, height: "100vh" }}>
                <Container>
                    <div className="d-flex mt-2" style={{ gap: "10px", flexWrap: "wrap", justifyContent: "space-around" }}>
                        {allSubscriptions.map((sub, index) => {
                            return (
                                <Card key={index} className="shadow" style={{ width: "49%" }}>
                                    <Card.Body>
                                        <div className="mb-3 mt-md-4">
                                            <h3 className="fw-bold text-uppercase ">{sub.name}</h3>
                                            <p className=" mb-5">Kaina: {sub.price}</p>

                                            <div className="mb-3">
                                                <Button variant="dark" onClick={() => handleShow(index)}>
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
                    <Button variant="dark" onClick={(e) => boughtSubscription(e)}>
                        Patvirtinti
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};

export { SubscriptionsPage };
