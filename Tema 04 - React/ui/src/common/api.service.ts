import { CarModel } from "../models/car.model";
import { CustomerModel } from "../models/customer.model";
import { OrderModel } from "../models/order.model";

export function getCars(): Promise<CarModel[]> {
    return fetch('http://localhost:5198/CarOffer')
        .then(r => r.json())
}

export function getCustomer(): Promise<CustomerModel[]> {
    return fetch('http://localhost:5198/Customer')
        .then(r => r.json())
}
export function postCar(car: CarModel) {
    fetch('http://localhost:5198/CarOffer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(car)
    })
}
export function postOrder(order: OrderModel) {
    fetch('http://localhost:5198/Order', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    })
}
export function postCustomer(customer: CustomerModel) {
    fetch('http://localhost:5198/Customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(customer)
    })
}