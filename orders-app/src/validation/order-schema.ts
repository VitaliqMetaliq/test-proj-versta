import z from "zod";

export interface FormData {
    senderCity: string;
    senderAddress: string;
    receiverCity: string;
    receiverAddress: string;
    weight: unknown | number;
    pickupDate: string;
}

export const orderSchema = z.object({
    senderCity: z.string()
        .min(1, "Заполните город отправителя")
        .max(100, "Максимум 100 символов"),

    senderAddress: z.string()
        .min(1, "Заполните адрес отправителя")
        .max(500, "Максимум 500 символов"),
    
    receiverCity: z.string()
        .min(1, "Заполните город получателя")
        .max(100, "Максимум 100 символов"),

    receiverAddress: z.string()
        .min(1, "Заполните адрес получателя")
        .max(500, "Максимум 500 символов"),

    weight: z.coerce.number()
        .min(1, "Вес должен быть больше 0"),
    
    pickupDate: z.string()
        .min(1, "Укажите дату"),
});