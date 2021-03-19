import { Component, OnInit } from '@angular/core';
import { ExtratoService } from '../extrato.service';

@Component({
  selector: 'app-extrato-listagem',
  templateUrl: './extrato-listagem.component.html',
  styleUrls: ['./extrato-listagem.component.css']
})
export class ExtratoListagemComponent implements OnInit {

  dadosConta: any = {};
  tipoMov: any;
  saldoFinal: any;
  selectedMov: any;
  dataIni: any;
  dataFim: any;
  extratoConta: Array<any> = new Array(); 

  constructor(private extratoService: ExtratoService) { }

  ngOnInit(): void {
    this.listarConta(1);
    this.listarTipoMovimentacao();
    //this.listarExtrato(1,0,'2021-03-18','2021-03-18');        
  }

  listarExtrato(idConta: any, idTipoMov: any, dataIni: string, dataFim: string){

    if(idTipoMov == undefined){
      alert('Favor preencher o Tipo de Transação!');
      return;
    }

    if(dataIni == undefined){
      alert('Favor preencher a Data Inicial!');
      return;
    }
    
    if(dataFim == undefined){
      alert('Favor preencher a Data Final!');
      return;
    }
    
    this.extratoService.listarExtrato(idConta,idTipoMov,dataIni,dataFim).subscribe(extrato => {
      this.extratoConta = extrato.movimentacoes;
      this.saldoFinal = extrato.saldoFinal;
    }, err => {
      console.log('Erro ao listar o extrato', err);
    });


  }  

  listarConta(idConta: any){
    
    this.extratoService.listarDadosConta(idConta).subscribe(conta => {
      this.dadosConta = conta;
    }, err => {
      console.log('Erro ao listar o extrato', err);
    });   


  }  

  listarTipoMovimentacao(){
    
    this.extratoService.listarTipoMovimentacao().subscribe(mov => {
      this.tipoMov = mov;
    }, err => {
      console.log('Erro ao listar o extrato', err);
    });   


  }  

}
