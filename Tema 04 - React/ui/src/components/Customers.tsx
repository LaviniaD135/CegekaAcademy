import { useEffect, useState } from "react";
import { getCustomer } from "../common/api.service";
import { CarModel } from "../models/car.model";
import Customer from "./Customer";
import { useNavigate } from "react-router-dom";
import { CustomerModel } from "../models/customer.model";
function Customers() {
    const [customers, setCustomers] = useState<CustomerModel[]>([]);
    let navigate=useNavigate();

    useEffect(()=>{
        getCustomer().then(c => setCustomers(c));
    },[])

    return (
        <div>
            <h2>Customers</h2>
            <a href="#" className="btn btn-primary" onClick={() => navigate("/newcustomer") } >Add new customer
                
                </a>
            
            <div>
            <table className="table">
                <thead>
                    <tr>
                    <th scope="col">#</th>
                    <th scope="col">Name</th>
                    <th scope="col">Email</th>
                    
                    </tr>
                </thead>
                <tbody>
                {
                customers.map((c) => (
                     <tr >
                         <td>{c.id}</td>
                         <td>{c.name}</td>
                         <td>{c.email}</td>
                         </tr>
          
               ))
               }
                   
                  
                    
                </tbody>
                </table>
            </div>
            
        </div>);
}



export default Customers;