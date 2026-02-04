import { useEffect, useState } from "react";
import type { Order } from "../types/order.dto";
import { useNavigate } from "react-router-dom";
import { formatDate, ordersService } from "../services/orders.service";

const OrdersListPage = () => {
    const [orders, setOrders] = useState<Order[]>([]);
    const navigate = useNavigate();

    useEffect(() => {
        ordersService.getOrders().then(setOrders);
    }, []);

    const onButtonClick = () => {
        navigate("/orders/new");
    }

    const onOrderClick = (id: number) => {
        navigate(`/orders/${id}`);
    }

    return (
        <div className="main-container">
            <div className="orders-header">
                <h2>Список заказов</h2>
                <button onClick={onButtonClick}>Новый заказ</button>
            </div>

            <ul className="orders-list">
                {orders.map(order => (
                    <li className="order-card"
                        key={order.id} 
                        onClick={() => onOrderClick(order.id)}>
                        <div className="order-main">
                            <span className="order-number"> № {order.id}</span>
                            <span className="order-route">
                                {order.senderCity} - {order.receiverCity}
                            </span>
                        </div>
                        <div className="order-info">
                            <span>{order.weight} кг</span>
                            <span>{formatDate(order.pickupDate)}</span>
                        </div>
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default OrdersListPage;