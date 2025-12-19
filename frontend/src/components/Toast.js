import React from 'react';

export default function Toast({ message, type = 'success', onClose }) {
  return (
    <div className={`toast align-items-center text-bg-${type} show`} role="alert" aria-live="assertive" aria-atomic="true" style={{ position: 'fixed', top: 20, right: 20, zIndex: 9999 }}>
      <div className="d-flex">
        <div className="toast-body">{message}</div>
        <button type="button" className="btn-close btn-close-white me-2 m-auto" aria-label="Close" onClick={onClose}></button>
      </div>
    </div>
  );
}
