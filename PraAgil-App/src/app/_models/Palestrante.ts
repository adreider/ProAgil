import { RedeSocial } from './RedeSocial';
import { Evento } from './Evento';

// tslint:disable-next-line: no-empty-interface
export interface Palestrante {

      id: number;
      nome: string;
      miniCurriculo: string;
      imagemUrl: string;
      telefone: string;
      email: string;
      redeSociais: RedeSocial[];
      palestranteEvento: Evento[];
}
