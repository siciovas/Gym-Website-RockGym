import React, { useCallback, useEffect, useState } from 'react';
import { Container, Card, Button, Form } from "react-bootstrap";
import Modal from 'react-bootstrap/Modal';
import { useNavigate } from 'react-router-dom';
import { useToast } from "@chakra-ui/react";
import { GroupTrainingTypes } from './GroupTrainingTypes';



const GroupTrainingsPage = () => {
    const [show, setShow] = useState(false);
    const [trainingId, setTrainingId] = useState<number>();
    const handleClose = () => setShow(false);
    const handleShow = (id: number):void => {
        setTrainingId(id);
        setShow(true);
    }
    const navigate = useNavigate();
    const NavigateToAllFeedbacks = () => {
        navigate('/gtfeedback')
    };
    const toast = useToast();
    const [allTrainings, setAllTrainings] = useState<GroupTrainingTypes[]>([]);
    const token = localStorage.getItem("accessToken");
    const subToken = localStorage.getItem("subscriptionIdOrder");


    const [feedback, setFeedback] = useState<string>();
    const onFeedbackChange = (e: any): void => {
        setFeedback(e.target.value as string);
      };

    const getTrainings = useCallback(async () => {
        const myTrainings = await fetch(`https://rockgym20221015172815.azurewebsites.net/api/subscription/${subToken}/grouptraining`,
            {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${token}`,
                },
                method: "GET",
            });
        const allTrainings = await myTrainings.json();
        setAllTrainings(allTrainings);
    }, []);

    useEffect(() => {
        getTrainings();
    }, [])

    const writeFeedback = async (e: React.FormEvent<HTMLFormElement>): Promise<void> => {
        e.preventDefault();
        const data = await fetch(`https://rockgym20221015172815.azurewebsites.net/api/subscription/${subToken}/grouptraining/${trainingId}/trainingfeedback`, {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          method: "POST",
          body: JSON.stringify({
            feedback
          }),
        });
        if (data.status === 201) {
            toast({
              title: "Atsiliepimas parašytas",
              status: "success",
              duration: 5000,
              position:"top-right",
              isClosable: true,
            })
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
                <Container >
                <div className="d-flex mt-2" style={{ gap: "10px", flexWrap:"wrap", justifyContent: "space-around" }}>
                {allTrainings.map((training, index) => {
                    return (
                    <Card key={index} className="shadow" style={{ width: "49%" }}>
                            <Card.Body>
                                <div className="mb-3 mt-md-4">
                                    <h2 className="fw-bold mb-2 text-uppercase">{training.name}</h2>
                                    <h2 className="fw-bold">Trenerio vardas:</h2>
                                    <p >{training.trainerName}</p>
                                    <h2 className="fw-bold">Trenerio pavardė:</h2>
                                    <p >{training.trainerSurname}</p>
                                    <h2 className="fw-bold">Trenerio amžius:</h2>
                                    <p >{training.trainerYear}</p>
                                    <h2 className="fw-bold">Prasideda:</h2>
                                    <p >{training.starts}</p>
                                    <h2 className="fw-bold">Truks laiko:</h2>
                                    <p >{training.duration}</p>
                                    <div className="mb-3">
                                        <Button variant="dark" type="submit" onClick={() => handleShow(training.id)}>
                                            Atsiliepimas
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
                    <Modal.Title>Atsiliepimas</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <Form onSubmit={(e) => {writeFeedback(e)}}>
                        <Form.Group
                            className="mb-3"
                            controlId="exampleForm.ControlTextarea1"
                        >
                            <Form.Label>Parašykite atsiliepimą</Form.Label>
                            <Form.Control as="textarea" rows={3} onChange={(e) => {onFeedbackChange(e)}}/>
                        </Form.Group>
                    <Button variant="dark" type="submit">
                        Patvirtinti
                    </Button>
                    </Form>
                </Modal.Body>
                <Modal.Footer>
                    <Button variant="dark" onClick={NavigateToAllFeedbacks}>
                        Peržiūrėti atsiliepimus
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    );
};
export { GroupTrainingsPage };
