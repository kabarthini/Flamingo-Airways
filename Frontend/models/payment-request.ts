export interface PaymentRequest {
  passengerName: string;
  flightNumber?: string;
  travelDate?: string;
  passengerCount?: number;
  ticketPrice?: number;
  totalAmount?: number;
  cardNumber: string;
}
