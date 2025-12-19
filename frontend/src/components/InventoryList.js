import React, { useState } from 'react';
import PhotoUploader from './PhotoUploader';

const mockInventario = [
  { id: 1, nombre: 'Escoba', cantidad: 2 },
  { id: 2, nombre: 'Detergente', cantidad: 5 },
  { id: 3, nombre: 'Guantes', cantidad: 0 },
];

export default function InventoryList() {
  const [inventario] = useState(mockInventario);

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Inventario</h2>
      <table className="table table-striped table-hover">
        <thead className="table-light">
          <tr>
            <th>#</th>
            <th>Nombre</th>
            <th>Cantidad</th>
            <th>Foto</th>
          </tr>
        </thead>
        <tbody>
          {inventario.map(item => (
            <tr key={item.id}>
              <td>{item.id}</td>
              <td>{item.nombre}</td>
              <td>{item.cantidad}</td>
              <td><PhotoUploader onUploaded={url => {}} /></td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
