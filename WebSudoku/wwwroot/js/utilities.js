﻿export function alert(message) {
    window.alert(message);
}

export function getSetting(key) {
    return localStorage.getItem(key);
}

export function setSetting(key, value) {
    localStorage.setItem(key, value);
}
