import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { CarModel } from "../models/car.model";
import Buy from "./Buy";


interface TProps{
    car: CarModel;
}


function Car(props: TProps){
    const [name, setName] = useState('');
    const { car } = props;
    const car1 = {
        name: props.car.make+" "+props.car.model
      };
    let navigate=useNavigate();
    function parentToChild(): void {
        
        navigate("/buyacar");
        setName(props.car.make+" "+props.car.model);
        <Buy />

       
    }
    
   
    const discountPrice = car.unitPrice * (1-car.discountPercentage);
    const hasDiscount = car.discountPercentage > 0;

    const formatedPrice = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'EUR' }).format(car.unitPrice);
    const formatedDiscountPrice = new Intl.NumberFormat('en-US', { style: 'currency', currency: 'EUR' }).format(discountPrice);
    const discount = '-' +(car.discountPercentage * 100) + '%';

    return (
        <div className="card" style={{width: '18rem', margin:20, position:'relative'}}>
            {hasDiscount && <span className="badge rounded-pill bg-danger" style={{width:50,position:'absolute'}}>{discount}</span> }
            <div style={{height:'12rem'}}>
                <img src={props.car.image} className="card-img-top" alt="..." />
            </div>
            <div className="card-body">
                <h5 className="card-title">{props.car.make}</h5>
                <p className="card-text">{props.car.model}</p>
                {
                    hasDiscount ? 
                    <>
                        <span className="card-text text-decoration-line-through">{formatedPrice}</span>
                        <p className="card-text" style={{color:'red', fontWeight:'bold'}}>{formatedDiscountPrice}</p>
                    </> :
                    <>
                        <span className="card-text">&nbsp;</span>
                        <p className="card-text" style={{color:'red', fontWeight:'bold'}}>{formatedDiscountPrice}</p>
                    </>
                }
                <Link className="btn btn-primary" to={"/buyacar"+"/"+props.car.id}>Buy </Link>
            </div>
        </div>
    )
}

export default Car;