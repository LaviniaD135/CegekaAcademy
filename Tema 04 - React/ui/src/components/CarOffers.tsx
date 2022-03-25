import { useEffect, useState } from "react";
import { getCars } from "../common/api.service";
import { CarModel } from "../models/car.model";
import Car from "./Car";
import { Link, useNavigate } from "react-router-dom";
import Buy from "./Buy";

//1. Props change
//2. State change

function CarOffers() {
    const [cars, setCars] = useState<CarModel[]>([]);
    let navigate=useNavigate();
   

    useEffect(()=>{
        getCars().then(c => setCars(c));
    },[])

    return (
    <div>
     
        <h2>All cars</h2>
        <a href="#" className="btn btn-primary" onClick={() => navigate('/newcar') } >Add new car
                
                </a>
        <div></div>
        <div style={{display:'flex', flexWrap:'wrap'}}>
            {cars.map(c => <Car car={c} />)}
           
 

        </div>
        
    </div>);
}

export default CarOffers;