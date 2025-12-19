import React from 'react';

export default function DashboardCard({ title, value, icon, color }) {
  return (
    <div className="col-md-4 mb-4">
      <div className={`card shadow border-0 bg-${color || 'primary'} text-white h-100`}>
        <div className="card-body d-flex align-items-center">
          <div className="me-3" style={{ fontSize: 36 }}>
            <i className={icon}></i>
          </div>
          <div>
            <h5 className="card-title mb-1">{title}</h5>
            <h3 className="card-text fw-bold">{value}</h3>
          </div>
        </div>
      </div>
    </div>
  );
}
