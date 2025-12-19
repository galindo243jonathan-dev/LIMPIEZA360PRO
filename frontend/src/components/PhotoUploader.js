import React, { useState } from 'react';
import axios from 'axios';
import Loader from './Loader';
import Toast from './Toast';

export default function PhotoUploader({ onUploaded }) {
  const [file, setFile] = useState(null);
  const [loading, setLoading] = useState(false);
  const [toast, setToast] = useState("");

  const handleChange = e => {
    setFile(e.target.files[0]);
  };

  const handleUpload = async () => {
    if (!file) return;
    setLoading(true);
    const formData = new FormData();
    formData.append('file', file);
    try {
      const token = localStorage.getItem('token');
      const res = await axios.post(
        'https://localhost:5001/api/upload/photo',
        formData,
        { headers: { 'Authorization': `Bearer ${token}` } }
      );
      setToast('Foto subida correctamente');
      setFile(null);
      if (onUploaded) onUploaded(res.data.url);
    } catch (err) {
      setToast('Error al subir la foto');
    }
    setLoading(false);
  };

  return (
    <div className="mb-3">
      <label className="form-label">Subir foto:</label>
      <input type="file" className="form-control mb-2" onChange={handleChange} />
      <button className="btn btn-primary" onClick={handleUpload} disabled={loading || !file}>
        {loading ? <Loader /> : 'Subir'}
      </button>
      {toast && <Toast message={toast} onClose={() => setToast("")} />}
    </div>
  );
}
