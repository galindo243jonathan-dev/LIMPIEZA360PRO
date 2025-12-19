import React, { useEffect, useState } from 'react';
import Loader from './Loader';

const mockPropiedades = [
  { id: 1, nombre: 'Casa Central', direccion: 'Av. Principal 123', responsable: 'Carlos Ruiz', tareasPendientes: 2 },
  { id: 2, nombre: 'Departamento Sur', direccion: 'Calle Sur 456', responsable: 'Ana López', tareasPendientes: 1 },
  { id: 3, nombre: 'Oficina Norte', direccion: 'Av. Norte 789', responsable: 'María Torres', tareasPendientes: 0 },
  { id: 4, nombre: 'Bodega Este', direccion: 'Calle Este 321', responsable: 'Juan Pérez', tareasPendientes: 3 },
];

export default function PropertiesList() {
  const [propiedades, setPropiedades] = useState([]);
  const [loading, setLoading] = useState(true);
  const [filtro, setFiltro] = useState('');

  useEffect(() => {
    setTimeout(() => {
      setPropiedades(mockPropiedades);
      setLoading(false);
    }, 1000);
  }, []);

  const propiedadesFiltradas = propiedades.filter(p =>
    p.nombre.toLowerCase().includes(filtro.toLowerCase()) ||
    p.direccion.toLowerCase().includes(filtro.toLowerCase()) ||
    p.responsable.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Propiedades</h2>
      <div className="mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Buscar por nombre, dirección o responsable..."
          value={filtro}
          onChange={e => setFiltro(e.target.value)}
        />
      </div>
      {loading ? <Loader /> : (
        <table className="table table-striped table-hover">
          <thead className="table-light">
            <tr>
              <th>#</th>
              <th>Nombre</th>
              <th>Dirección</th>
              <th>Responsable</th>
              <th>Tareas Pendientes</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {propiedadesFiltradas.map(p => (
              <tr key={p.id}>
                <td>{p.id}</td>
                <td>{p.nombre}</td>
                <td>{p.direccion}</td>
                <td>{p.responsable}</td>
                <td>
                  <span className={`badge bg-${p.tareasPendientes > 0 ? 'warning text-dark' : 'success'}`}>{p.tareasPendientes}</span>
                </td>
                <td>
                  <button className="btn btn-sm btn-outline-primary me-2">Ver</button>
                  <button className="btn btn-sm btn-outline-success" disabled={p.tareasPendientes === 0}>Completar todas</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
