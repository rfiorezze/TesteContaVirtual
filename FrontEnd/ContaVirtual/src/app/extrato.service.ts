import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class ExtratoService {

  constructor(private http: HttpClient) { }

  listarExtrato(idConta: any, idTipoMov: any, dataIni: string, dataFim: string) : Observable<any> {

    return this.http.get("https://localhost:44381/api/Movimentacoes/"+idConta+"/"+idTipoMov+"/"+dataIni+"/"+dataFim);

  }
  
  listarDadosConta(idConta: any) : Observable<any> {

    return this.http.get("https://localhost:44381/api/Contas/"+idConta);

  }

  listarTipoMovimentacao() : Observable<any> {

    return this.http.get("https://localhost:44381/api/TipoMovimentacaos");

  }
}
