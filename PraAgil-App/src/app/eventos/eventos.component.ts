import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Evento } from '../_models/Evento';
import { EventoService } from '../_services/evento.service';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemAltura =  50;
  imagemMargem = 80;
  mostrarImagem = false;
  modalRef: BsModalRef;

  // tslint:disable-next-line: variable-name
  _filtroLista = '';

  constructor(
    private eventoService: EventoService
    // tslint:disable-next-line: align
    , private modalService: BsModalService
    ) { }


  // tslint:disable-next-line: variable-name
  get filtroLista(): string{
    return this._filtroLista;
  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEvento(this.filtroLista) : this.eventos;
  }

  // tslint:disable-next-line: variable-name
  _filtroLista1: string;
  get filtroLista1(): string{
    return this._filtroLista;
  }
  set filtroLista1(value: string) {
    this._filtroLista1 = value;
    this.eventosFiltrados = this.filtroLista1 ? this.filtrarEvento1(this.filtroLista1) : this.eventos;
  }

  // tslint:disable-next-line: typedef
  openModal(template: TemplateRef<any>){
    this.modalRef = this.modalService.show(template);
  }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getEventos();
  }

  filtrarEvento(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      x => x.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1,
    );
  }

  filtrarEvento1(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter(
      x => x.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1,
    );
  }

  // tslint:disable-next-line: typedef
  alternarImagem() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  // tslint:disable-next-line: typedef
  getEventos() {
    this.eventoService.GetAllEvento().subscribe(
        // tslint:disable-next-line: variable-name
        (_eventos: Evento[]) => {
        this.eventos = _eventos;
        this.eventosFiltrados = this.eventos;
        console.log(_eventos);
      }, error => {
        console.log(error);
      }
    );
  }

}
