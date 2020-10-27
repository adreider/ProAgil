
// tslint:disable-next-line: no-empty-interface
export interface Lote {
         id: number;
         nome: string;
         preco: number;
         dataInicio?: Date;
         dataFim?: Date;
         quantidade: number;
         eventoId: number;
}
