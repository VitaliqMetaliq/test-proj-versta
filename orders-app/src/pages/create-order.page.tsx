import { useNavigate } from "react-router-dom";
import OrderForm from "../components/order-form";
import { ordersService } from "../services/orders.service";
import { type FormData } from "../validation/order-schema";
import type { Order } from "../types/order.dto";
import "./styles.css";

const CreateOrderPage = () => {
    const navigate = useNavigate();

    const onFormSubmit = async (data: FormData) => {
        await ordersService.createOrder(data as Omit<Order, "id">);
        navigate("/orders");
    }

    return (
        <div className="form-container">
            <h2 className="form-container-header">Создание заказа</h2>
            <OrderForm onSubmit={onFormSubmit}/>
        </div>
    )
}

export default CreateOrderPage;