import { Injectable } from '@angular/core';

enum IconType {
  INFO = 'm11.25 11.25.041-.02a.75.75 0 0 1 1.063.852l-.708 2.836a.75.75 0 0 0 1.063.853l.041-.021M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Zm-9-3.75h.008v.008H12V8.25Z',
  SUCCESS = 'M9 12.75 11.25 15 15 9.75M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z',
  WARNING = 'M12 9v3.75m-9.303 3.376c-.866 1.5.217 3.374 1.948 3.374h14.71c1.73 0 2.813-1.874 1.948-3.374L13.949 3.378c-.866-1.5-3.032-1.5-3.898 0L2.697 16.126ZM12 15.75h.007v.008H12v-.008Z',
  ERROR = 'm9.75 9.75 4.5 4.5m0-4.5-4.5 4.5M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z'
}

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor() {
    this.createToastContainer();
  }

  private createToastContainer() {
    if (!document.getElementById('toast-container')) {
      const container = document.createElement('div');
      container.id = 'toast-container';
      container.className = "toast";
      document.body.appendChild(container);
    }
  }

  private createToast(
    message: string,
    alertType: string,
    duration = 5000,
    icon: string = '') {
    const toastContainer = document.getElementById('toast-container');
    if (!toastContainer) return;

    const toast = document.createElement('div');
    toast.classList.add('alert', alertType, 'shadow-lg');
    toast.innerHTML = `
    <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke-width="1.5" stroke="currentColor" class="size-6">
      <path stroke-linecap="round" stroke-linejoin="round" d="${icon}" />
    </svg>
    <span>${message}</span>
    <button class="btn btn-sm btn-ghost ml-4" onclick="this.parentElement.remove()">X</button>
    `
    toast.querySelector('button')?.addEventListener('click', () => {
      toastContainer.removeChild(toast);
    });
    toastContainer.appendChild(toast);

    // Remove the toast after a delay
    setTimeout(() => {
      if (toastContainer.contains(toast)) {
        toastContainer.removeChild(toast);
      }
    }, duration);
  }

  Info(message: string, duration?: number) {
    this.createToast(message, 'alert-info', duration, IconType.INFO);
  }
  Success(message: string, duration?: number) {
    this.createToast(message, 'alert-success', duration, IconType.SUCCESS);
  }
  Warning(message: string, duration?: number) {
    this.createToast(message, 'alert-warning', duration, IconType.WARNING);
  }
  Error(message: string, duration?: number) {
    this.createToast(message, 'alert-error', duration, IconType.ERROR);
  }
}
