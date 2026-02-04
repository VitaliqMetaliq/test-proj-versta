import axios from "axios";
import type { Order } from "../types/order.dto";

const api = axios.create({
    baseURL: "/api",
});

api.interceptors.response.use(
    response => response,
    error => {
        console.error("[API Error]:", error);
        return Promise.reject(error);
    }
)

export const ordersService = {
    async getOrders(): Promise<Order[]> {
        const response = await api.get("/orders");
        return response.data;
    },

    async getOrderById(id: number): Promise<Order> {
        const response = await api.get(`/orders/${id}`);
        return response.data;
    },

    async createOrder(order: Omit<Order, "id">): Promise<void> {
        await api.post("/orders", order);
    }
}

export function formatDate(dateStr: string) {
    return new Date(dateStr).toLocaleDateString('ru-RU', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric'
    });
}