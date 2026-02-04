import { useParams } from "react-router-dom";
import type { Order } from "../types/order.dto";
import { useEffect, useState } from "react";
import { formatDate, ordersService } from "../services/orders.service";

const OrderDetailsPage = () => {
    const params = useParams();
    const [order, setOrder] = useState<Order | null>(null);

    useEffect(() => {
        if (params.id) {
            ordersService.getOrderById(Number(params.id)).then(setOrder);
        }
    }, [ params.id ]);

    if (!order) {
        return <div>Загрузка...</div>;
    }

    return (
        <div className="main-container">
            <h2 className="order-details-header">Заказ № {order.id}</h2>
            <div className="order-details-grid">
                <div>
                    <span>Город отправителя</span>
                    <p>{order.senderCity}</p>
                </div>
                <div>
                    <span>Адрес отправителя</span>
                    <p>{order.senderAddress}</p>
                </div>
                <div>
                    <span>Город получателя</span>
                    <p>{order.receiverCity}</p>
                </div>
                <div>
                    <span>Адрес получателя</span>
                    <p>{order.receiverAddress}</p>
                </div>
                <div>
                    <span>Вес груза</span>
                    <p>{order.weight} кг</p>
                </div>
                <div>
                    <span>Дата забора груза</span>
                    <p>{formatDate(order.pickupDate)}</p>
                </div>
            </div>
        </div>
    );
}

export default OrderDetailsPage;