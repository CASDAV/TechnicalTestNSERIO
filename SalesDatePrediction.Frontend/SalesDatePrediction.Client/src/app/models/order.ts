export interface Order {
    empid: number;
    orderdate: Date;
    requireddate: Date;
    shippeddate?: Date | null;
    shipperid: number;
    freight: number;
    shipname: string;
    shipaddress: string;
    shipcity: string;
    shipregion?: string | null;
    shippostalcode?: string | null;
    shipcountry: string;
    productid: number;
    unitprice: number;
    qty: number;
    discount: number; // entre 0.000 y 1.000
}