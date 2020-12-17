import { PaymentMethod } from '../enums/payment-method.enum';
import { OrderItem } from './order-item.model';

export interface Order {
  orderID: number;
  customerID: number;
  line1: string;
  line2: string;
  number: number;
  paymentMethodID: PaymentMethod;
  orderItems: OrderItem[];
}
