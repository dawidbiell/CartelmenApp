import { Injectable } from '@angular/core';

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
    alertType: 'info' | 'success' | 'warning' | 'error' = 'success',
    duration = 5000) {
    const toastContainer = document.getElementById('toast-container');
    if (!toastContainer) return;

    const toast = document.createElement('div');
    toast.classList.add('alert', `alert-${alertType}`, 'shadow-lg');
    toast.innerHTML = `
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
}
