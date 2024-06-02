
export interface Journey {
  id: number,
  vehicle: Vehicle,
  country: string,
  description: string,
  departure: string,
  capacity: number,
  pictureUrl: string
}

export interface Vehicle {
  id: number,
  type: string
}

export interface JourneyShort {
  id: number,
  destination: string,
}
