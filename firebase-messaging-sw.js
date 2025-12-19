// public/firebase-messaging-sw.js
importScripts('https://www.gstatic.com/firebasejs/9.6.10/firebase-app-compat.js');
importScripts('https://www.gstatic.com/firebasejs/9.6.10/firebase-messaging-compat.js');

firebase.initializeApp({
  apiKey: "AIzaSyBcUAm-_Kj0RBvShNxqpSXLBPGYtQLDjsc",
  authDomain: "limpieza360pro-e0a70.firebaseapp.com",
  projectId: "limpieza360pro-e0a70",
  storageBucket: "limpieza360pro-e0a70.firebasestorage.app",
  messagingSenderId: "63299828446",
  appId: "1:63299828446:web:bf3795ee95fd70a6d7e04f"
});

const messaging = firebase.messaging();

messaging.onBackgroundMessage(function(payload) {
  self.registration.showNotification(payload.notification.title, {
    body: payload.notification.body,
    icon: '/logo192.png'
  });
});
