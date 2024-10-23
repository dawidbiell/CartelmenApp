export interface Building {
  name: string;
  description?: string;
  startDate?: Date; // DateOnly nie istnieje w TypeScript, użyj string lub Date
  country?: string;
  city?: string;
  street?: string;
  postalCode?: string;
}