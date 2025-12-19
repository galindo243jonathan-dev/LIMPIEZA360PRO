import React, { useState } from 'react';
import PhotoUploader from './PhotoUploader';

const mockLista = [
  { id: 1, producto: 'Jabón', cantidad: 3 },
  { id: 2, producto: 'Cloro', cantidad: 2 },
  { id: 3, producto: 'Bolsas de basura', cantidad: 10 },
];

export default function ShoppingList() {
  const [lista] = useState(mockLista);

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Lista de Compras</h2>
      <table className="table table-striped table-hover">
        <thead className="table-light">
          <tr>
            <th>#</th>
            <th>Producto</th>
            <th>Cantidad</th>
            <th>Foto</th>
          </tr>
        </thead>
        <tbody>
          {lista.map(item => (
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.producto}</td>
              <td>{item.cantidad}</td>
              <td><PhotoUploader onUploaded={url => {}} /></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
