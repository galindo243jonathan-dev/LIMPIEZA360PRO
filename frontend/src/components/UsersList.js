import React, { useEffect, useState } from 'react';
import Loader from './Loader';

export default function UsersList() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Simulación de fetch de usuarios
    setTimeout(() => {
      setUsers([
        { id: 1, nombre: 'Juan Pérez', rol: 'Dueño', email: 'juan@demo.com' },
        { id: 2, nombre: 'Ana López', rol: 'Manager', email: 'ana@demo.com' },
        { id: 3, nombre: 'Carlos Ruiz', rol: 'Empleado', email: 'carlos@demo.com' },
        { id: 4, nombre: 'María Torres', rol: 'Empleado', email: 'maria@demo.com' },
      ]);
      setLoading(false);
    }, 1000);
  }, []);

  if (loading) return <Loader />;

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Usuarios</h2>
      <table className="table table-striped table-hover">
        <thead className="table-light">
          <tr>
            <th>#</th>
            <th>Nombre</th>
            <th>Rol</th>
            <th>Email</th>
          </tr>
        </thead>
        <tbody>
          {users.map(u => (
            <tr key={u.id}>
              <td>{u.id}</td>
              <td>{u.nombre}</td>
              <td>{u.rol}</td>
              <td>{u.email}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
