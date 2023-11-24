import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-cadastrar-tarefa',
  template: `
    <h1>Cadastro de Tarefas</h1>
    <div>
      <input type="text" name="nome" id="nome">
    </div>
    <div>
      <input type="text" name="descricao" id="descricao">
    </div>
    <div>    
    <input type="text" name="status" id="status">
    </div>
    <div>
      <input type="text" name="categoria" id="categoria">
    </div>
  `,
  styles: [
  ]
})
export class CadastrarTarefaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
