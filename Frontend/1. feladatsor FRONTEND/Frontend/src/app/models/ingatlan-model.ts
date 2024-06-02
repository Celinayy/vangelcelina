export interface IngatlanModel {
  id: number,
  kategoriaId: number,
  kategoria: KategoriaModel,
  leiras: string,
  hirdetesDatuma: string,
  tehermentes: boolean,
  kepUrl: string
}


export interface KategoriaModel {
  id: number,
  megnevezes: string
}
