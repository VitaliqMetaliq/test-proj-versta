import { orderSchema, type FormData } from "../validation/order-schema";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import "./order-form.css";

interface Props {
    onSubmit: (order: FormData) => void;
}

const OrderForm = (props: Props) => {

    const { register, handleSubmit, formState: { errors }} = 
        useForm<FormData>({resolver: zodResolver(orderSchema)});

    return (
        <form onSubmit={handleSubmit(props.onSubmit)} className="form">
            <div className="form-input">
                <input {...register("senderCity")} placeholder="Город отправителя" />
                {errors.senderCity && <span>{errors.senderCity.message}</span>}
            </div>
            <div className="form-input">
                <input {...register("senderAddress")} placeholder="Адрес отправителя" />
                {errors.senderAddress && <span>{errors.senderAddress.message}</span>}
            </div>
            <div className="form-input">
                <input {...register("receiverCity")} placeholder="Город получателя" />
                {errors.receiverCity && <span>{errors.receiverCity.message}</span>}
            </div>
            <div className="form-input">
                <input {...register("receiverAddress")} placeholder="Адрес получателя" />
                {errors.receiverAddress && <span>{errors.receiverAddress.message}</span>}
            </div>
            <div className="form-input">
                <input {...register("weight")} type="number" placeholder="Вес груза" />
                {errors.weight && <span>{errors.weight.message}</span>}
            </div>
            <div className="form-input">
                <input {...register("pickupDate")} type="date" />
                {errors.pickupDate && <span>{errors.pickupDate.message}</span>}
            </div>
            
            <button type="submit" className="form-submit-button">Создать заказ</button>
        </form>
    );
}

export default OrderForm;
