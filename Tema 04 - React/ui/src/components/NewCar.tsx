import { useState } from "react";
import { Link } from "react-router-dom";
import { postCar } from "../common/api.service";
import { CarModel } from "../models/car.model";
import { useNavigate } from "react-router-dom";

function NewCar() {

    const [make, setMake] = useState('');
    const [model, setModel] = useState('');
    const [availableStock, setAvailableStock] = useState(0);
    const [unitPrice, setUnitPrice] = useState(0);
    const [image, setImage] = useState('');
    const [discountPercentage, setDiscountPercentage] = useState(0);
    const [id, setId] = useState(0);
    let history=useNavigate();
    function handleClick(): void {
        setId(id);
        const car:CarModel = {
            id,
            make,
            model,
            availableStock,
            unitPrice,
            image,
            discountPercentage
        };
        postCar(car);
        
        history("/caroffers");
    }

    return (
        <>
            <h2>New Car</h2>
            <div>
                <div className="mb-3">
                    <label className="form-label">Make</label>
                    <input type="text" className="form-control" placeholder="Make" onChange={ev => setMake(ev.target.value)} />
                </div>
                <div className="mb-3">
                    <label className="form-label">Model</label>
                    <input type="text" className="form-control" placeholder="Model" onChange={ev => setModel(ev.target.value)}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Stock</label>
                    <input type="number" className="form-control" placeholder="Stock" onChange={ev => setAvailableStock(Number(ev.target.value))}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Price</label>
                    <input type="number" className="form-control" placeholder="Price" onChange={ev => setUnitPrice(Number(ev.target.value))}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Image</label>
                    <input type="text" className="form-control" placeholder="Image" onChange={ev => setImage(ev.target.value)}/>
                </div>
                <div className="mb-3">
                    <label className="form-label">Price</label>
                    <input type="number" className="form-control" placeholder="Discount Percentage" onChange={ev => setDiscountPercentage(Number(ev.target.value))}/>
                </div>
                
                <a href="#" className="btn btn-primary" onClick={() => handleClick() } >Save
                
                </a>
            </div>
        </>);
}

export default NewCar;


