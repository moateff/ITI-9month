import React, { useState } from "react";
// Updated to match your exact "generated" filenames
import { OrderClient }  from "./generated/order_grpc_web_pb.js";
import { OrderRequest, Item } from "./generated/order_pb.js";


const client = new OrderClient("http://localhost:5089");

export default function CreateOrder() {
  const [orderId, setOrderId] = useState("");
  const [userId, setUserId] = useState("");
  const [items, setItems] = useState([]);

  const handleAddItem = () => {
    setItems([
      ...items,
      { id: Date.now(), itemId: "", price: "", quantity: "" }
    ]);
  };

  const handleRemoveItem = (idToRemove) => {
    setItems(items.filter((item) => item.id !== idToRemove));
  };

  const handleItemChange = (id, field, value) => {
    setItems(
      items.map((item) =>
        item.id === id ? { ...item, [field]: value } : item
      )
    );
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const request = new OrderRequest();
    request.setId(Number(orderId));
    request.setUserId(Number(userId));

    const grpcItems = items.map((i) => {
      const protoItem = new Item();
      protoItem.setId(Number(i.itemId));
      protoItem.setPrice(Number(i.price));
      protoItem.setQuantity(Number(i.quantity));
      return protoItem;
    });

    request.setItemsList(grpcItems);

    client.create(request, {}, (err, response) => {
      if (err) {
        console.error("gRPC Error:", err);
        alert(`Error: ${err.message}`);
        return;
      }
      console.log("Response:", response.toObject());
      alert(response.getMessage());
    });
  };

  return (
    <div className="container mt-5">
      <div className="card shadow p-4">
        <h3 className="mb-4">Create Order</h3>

        <form onSubmit={handleSubmit}>
          <div className="mb-3">
            <label className="form-label">Order ID</label>
            <input
              type="number"
              className="form-control"
              value={orderId}
              onChange={(e) => setOrderId(e.target.value)}
              required
            />
          </div>

          <div className="mb-3">
            <label className="form-label">User ID</label>
            <input
              type="number"
              className="form-control"
              value={userId}
              onChange={(e) => setUserId(e.target.value)}
              required
            />
          </div>

          <hr />
          <h5>Items</h5>
          
          <div>
            {items.map((item) => (
              <div className="border rounded p-3 mb-2 bg-white" key={item.id}>
                <div className="row">
                  <div className="col">
                    <input
                      type="number"
                      className="form-control"
                      placeholder="Item ID"
                      value={item.itemId}
                      onChange={(e) => handleItemChange(item.id, "itemId", e.target.value)}
                      required
                    />
                  </div>
                  <div className="col">
                    <input
                      type="number"
                      className="form-control"
                      placeholder="Price"
                      value={item.price}
                      onChange={(e) => handleItemChange(item.id, "price", e.target.value)}
                      required
                    />
                  </div>
                  <div className="col">
                    <input
                      type="number"
                      className="form-control"
                      placeholder="Quantity"
                      value={item.quantity}
                      onChange={(e) => handleItemChange(item.id, "quantity", e.target.value)}
                      required
                    />
                  </div>
                  <div className="col-auto">
                    <button
                      type="button"
                      className="btn btn-danger"
                      onClick={() => handleRemoveItem(item.id)}
                    >
                      X
                    </button>
                  </div>
                </div>
              </div>
            ))}
          </div>

          <button
            type="button"
            className="btn btn-secondary mt-2"
            onClick={handleAddItem}
          >
            + Add Item
          </button>

          <hr />

          <button type="submit" className="btn btn-primary w-100">
            Create Order
          </button>
        </form>
      </div>
    </div>
  );
}