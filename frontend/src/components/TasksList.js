import React, { useEffect, useState } from 'react';
import Loader from './Loader';
import PhotoUploader from './PhotoUploader';

const mockTareas = [
  { id: 1, titulo: 'Limpieza cocina', estado: 'Completada', responsable: 'Carlos Ruiz', fecha: '2025-12-17' },
  { id: 2, titulo: 'Mantenimiento baño', estado: 'Pendiente', responsable: 'Ana López', fecha: '2025-12-18' },
  { id: 3, titulo: 'Revisión inventario', estado: 'Completada', responsable: 'María Torres', fecha: '2025-12-16' },
  { id: 4, titulo: 'Limpieza ventanas', estado: 'Pendiente', responsable: 'Juan Pérez', fecha: '2025-12-19' },
];

export default function TasksList() {
  const [tareas, setTareas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [filtro, setFiltro] = useState('');

  useEffect(() => {
    setTimeout(() => {
      setTareas(mockTareas);
      setLoading(false);
    }, 1000);
  }, []);

  const tareasFiltradas = tareas.filter(t =>
    t.titulo.toLowerCase().includes(filtro.toLowerCase()) ||
    t.responsable.toLowerCase().includes(filtro.toLowerCase()) ||
    t.estado.toLowerCase().includes(filtro.toLowerCase())
  );

  return (
    <div className="container mt-4">
      <h2 className="mb-4">Tareas</h2>
      <div className="mb-3">
        <input
          type="text"
          className="form-control"
          placeholder="Buscar por título, responsable o estado..."
          value={filtro}
          onChange={e => setFiltro(e.target.value)}
        />
      </div>
      {loading ? <Loader /> : (
        <table className="table table-striped table-hover">
          <thead className="table-light">
            <tr>
              <th>#</th>
              <th>Título</th>
              <th>Estado</th>
              <th>Responsable</th>
              <th>Fecha</th>
              <th>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {tareasFiltradas.map(t => (
              <tr key={t.id}>
                <td>{t.id}</td>
                <td>{t.titulo}</td>
                <td>
                  <span className={`badge bg-${t.estado === 'Completada' ? 'success' : 'warning text-dark'}`}>{t.estado}</span>
                </td>
                <td>{t.responsable}</td>
                <td>{t.fecha}</td>
                <td>
                  <button className="btn btn-sm btn-outline-primary me-2">Ver</button>
                  <button className="btn btn-sm btn-outline-success" disabled={t.estado === 'Completada'}>Completar</button>
                  {t.estado === 'Completada' && (
                    <div className="mt-2">
                      <PhotoUploader onUploaded={url => {}} />
                    </div>
                  )}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
