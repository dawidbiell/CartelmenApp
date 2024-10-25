export interface Worker {
  firstName: string;
  lastName: string;
  phone?: string; // opcjonalne
  email?: string; // opcjonalne
  payRate: number;
  hiringDate?: Date; // DateOnly nie istnieje w TypeScript, więc użyj string lub Date
}
