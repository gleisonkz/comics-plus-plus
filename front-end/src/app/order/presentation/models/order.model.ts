import { PaymentMethod } from '@order/presentation/enums/payment-method.enum';
import { OrderItem } from '@order/presentation/models/order-item.model';

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
