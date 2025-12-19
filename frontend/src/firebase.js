// src/firebase.js
import { initializeApp } from 'firebase/app';
import { getMessaging, getToken, onMessage } from 'firebase/messaging';

const firebaseConfig = {
  apiKey: "AIzaSyBcUAm-_Kj0RBvShNxqpSXLBPGYtQLDjsc",
  authDomain: "limpieza360pro-e0a70.firebaseapp.com",
  projectId: "limpieza360pro-e0a70",
  storageBucket: "limpieza360pro-e0a70.firebasestorage.app",
  messagingSenderId: "63299828446",
  appId: "1:63299828446:web:bf3795ee95fd70a6d7e04f"
};

const app = initializeApp(firebaseConfig);
const messaging = getMessaging(app);

export { messaging, getToken, onMessage };
