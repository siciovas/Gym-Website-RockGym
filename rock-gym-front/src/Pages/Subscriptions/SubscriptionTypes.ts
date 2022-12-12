export interface Service {
    id: number;
    name: string;
}

export interface Subscriptions{
    id: number;
    name: string;
    price: number;
    SubscriptionStarts: Date;
    SubscriptionEnds: Date; 
}