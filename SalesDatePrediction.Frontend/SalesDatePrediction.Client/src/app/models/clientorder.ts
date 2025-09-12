export interface ClientOrder {
  orderid: number;
  requireddate: Date;
  shippeddate?: Date | null;
  shipname: string;
  shipaddress: string;
  shipcity: string;
}
