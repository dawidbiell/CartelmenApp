import { of } from 'rxjs';

export interface Spot {
	id: number;
	name: string;
	description?: string;
	startDate?: string;
	country?: string;
	city?: string;
	street?: string;
	postalCode?: string;
}

export class MockSpotService {
  getSpots() { return of(MOCK_SPOTS); }
  getSpot(id: number) { return of(MOCK_SPOTS.find(s => s.id === id)); }
}

export const MOCK_SPOTS: Spot[] = [
	{
		id: 1,
		name: "Morawski - Śliwiński",
		description: "User-friendly didactic synergy",
		startDate: "2024-07-24",
		country: "Komory",
		city: "Szczekociny",
		street: "al. Drozd",
		postalCode: "91-038"
	},
	{
		id: 2,
		name: "Czapla - Gajewski",
		description: "Synergistic optimizing challenge",
		startDate: "2024-05-17",
		country: "Bośnia i Hercegowina",
		city: "Pułtusk",
		street: "ul. Różycki",
		postalCode: "08-171"
	},
	{
		id: 3,
		name: "Kautzer Group",
		description: "Basium constans cerno suscipio decimus admitto soleo spoliatio.",
		startDate: "2025-11-22",
		country: "Bouvet Island",
		city: "East Zakarymouth",
		street: "Marsh Lane",
		postalCode: "5132209430305698"
	},
	{
		id: 4,
		name: "Davis, Hudson and Hammes",
		description: "Cohaero demum subseco inventore.",
		startDate: "2025-11-22",
		country: "Cote d'Ivoire",
		city: "West Hayleyland",
		street: "Clement Summit",
		postalCode: "3934596860128207"
	}
];

