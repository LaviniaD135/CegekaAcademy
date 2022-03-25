import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { getCustomer, postOrder } from "../common/api.service";

import { useNavigate } from "react-router-dom";
import { OrderModel } from "../models/order.model";
import { CustomerModel } from "../models/customer.model";
function Buy(this: any) {

    const [customers, setCustomers] = useState<CustomerModel[]>([]);

    useEffect(()=>{
        getCustomer().then(c => setCustomers(c));
    },[])

    const {id}=useParams();
    const [idOrder, setId] = useState(0);
    const [customerId, setCustomerName] = useState('');
    const [quantity, setQuantity] = useState(0);
    let carOfferId:string=id as string;

    let history=useNavigate();
    function handleClick(): void {
      
        const order:OrderModel = {
            idOrder,
            carOfferId,
            customerId,
            quantity
           
            
        };
        postOrder(order);
        setId(idOrder);
        history("/caroffers");
        //console.log(order);
       
    }

    return(
    <>
    <h2>Buy</h2>
    <h2>Car {id}</h2>
    <div>
        <select className="form-select" onChange={ev => setCustomerName(ev.target.value)}>
            <label className="form-label">Customer Id</label>
            <option value="select">Select Customer</option>
            {
                customers.map((c) => (
                   <option>
                       {c.id}
                   </option>
          
               ))
               }
        </select>
        <div className="mb-3">
            <label className="form-label">Quantity</label>
            <input type="number" className="form-control" placeholder="Select Quantity" min="1" max="5" onChange={ev => setQuantity(Number(ev.target.value))}/>
        </div>

        <a href="#" className="btn btn-primary" onClick={() => handleClick() } >Buy
        
        </a>
    </div>
</>);
}

export default Buy;