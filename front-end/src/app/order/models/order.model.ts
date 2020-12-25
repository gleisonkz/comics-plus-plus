import { PaymentMethod } from '@order/enums/payment-method.enum';
import { OrderItem } from '@order/models/order-item.model';

export interface Order {
  orderID: number;
  customerID: number;
  line1: string;
  line2: string;
  number: number;
  neighborhood: string;
  city: string;
  paymentMethodID: PaymentMethod;
  orderItems: OrderItem[];
}
