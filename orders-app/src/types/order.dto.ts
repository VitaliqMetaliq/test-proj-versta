export interface Order {
    id: number;
    senderCity: string;
    senderAddress: string;
    receiverCity: string;
    receiverAddress: string;
    weight: number;
    pickupDate: string;
}