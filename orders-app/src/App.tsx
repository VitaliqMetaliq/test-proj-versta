import './App.css'
import { BrowserRouter, Navigate, Route, Routes } from 'react-router-dom';
import CreateOrderPage from './pages/create-order.page';
import OrderDetailsPage from './pages/order-details.page';
import OrdersListPage from './pages/orders-list.page';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Navigate to="/orders" />} />
        <Route path="/orders" element={<OrdersListPage />} />
        <Route path="/orders/new" element={<CreateOrderPage />} />
        <Route path="/orders/:id" element={<OrderDetailsPage />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
