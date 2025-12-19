import { messaging, getToken, onMessage } from './firebase';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Routes, Route, Link, Navigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import DashboardCard from './components/DashboardCard';
import Loader from './components/Loader';
import Toast from './components/Toast';
import UsersList from './components/UsersList';
import TasksList from './components/TasksList';
import PropertiesList from './components/PropertiesList';
import InventoryList from './components/InventoryList';
import ShoppingList from './components/ShoppingList';
import { startNotificationsHub, stopNotificationsHub } from './utils/signalR';

function Home() {
  return (
    <div className="text-center mt-5">
      <h1 className="mb-4 text-primary">Limpieza 360Pro</h1>
      <p className="lead">Bienvenido a la plataforma profesional de gestión de limpieza y mantenimiento.</p>
      <p>Utiliza el menú para navegar por las funciones principales.</p>
    </div>
  );
}

function Login() {
  const [usuario, setUsuario] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const [showToast, setShowToast] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setLoading(true);
    setShowToast(false);
    // Simulación de login
    setTimeout(() => {
      setLoading(false);
      if (usuario === 'admin' && password === 'admin') {
        localStorage.setItem('token', 'demo-token');
        setShowToast(true);
        setTimeout(() => window.location.href = '/dashboard', 1000);
      } else {
        setError('Credenciales incorrectas.');
      }
    }, 1200);
  };

  return (
    <div className="row justify-content-center mt-5">
      <div className="col-md-4">
        <div className="card shadow">
          <div className="card-body">
            <h2 className="mb-4 text-center">Iniciar Sesión</h2>
            {error && <div className="alert alert-danger">{error}</div>}
            {showToast && <Toast message="¡Login exitoso!" onClose={() => setShowToast(false)} />}
            <form onSubmit={handleSubmit} autoComplete="off">
              <div className="mb-3">
                <label className="form-label">Usuario</label>
                <input type="text" className="form-control" value={usuario} onChange={e => setUsuario(e.target.value)} />
              </div>
              <div className="mb-3">
                <label className="form-label">Contraseña</label>
                <input type="password" className="form-control" value={password} onChange={e => setPassword(e.target.value)} />
              </div>
              <button type="submit" className="btn btn-primary w-100" disabled={loading}>Entrar</button>
            </form>
            {loading && <Loader />}
          </div>
        </div>
      </div>
    </div>
  );
}

function ProtectedRoute({ children }) {
  const token = localStorage.getItem('token');
  if (!token) {
    return <Navigate to="/login" replace />;
  }
  return children;
}

function Dashboard() {
  // Simulación de datos
  const stats = [
    { title: 'Propiedades', value: 4, icon: 'bi bi-house-door', color: 'primary' },
    { title: 'Tareas', value: 12, icon: 'bi bi-list-check', color: 'success' },
    { title: 'Usuarios', value: 5, icon: 'bi bi-people', color: 'info' },
  ];
  return (
    <div className="container mt-4">
      <h2 className="mb-4">Panel Principal</h2>
      <div className="row">
        {stats.map((s, i) => <DashboardCard key={i} {...s} />)}
      </div>
    </div>
  );
}

function App() {
  const [notification, setNotification] = useState("");
  const [showToast, setShowToast] = useState(false);

  useEffect(() => {
    // Iniciar SignalR solo si está autenticado
    if (localStorage.getItem('token')) {
      startNotificationsHub(msg => {
        setNotification(msg);
        setShowToast(true);
      });
      return () => stopNotificationsHub();
    }
  }, []);

  // Notificaciones push Firebase
  useEffect(() => {
    if ('serviceWorker' in navigator) {
      navigator.serviceWorker.register('/firebase-messaging-sw.js')
        .then(registration => {
          // Solicitar permiso
          Notification.requestPermission().then(permission => {
            if (permission === 'granted') {
              getToken(messaging, { vapidKey: 'BNlWQr-akI-rdi2kLIzuToqtUbxFhsYWaESk0TUF7nwRtxCbzL-x0HDToxY2YD9lfZS2XGs9RE7oAm7TFThm8RE', serviceWorkerRegistration: registration })
                .then((currentToken) => {
                  if (currentToken) {
                    // Aquí puedes enviar el token al backend si lo necesitas
                  }
                });
            }
          });
        });
    }
    // Mensajes en primer plano
    onMessage(messaging, payload => {
      setNotification(payload.notification?.title + ': ' + payload.notification?.body);
      setShowToast(true);
    });
  }, []);

  return (
    <Router>
      <nav className="navbar navbar-expand-lg navbar-light bg-light">
        <div className="container-fluid">
          <Link className="navbar-brand" to="/">Limpieza 360Pro</Link>
          <div className="collapse navbar-collapse">
            <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
              <li className="nav-item">
                <Link className="nav-link" to="/">Inicio</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/login">Login</Link>
              </li>
              <li className="nav-item">
                <Link className="nav-link" to="/dashboard">Dashboard</Link>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <div className="container py-4">
        {showToast && <Toast message={notification} onClose={() => setShowToast(false)} />}
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/login" element={<Login />} />
          <Route path="/dashboard" element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          } />
          <Route path="/usuarios" element={
            <ProtectedRoute>
              <UsersList />
            </ProtectedRoute>
          } />
          <Route path="/tareas" element={
            <ProtectedRoute>
              <TasksList />
            </ProtectedRoute>
          } />
          <Route path="/propiedades" element={
            <ProtectedRoute>
              <PropertiesList />
            </ProtectedRoute>
          } />
          <Route path="/inventario" element={
            <ProtectedRoute>
              <InventoryList />
            </ProtectedRoute>
          } />
          <Route path="/compras" element={
            <ProtectedRoute>
              <ShoppingList />
            </ProtectedRoute>
          } />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
