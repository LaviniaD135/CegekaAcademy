import { useState } from "react";
import { Link } from "react-router-dom";
import { postCustomer } from "../common/api.service";

import { useNavigate } from "react-router-dom";
import { CustomerModel } from "../models/customer.model";

function NewCustomer() {

    const [id, setId] = useState(0);
    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    
    let history=useNavigate();
    function handleClick(): void {
        const customer:CustomerModel = {
            id,
            name,
            email
            
        };
        postCustomer(customer);
        setId(id);
        history("/customers");
    }

    return(
    <>
    <h2>New Car</h2>
    <div>
        <div className="mb-3">
            <label className="form-label">Make</label>
            <input type="text" className="form-control" placeholder="Name" onChange={ev => setName(ev.target.value)} />
        </div>
        <div className="mb-3">
            <label className="form-label">Model</label>
            <input type="email" className="form-control" placeholder="Email" onChange={ev => setEmail(ev.target.value)}/>
        </div>
        
        
        <a href="#" className="btn btn-primary" onClick={() => handleClick() } >Save
        
        </a>
    </div>
</>);
}

export default NewCustomer;