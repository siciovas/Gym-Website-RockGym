import React, { useCallback, useEffect, useState } from 'react';
import { Card } from 'react-bootstrap';
import { TrainingFeedbackTypes } from './TrainingFeedbackTypes';
import { useSearchParams } from "react-router-dom";


const TrainingFeedbackPage = () => {

    const token = localStorage.getItem("accessToken");
    const subToken = localStorage.getItem("subscriptionIdOrder");
    const [allFeedbacks, setAllFeedbacks] = useState<TrainingFeedbackTypes[]>([]);
    let [searchParams] = useSearchParams();


    const getFeedbacks = useCallback(async () => {
        const trainingId = window.location.search.split("=")[1]
        const myFeedbacks = await fetch(`https://rockgym20221015172815.azurewebsites.net/api/subscription/${subToken}/grouptraining/${trainingId}/trainingfeedback`,
            {
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${token}`,
                },
                method: "GET",
            });
        const allFeedbacks = await myFeedbacks.json();
        setAllFeedbacks(allFeedbacks);
    }, []);

    useEffect(() => {
        getFeedbacks();
    }, [])

    return ( 
        <>
    {allFeedbacks.map((feedback, index) => {
    return (
        <Card key={index}>
            <Card.Body>{feedback.feedback}</Card.Body>
        </Card>
    );
    })}
     </>
    )
};

export { TrainingFeedbackPage };
